using ChuTools.Scripts;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SliderBehaviour : MonoBehaviour
{
    public Slider slider;
    
    public FloatVariable resourceVariable;

    [SerializeField]
    private float oldValue;


    public float textVariable;
    private void Start()
    {

        if(slider == null)
            slider = GetComponent<Slider>();
        slider.onValueChanged.AddListener(OnSliderValueChanged);

        oldValue = slider.value;
    }
 
    public void OnSliderValueChanged(float value)
    {
        float deltaValue = value - oldValue;
        float newValue = value;

        if ((resourceVariable.Value - deltaValue) > 0)
            oldValue = value;
        else
            slider.value = oldValue;
    }


}
