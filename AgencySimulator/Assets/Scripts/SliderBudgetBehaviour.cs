using System;
using System.Collections;
using System.Collections.Generic;
using Michsky.UI.ModernUIPack;
using UnityEngine;
using UnityEngine.Serialization;

public class SliderBudgetBehaviour : MonoBehaviour
{
    public SliderManager slider;

    [FormerlySerializedAs("previousValue")]
    [SerializeField]
    private float previous = 0;

    public RadialSlider radialSlider;

    private void Start()
    {
        if (slider == null)
            slider = GetComponent<SliderManager>();
        slider.sliderEvent.AddListener(OnValueChanged);

        remaining = 100 - radialSlider.currentValue;
    }

    [SerializeField]
    private float delta;

    [SerializeField]
    private float remaining;

    public void OnValueChanged(float current)
    {
        delta = current - previous;
        remaining = 100 - radialSlider.SliderValue;
        if (remaining <= 0 && delta > 0)
        {
            slider.mainSlider.value = previous;
            return;
        }

        if (delta > remaining)//if the change in slider is more than what is left, try setting it to that amount
        {
            
            
            slider.mainSlider.value = previous + remaining;
            current = slider.mainSlider.value;
            delta = current - previous;
        }

        radialSlider.SliderValue += delta;
        previous = current;


        radialSlider.UpdateUI();
    }
}