using System;

public interface ISpeedChangeView
{
    public float Value { get; }
    public event Action ValueChanged;
}
