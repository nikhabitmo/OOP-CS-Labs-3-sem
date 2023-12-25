using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.CPU;
using Itmo.ObjectOrientedProgramming.Lab2.Entities.Drive;
using Itmo.ObjectOrientedProgramming.Lab2.Models;
using Itmo.ObjectOrientedProgramming.Lab2.Models.ConnectionType;
using Itmo.ObjectOrientedProgramming.Lab2.Models.DdrStandart;
using Itmo.ObjectOrientedProgramming.Lab2.Models.FormFactor;
using Itmo.ObjectOrientedProgramming.Lab2.Models.Storage;
using Itmo.ObjectOrientedProgramming.Lab2.Services.Bios;
using Itmo.ObjectOrientedProgramming.Lab2.Services.CPU;
using Itmo.ObjectOrientedProgramming.Lab2.Services.MotherBoard;
using Itmo.ObjectOrientedProgramming.Lab2.Services.RAM;
using Itmo.ObjectOrientedProgramming.Lab2.Services.VideoCard;

namespace Itmo.ObjectOrientedProgramming.Lab2.DataBase;

public class DataBase
{
    public ICollection<Entities.Cpu> CPUs { get; private set; } = new List<Entities.Cpu>()
    {
        new CpuBuilder()
            .WithName("HighPerformanceCPU")
            .WithSupportedSocket(new Sockets().FindSocketByName("AMDsWRX8"))
            .WithCoreFrequency(4000)
            .WithBuiltInVideoCore(false)
            .WithSupportedMemoryFrequencies(3200)
            .WithHeatDissipation(95)
            .WithPowerConsumption(2300)
            .WithCoolingSystem(
                new CoolingSystem("Liquid Cooling", new Dimension(120, 220), maximumHeatdissipationMass: 200)
                    .AddSupportedSocket(new Socket("sWRX8", "AMDsWRX8")))
            .Build(),

        new CpuBuilder()
            .WithName("MidRangeCPU")
            .WithSupportedSocket(new Sockets().FindSocketByName("Intel V1"))
            .WithCoreFrequency(3200)
            .WithBuiltInVideoCore(true)
            .WithSupportedMemoryFrequencies(2666)
            .WithHeatDissipation(65)
            .WithPowerConsumption(2500)
            .WithCoolingSystem(
                new CoolingSystem("Air Cooling", new Dimension(230, 120), maximumHeatdissipationMass: 150)
                    .AddSupportedSocket(new Socket("LGA 1851", "Intel V1")))
            .Build(),

        new CpuBuilder()
            .WithName("BudgetCPU")
            .WithSupportedSocket(new Sockets().FindSocketByName("Intel V1"))
            .WithCoreFrequency(2500)
            .WithBuiltInVideoCore(true)
            .WithSupportedMemoryFrequencies(2133)
            .WithHeatDissipation(45)
            .WithPowerConsumption(3000)
            .WithCoolingSystem(new CoolingSystem(
                "Air Cooling",
                new Dimension(220, 200),
                maximumHeatdissipationMass: 100))
            .Build(),
    };

