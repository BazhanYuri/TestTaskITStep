using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInput
{
    public event Action<Vector2> Clicked;
}
