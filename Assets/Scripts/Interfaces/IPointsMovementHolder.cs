using System;
using UnityEngine;

public interface IPointsMovementHolder
{
    public event Action PointAdded;
    public Vector2 GetLastPoint();
    public bool IsPointsEmpty();
}
