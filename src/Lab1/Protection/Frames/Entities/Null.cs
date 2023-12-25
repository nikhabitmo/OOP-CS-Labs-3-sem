using Itmo.ObjectOrientedProgramming.Lab1.Units;

namespace Itmo.ObjectOrientedProgramming.Lab1.Protection.Frames.Models;

public class Null : Entities.FrameBase
{
    protected Null()
        : base()
    {
        HitPoints = new HitPoint();
    }
}