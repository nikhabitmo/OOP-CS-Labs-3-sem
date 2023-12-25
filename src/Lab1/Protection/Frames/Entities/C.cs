using Itmo.ObjectOrientedProgramming.Lab1.Protection.Frames.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Protection.Frames.Models;

public class C : FrameBase
{
    public C()
        : base()
    {
        HitPoints = Config.HitPoints.C;
    }
}