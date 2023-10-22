using System;
using UnityEngine;
using UnityEngine.UI;

public class SpeedChangeView : MonoBehaviour, ISpeedChangeView
{
    [SerializeField] private Slider _slider;

    public float Value { get; private set; }

    public event Action ValueChanged;



    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(OnSliderValueChanged);
        
    }
    private void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(OnSliderValueChanged);
    }
    private void OnSliderValueChanged(float arg0)
    {
        Value = arg0;
        ValueChanged?.Invoke();
    }
}
