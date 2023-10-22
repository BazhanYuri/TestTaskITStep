using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class DirectionShower : MonoBehaviour
{
    [SerializeField] private Transform _arrow;
    [SerializeField] private Movement _movement;


    private void OnEnable()
    {
        _movement.MovementStarted += OnMovementStarted;
    }

   
    private void OnDisable()
    {
        _movement.MovementStarted -= OnMovementStarted;
    }
    private void OnMovementStarted(Vector2 lookAtPosition)
    {
        Vector2 direction = lookAtPosition - (Vector2)_arrow.position;

        // Calculate the rotation angle in degrees
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Rotate the arrow to point in the calculated direction
        _arrow.rotation = Quaternion.Euler(0, 0, angle);
    }
}
