using UnityEngine;
using Zenject;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System;

public class PlayerInput : IInput, ITickable
{
    public event Action<Vector2> Clicked;

    public void Tick()
    {
        CheckAndDetectMouseClick();
    }

    private void CheckAndDetectMouseClick()
    {
        if (Input.GetMouseButtonDown(0) && !IsPointerOverUI())
        {
            Clicked?.Invoke(Input.mousePosition);
        }
    }

    private bool IsPointerOverUI()
    {
        PointerEventData eventData = new PointerEventData(EventSystem.current);
        eventData.position = Input.mousePosition;
        var raycastResults = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, raycastResults);
        return raycastResults.Count > 0;
    }
}