using System;
using System.Collections;
using UnityEngine;
public class Movement : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    private Vector2 _currentMovingPoint;
    private IPointsMovementHolder _pointsMovementHolder;
    private IUIBuilder _uiBuilder;

    private bool _isMovingStarted = false;
    private float _distanceToReachPoint = 0.1f;
    private float _standartSpeed = 5f;

    public event Action<Vector2> MovementStarted;

    public void Initialize(IPointsMovementHolder pointsMovementHolder, IUIBuilder uiBuilder, Rigidbody2D rigidbody2D)
    {
        _pointsMovementHolder = pointsMovementHolder;
        _uiBuilder = uiBuilder;
        _rigidbody2D = rigidbody2D;

        _pointsMovementHolder.PointAdded += PointAdded;
    }

    private void PointAdded()
    {
        if (!_isMovingStarted)
        {
            _isMovingStarted = true;
            SelectLastPoint();
        }
    }

    private void FixedUpdate()
    {
        if (_isMovingStarted)
        {
            if (CheckIsCloseToPoint() == false)
            {
                MoveToPoint();
            }
            else
            {
                _isMovingStarted = false;
            }
        }
        else
        {
            if (!_pointsMovementHolder.IsPointsEmpty())
            {
                _isMovingStarted = true;
                SelectLastPoint();
            }
        }
    }

    private bool CheckIsCloseToPoint()
    {
        return Vector2.Distance(transform.position, _currentMovingPoint) < _distanceToReachPoint;
    }

    private void MoveToPoint()
    {
        transform.position = Vector2.MoveTowards(transform.position, _currentMovingPoint, _standartSpeed * Time.deltaTime * _uiBuilder.SpeedChangeView.Value);
    }

    private void SelectLastPoint()
    {
        _currentMovingPoint = _pointsMovementHolder.GetLastPoint();
        MovementStarted?.Invoke(_currentMovingPoint);
    }
}
