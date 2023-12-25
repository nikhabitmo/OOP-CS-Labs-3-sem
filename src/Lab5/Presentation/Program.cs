using Application.Extensions;
using Infrastructure.Extensions;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.Extensions.DependencyInjection.Extensions;

var collection = new ServiceCollection();

IConfigurationRoot configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

collection
    .AddApplication()
    .AddInfrastructureDataAccess(configure =>
    {
        configure.Host = configuration["ConnectionStrings:DefaultConnection:Host"] ??
                         throw new InvalidOperationException(nameof(configure.Host));

#pragma warning disable CA1305
        configure.Port = int.Parse(configuration["ConnectionStrings:DefaultConnection:Port"] ??
                                   throw new InvalidOperationException(nameof(configure.Port)));
#pragma warning restore CA1305

        configure.Username = configuration["ConnectionStrings:DefaultConnection:Username"] ??
                             throw new InvalidOperationException(nameof(configure.Username));

        configure.Password = configuration["ConnectionStrings:DefaultConnection:Password"] ??
                             throw new InvalidOperationException(nameof(configure.Password));

        configure.Database = configuration["ConnectionStrings:DefaultConnection:Database"] ??
                             throw new InvalidOperationException(nameof(configure.Database));
    });

#pragma warning disable ASP0000
ServiceProvider provider = collection.BuildServiceProvider();
#pragma warning restore ASP0000
using IServiceScope scope = provider.CreateScope();

await scope.UseInfrastructureDataAccess();

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.Add(collection);
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
    .AddNegotiate().AddCookie();

builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = options.DefaultPolicy;
});
builder.Services.AddRazorPages();
WebApplication app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");

    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

await app.RunAsync();