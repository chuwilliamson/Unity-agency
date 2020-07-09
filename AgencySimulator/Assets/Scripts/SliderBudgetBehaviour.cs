using System;
using System.Collections;
using System.Collections.Generic;
using Michsky.UI.ModernUIPack;
using UnityEngine;

public class SliderBudgetBehaviour : MonoBehaviour
{
    public SliderManager slider;
    
    [SerializeField]
    private float previousValue = 0;
    
    public RadialSlider radialSlider;
    private void Start()
    {
        if (slider == null)
            slider = GetComponent<SliderManager>();
        
        remaining = 100 - radialSlider.currentValue;
    }

    [SerializeField]
    private float delta;
    
    [SerializeField]
    private float remaining;
    
    public void OnValueChanged(float current)
    {
        delta = current - previousValue;
        remaining = 100 - radialSlider.SliderValue;
        if(delta > remaining)
            slider.mainSlider.value = previousValue;
        else
        {
            radialSlider.SliderValue += delta;
            previousValue = current;
        }
        
        
        radialSlider.UpdateUI();
        
    }
}