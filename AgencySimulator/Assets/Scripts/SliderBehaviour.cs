using System;
using ChuTools.Scripts;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class SliderBehaviour : MonoBehaviour
{
    public FloatVariable refValue;

    [SerializeField] private Slider _slider;
    public float oldValue;
    public float remaining;
    private void Start()
    {
        oldValue = _slider.value;
        refValue.OnPropertyChanged.AddListener(onValueChanged);
    }

    public void onValueChanged(float value)
    {
        remaining = 100 - refValue.Value;
        float newValue = oldValue + value;
        if (newValue >= 100 - refValue.Value)
            return;
        _slider.value = newValue;
    }
 
}