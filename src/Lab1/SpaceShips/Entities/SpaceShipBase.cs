using System;
using Itmo.ObjectOrientedProgramming.Lab1.Engines.Impulse.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Engines.Jump.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Protection.Deflectors.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.Protection.Frames.Entities;
using Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Status;
using Null = Itmo.ObjectOrientedProgramming.Lab1.Obstacles.Models.Null;

namespace Itmo.ObjectOrientedProgramming.Lab1.SpaceShips.Entities;

public abstract class SpaceShipBase
{
    protected SpaceShipBase(
        FrameBase frame,
        ImpulseBase impulse,
        DeflectorBase? deflector = null,
        JumpBase? jumpingEngine = null)
    {
        Frame = frame ?? throw new ArgumentNullException(nameof(frame));

        ImpulseEngine = impulse ?? throw new ArgumentNullException(nameof(impulse));

        Deflector = deflector ?? new Protection.Deflectors.Models.NullDeflector();

        JumpingEngine = jumpingEngine ?? new Engines.Jump.Models.Null();

        AntiNitrineEmitter = false;
    }

    public TypeOfShip Type { get; protected set; }

    public double ConsumptedFuel { get; protected internal set; }

    public ShipTravelResult ShipStatus { get; protected set; }
    protected internal Engines.Jump.Entities.JumpBase JumpingEngine { get; private set; }
    protected internal Engines.Impulse.Entities.ImpulseBase ImpulseEngine { get; private set; }
    protected bool AntiNitrineEmitter { get; init; }
    private Protection.Deflectors.Entities.DeflectorBase? Deflector { get; set; }
    private Protection.Frames.Entities.FrameBase Frame { get; set; }

    public ShipTravelResult TakeDamage(Obstacles.Entities.ObstacleBase? obstacle)
    {
        obstacle ??= new Null();

        if (obstacle is CosmoKits && !AntiNitrineEmitter && Deflector is not Protection.Deflectors.Models.C)
        {
            return ShipTravelResult.Crushed;
        }

        ShipStatus = Frame.TakeDamage(obstacle);

        if (ShipStatus != ShipTravelResult.Success)
        {
            return ShipTravelResult.Crushed;
        }

        if (Deflector == null) return ShipTravelResult.Crushed;

        if (Deflector.Modifier == null && obstacle is AntimatterFlares) return ShipTravelResult.Crushed;

        ShipStatus = Deflector.TakeDamage(obstacle);

        return ShipStatus == ShipTravelResult.Success ? ShipTravelResult.Success : ShipStatus;
    }
}