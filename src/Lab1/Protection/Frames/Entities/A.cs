using Itmo.ObjectOrientedProgramming.Lab1.Protection.Frames.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab1.Protection.Frames.Models;

public class A : FrameBase
{
    public A()
    {
        HitPoints = Config.HitPoints.A;
    }
}