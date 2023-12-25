using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Models.DdrStandart;
using Itmo.ObjectOrientedProgramming.Lab2.Models.FormFactor;
using Itmo.ObjectOrientedProgramming.Lab2.Services;

namespace Itmo.ObjectOrientedProgramming.Lab2.Entities;

public class MotherBoard : IComponent
{
    public MotherBoard(
        string name,
        Socket socket,
        int numberOfPcieLines,
        int numberOfSataPorts,
        string? chipSet,
        IDdrStandart? ddrStandart,
        int numberOfRamSlots,
        MotherBoardFormFactor? motherboardFormFactor,
        Bios bios,
        Xmp? xmp)
    {
        Name = name;
        SupportedSocket = socket;
        NumberOfPcieLines = numberOfPcieLines;
        NumberOfSataPorts = numberOfSataPorts;
        ChipSet = chipSet;
        DdrStandart = ddrStandart;
        NumberOfRamSlots = numberOfRamSlots;
        MotherboardFormFactor = motherboardFormFactor;
        Bios = bios;
        Xmp = xmp;
    }

    public string Name { get; set; } = string.Empty;
    public Socket SupportedSocket { get; private set; }
    public int NumberOfPcieLines { get; private set; }
    public int NumberOfSataPorts { get; private set; }
    public string? ChipSet { get; private set; }
    public IDdrStandart? DdrStandart { get; private set; }
    public int NumberOfRamSlots { get; private set; }
    public MotherBoardFormFactor? MotherboardFormFactor { get; private set; }
    public Bios Bios { get; private set; }
    public Xmp? Xmp { get; private set; }

    public MotherBoard Clone()
    {
        return new MotherBoard(
            Name,
            SupportedSocket,
            NumberOfPcieLines,
            NumberOfSataPorts,
            ChipSet,
            DdrStandart,
            NumberOfRamSlots,
            MotherboardFormFactor,
            Bios,
            Xmp);
    }
}