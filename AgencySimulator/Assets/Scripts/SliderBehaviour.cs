using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SliderBehaviour : MonoBehaviour
{
    public List<Slider> sliders;    

    // Update is called once per frame
    void Update()
    {
        float sliderTotal = 0;
        foreach(Slider slider in sliders)
        {
            sliderTotal += slider.value;

        }
    }
}
