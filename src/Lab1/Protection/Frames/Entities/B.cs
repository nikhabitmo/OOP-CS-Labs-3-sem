using Itmo.ObjectOrientedProgramming.Lab1.Protection.Frames.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Protection.Frames.Models;

public class B : FrameBase
{
    public B()
        : base()
    {
        HitPoints = Config.HitPoints.B;
    }
}