using Itmo.ObjectOrientedProgramming.Lab1.Protection.Deflectors.Config;
using Itmo.ObjectOrientedProgramming.Lab1.Protection.Deflectors.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Protection.Deflectors.Models;

public class Photonic : ModifierBase
{
    public Photonic()
        : base()
    {
        DefenceAntiMatterFlares = Modifications.CanDefendAntiMatterFlares;
    }
}