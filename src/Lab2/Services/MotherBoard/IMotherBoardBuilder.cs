using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Models.DdrStandart;
using Itmo.ObjectOrientedProgramming.Lab2.Models.FormFactor;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Bios;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.MotherBoard;

public interface IMotherBoardBuilder
{
    IMotherBoardBuilder WithName(string name);
    IMotherBoardBuilder WithSupportedSocket(Socket socket);
    IMotherBoardBuilder WithNumberOfPcieLines(int numberOfPcieLines);
    IMotherBoardBuilder WithNumberOfSataPorts(int numberOfSataPorts);
    IMotherBoardBuilder WithChipSet(string chipSet);
    IMotherBoardBuilder WithDdrStandard(IDdrStandart ddrStandard);
    IMotherBoardBuilder WithNumberOfRamSlots(int numberOfRamSlots);
    IMotherBoardBuilder WithMotherboardFormFactor(MotherBoardFormFactor motherboardFormFactor);
    IMotherBoardBuilder WithBios(IBiosBuilder bios);
    IMotherBoardBuilder WithXmp(Xmp xmp);
    Entities.MotherBoard Build();
}
