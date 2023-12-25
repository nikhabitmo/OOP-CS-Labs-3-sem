namespace Application.Contracts.Users;

public abstract record LoginResult
{
    private LoginResult() { }

#pragma warning disable CA1034
    public sealed record SuccessAsUser : LoginResult;
#pragma warning restore CA1034

#pragma warning disable CA1034
    public sealed record Failure : LoginResult;
#pragma warning restore CA1034

#pragma warning disable CA1034
    public sealed record SuccessAsAdmin : LoginResult;
#pragma warning restore CA1034

#pragma warning disable CA1034
    public sealed record NotFound : LoginResult;
#pragma warning restore CA1034
}