    public ICollection<Entities.MotherBoard> MotherBoards { get; private set; } = new List<Entities.MotherBoard>()
    {
        new MotherboardBuilder().WithNumberOfPcieLines(16)
            .WithNumberOfSataPorts(6)
            .WithChipSet("SomeChipset")
            .WithDdrStandard(new Ddr4())
            .WithNumberOfRamSlots(4)
            .WithMotherboardFormFactor(new ATXFormFactor())
            .WithBios(new BiosBuilder()
                .WithType("a").WithVersion("a").WithSupportableCpus("a", "a"))
            .WithXmp(new Xmp("s", "87", 87))
            .WithSupportedSocket(new Socket("LGA1851", "Intel V1"))
            .WithName("motherboard1")
            .Build(),

        new MotherboardBuilder().WithNumberOfPcieLines(16)
            .WithNumberOfSataPorts(6)
            .WithChipSet("GamingChipset")
            .WithDdrStandard(new Ddr4())
            .WithNumberOfRamSlots(4)
            .WithMotherboardFormFactor(new ATXFormFactor())
            .WithBios(new BiosBuilder()
                .WithType("GamingType")
                .WithVersion("GamingVersion")
                .WithSupportableCpus("Intel Core i9", "AMD Ryzen 9"))
            .WithXmp(new Xmp("GamingXMP", "87", 87))
            .WithSupportedSocket(new Socket("Socket456", "SocketName456"))
            .WithName("motherboard2")
            .Build(),

        new MotherboardBuilder()
            .WithNumberOfPcieLines(8)
            .WithNumberOfSataPorts(4)
            .WithChipSet("OfficeChipset")
            .WithDdrStandard(new Ddr3())
            .WithNumberOfRamSlots(2)
            .WithMotherboardFormFactor(new MicroATXFormFactor())
            .WithBios(new BiosBuilder()
                .WithType("OfficeType")
                .WithVersion("OfficeVersion")
                .WithSupportableCpus("Intel Core i3", "AMD Ryzen 3"))
            .WithSupportedSocket(new Socket("Socket789", "SocketName789"))
            .WithName("Office Motherboard")
            .Build(),

        new MotherboardBuilder()
            .WithNumberOfPcieLines(4)
            .WithNumberOfSataPorts(2)
            .WithChipSet("BudgetChipset")
            .WithDdrStandard(new Ddr3())
            .WithNumberOfRamSlots(2)
            .WithMotherboardFormFactor(new MicroATXFormFactor())
            .WithBios(new BiosBuilder()
                .WithType("BudgetType")
                .WithVersion("BudgetVersion")
                .WithSupportableCpus("Intel Pentium", "AMD Athlon"))
            .WithSupportedSocket(new Socket("Socket101", "SocketName101"))
            .WithName("Budget Motherboard")
            .Build(),

        new MotherboardBuilder()
            .WithNumberOfPcieLines(32)
            .WithNumberOfSataPorts(8)
            .WithChipSet("ServerChipset")
            .WithDdrStandard(new Ddr4())
            .WithNumberOfRamSlots(16)
            .WithMotherboardFormFactor(new ExtendedATXFormFactor())
            .WithBios(new BiosBuilder()
                .WithType("ServerType")
                .WithVersion("ServerVersion")
                .WithSupportableCpus("Intel Xeon", "AMD EPYC"))
            .WithXmp(new Xmp("ServerXMP", "100", 100))
            .WithSupportedSocket(new Socket("Socket202", "SocketName202"))
            .WithName("Server Motherboard")
            .Build(),

        new MotherboardBuilder()
            .WithNumberOfPcieLines(8)
            .WithNumberOfSataPorts(4)
            .WithChipSet("OfficeBasicChipset")
            .WithDdrStandard(new Ddr3())
            .WithNumberOfRamSlots(2)
            .WithMotherboardFormFactor(new MicroATXFormFactor())
            .WithBios(new BiosBuilder()
                .WithType("OfficeBasicType")
                .WithVersion("OfficeBasicVersion"))
            .WithSupportedSocket(new Socket("Socket303", "SocketName303"))
            .WithName("Office Basic Motherboard")
            .Build(),
    };

    public ICollection<Ram> Rams { get; private set; } = new List<Ram>()
    {
        new RamBuilder()
            .WithName("Sample RAM")
            .WithFormFactor("DIMM")
            .WithDdrStandardVersion("DDR4")
            .WithSupportedXmpAndDocProfiles(new List<string> { "XMP 2.0", "DOCP" })
            .WithAvailableMemorySize(16)
            .WithPowerConsumption(5)
            .WithSupportedJedecFrequencyAndVoltage(2400, 1.2)
            .Build(),

        new RamBuilder()
            .WithName("Corsair Vengeance LPX 16GB")
            .WithFormFactor("DIMM")
            .WithDdrStandardVersion("DDR4")
            .WithSupportedXmpAndDocProfiles(new List<string> { "XMP 2.0" })
            .WithAvailableMemorySize(16)
            .WithPowerConsumption(1.35)
            .WithSupportedJedecFrequencyAndVoltage(2400, 1.2)
            .Build(),

        new RamBuilder()
            .WithName("Kingston HyperX 8GB")
            .WithFormFactor("DIMM")
            .WithDdrStandardVersion("DDR3")
            .WithSupportedXmpAndDocProfiles(new List<string> { "XMP 1.3" })
            .WithAvailableMemorySize(8)
            .WithPowerConsumption(1.5)
            .WithSupportedJedecFrequencyAndVoltage(1600, 1.5)
            .Build(),

        new RamBuilder()
            .WithName("Crucial Ballistix 32GB")
            .WithFormFactor("DIMM")
            .WithDdrStandardVersion("DDR4")
            .WithSupportedXmpAndDocProfiles(new List<string> { "XMP 2.0", "DOCP 2.0" })
            .WithAvailableMemorySize(32)
            .WithPowerConsumption(1.2)
            .WithSupportedJedecFrequencyAndVoltage(3200, 1.35)
            .Build(),

        new RamBuilder()
            .WithName("G.Skill Ripjaws V 16GB")
            .WithFormFactor("DIMM")
            .WithDdrStandardVersion("DDR4")
            .WithSupportedXmpAndDocProfiles(new List<string> { "XMP 2.0" })
            .WithAvailableMemorySize(16)
            .WithPowerConsumption(1.35)
            .WithSupportedJedecFrequencyAndVoltage(2666, 1.2)
            .Build(),

        new RamBuilder()
            .WithName("AMD HyperX Fury 16GB")
            .WithFormFactor("DIMM")
            .WithDdrStandardVersion("DDR3")
            .WithSupportedXmpAndDocProfiles(new List<string> { "XMP 1.3" })
            .WithAvailableMemorySize(16)
            .WithPowerConsumption(1.5)
            .WithSupportedJedecFrequencyAndVoltage(1866, 1.5)
            .Build(),

        new RamBuilder()
            .WithName("Intel Optane 16GB")
            .WithFormFactor("DIMM")
            .WithDdrStandardVersion("DDR4")
            .WithSupportedXmpAndDocProfiles(new List<string> { "XMP 2.0" })
            .WithAvailableMemorySize(16)
            .WithPowerConsumption(1.35)
            .WithSupportedJedecFrequencyAndVoltage(2133, 1.2)
            .Build(),
    };

