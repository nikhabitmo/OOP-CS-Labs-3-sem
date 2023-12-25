using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Units;

public class HitPoint
{
    private int _value;

    public HitPoint(int value = 0)
    {
        SetValue(value);
    }

    public int Value
    {
        get => _value;
        private set => SetValue(value);
    }

    public HitPoint Lose(HitPoint damage)
    {
        if (damage == null) throw new ArgumentNullException(nameof(damage));
        if (Value < damage.Value) Value = 0;
        else Value -= damage.Value;
        return this;
    }

    private void SetValue(int value)
    {
        if (value < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(value), "Hit points cannot be negative.");
        }

        _value = value;
    }
}