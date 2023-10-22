using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class MovementPointsHolder : IPointsMovementHolder, IInitializable
{
    private IInput _input;
    private List<Vector2> _points = new List<Vector2>();

    private Camera _camera;

    public event Action PointAdded;

    [Inject]
    public void Construct(IInput input)
    {
        _input = input;
    }

    public void Initialize()
    {
        _camera = Camera.main;
        _input.Clicked += OnMouseClicked;
    }

    public Vector2 GetLastPoint()
    {
        if (_points.Count > 0)
        {
            Vector2 lastPoint = _points[0];
            _points.RemoveAt(0);
            return lastPoint;
        }
        return Vector2.zero;
    }

    public bool IsPointsEmpty()
    {
        return _points.Count == 0;
    }

    private void OnMouseClicked(Vector2 screenPosition)
    {
        Vector3 worldPosition = _camera.ScreenToWorldPoint(new Vector3(screenPosition.x, screenPosition.y, _camera.nearClipPlane));
        _points.Add(worldPosition);
        PointAdded?.Invoke();
    }
}