    public ICollection<Entities.PowerUnit> PowerUnits { get; private set; } = new Collection<Entities.PowerUnit>()
    {
        new Entities.PowerUnit("PowerUnit1", 500),
        new Entities.PowerUnit("PowerUnit2", 750),
        new Entities.PowerUnit("PowerUnit3", 450),
    };

    public IList<Frame> Frames { get; private set; } = new List<Frame>()
    {
        new Frame("Standart Frame", 450, 220, 15),
        new Frame("Compact Frame", 350, 180, 12),
        new Frame("HighPerformanceFrame", 550, 250, 20),
    };

    public ICollection<BasicDrive> Drives { get; private set; } = new List<BasicDrive>()
    {
        new SSD("SSD1", new SATA(), 700, 80, 2000),
        new SSD("SSD2", new PCIE(), 1000, 15, 20),
        new HDD("HDD1", new SATA(), 750, 12),
    };

    public ICollection<Entities.VideoCard> VideoCards { get; private set; } = new List<Entities.VideoCard>()
    {
        new VideoCardBuilder()
            .WithName("Null")
            .WithHeight(0)
            .WithWidth(0)
            .WithVideoMemorySize(0)
            .WithPciExpressVersion("0")
            .WithChipFrequency(0)
            .WithPowerConsumption(0)
            .Build(),

        new VideoCardBuilder()
            .WithName("HighPerformanceVideoCard")
            .WithHeight(10)
            .WithWidth(20)
            .WithVideoMemorySize(16)
            .WithPciExpressVersion("3.0")
            .WithChipFrequency(2000)
            .WithPowerConsumption(200)
            .Build(),

        new VideoCardBuilder()
            .WithName("MidRangeVideoCard")
            .WithHeight(8)
            .WithWidth(18)
            .WithVideoMemorySize(8)
            .WithPciExpressVersion("2.0")
            .WithChipFrequency(1500)
            .WithPowerConsumption(150)
            .Build(),

        new VideoCardBuilder()
            .WithHeight(6)
            .WithWidth(16)
            .WithVideoMemorySize(4)
            .WithPciExpressVersion("1.0")
            .WithChipFrequency(1000)
            .WithPowerConsumption(100)
            .Build(),
    };

    public ICollection<Entities.WiFiAdapter> WiFiAdapters { get; private set; } =
        new Collection<Entities.WiFiAdapter>()
        {
            new Entities.WiFiAdapter("StandartWiFiAdapter", "2", true, "897f", 2),
            new Entities.WiFiAdapter("StandartWiFiAdapter2", "2", false, "897f", 3),
            new Entities.WiFiAdapter("StandartWiFiAdapter3", "3", true, "897a", 2),
            new Entities.WiFiAdapter("StandartWiFiAdapter4", "2", false, "897d", 4),
            new Entities.WiFiAdapter("StandartWiFiAdapter5", "4", false, "897f", 3),
            new Entities.WiFiAdapter("StandartWiFiAdapter6", "3", true, "897b", 4),
            new Entities.WiFiAdapter("StandartWiFiAdapter7", "5", true, "89af", 5),
        };

    public void AddCpu(Entities.Cpu cpu)
    {
        CPUs.Add(cpu);
    }

    public void AddMotherBoard(Entities.MotherBoard motherboard)
    {
        MotherBoards.Add(motherboard);
    }

    public void AddRam(Ram ram)
    {
        Rams.Add(ram);
    }

    public void AddPowerUnit(Entities.PowerUnit powerUnit)
    {
        PowerUnits.Add(powerUnit);
    }

    public void AddFrame(Frame frame)
    {
        Frames.Add(frame);
    }

    public void AddDrive(BasicDrive drive)
    {
        Drives.Add(drive);
    }

    public void AddVideoCard(Entities.VideoCard videoCard)
    {
        VideoCards.Add(videoCard);
    }

    public void AddWiFiAdapter(Entities.WiFiAdapter wifiAdapter)
    {
        WiFiAdapters.Add(wifiAdapter);
    }
}