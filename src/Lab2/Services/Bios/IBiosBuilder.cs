namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Bios;

public interface IBiosBuilder
{
    IBiosBuilder WithType(string type);
    IBiosBuilder WithVersion(string version);
    IBiosBuilder WithSupportableCpus(params string[] cpuNames);
    Models.Bios Build();
}