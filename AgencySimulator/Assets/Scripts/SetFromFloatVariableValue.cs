using ChuTools.Scripts;
using Michsky.UI.ModernUIPack;
using UnityEngine;

public class SetFromFloatVariableValue : MonoBehaviour
{
    public FloatVariable refValue;

    public RadialSlider slider;

    public void OnValueChanged(float value)
    {
        slider.SliderValue = value;
        slider.UpdateUI();
    }
}