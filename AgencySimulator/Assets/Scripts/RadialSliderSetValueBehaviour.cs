using ChuTools.Attributes;
using ChuTools.Scripts;
using Michsky.UI.ModernUIPack;
using UnityEngine;
using UnityEngine.Serialization;

/// <summary>
///     use this script to change the value of a slider to the value of a target reference variable
/// </summary>
public class RadialSliderSetValueBehaviour : MonoBehaviour
{
    [FormerlySerializedAs("targetValue")]
    [ScriptVariable(typeof(FloatVariable))]
    public FloatVariable refValue;

    public FloatVariable remainingValue;
    public RadialSlider slider;

    private void Start()
    {
        refValue.OnPropertyChanged.AddListener(OnRefValueChanged);
    }

    public void OnRefValueChanged(float newValue)
    {
        slider.SliderValue = newValue;
        slider.UpdateUI();
    }
}