using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class SliderDistribute : MonoBehaviour
{
    public float m_bankValue;
    public float m_minValue;

    private float m_totalValue;

    public Text m_bankDisplay;
    public Slider[] m_sliders;





    // Start is called before the first frame update
    void Start()
    {
        m_totalValue = m_bankValue;
        m_sliders = GetComponentsInChildren<Slider>();
        
        foreach(Slider s in m_sliders)
        {
            s.minValue = m_minValue;
            s.maxValue = m_totalValue;
            s.onValueChanged.AddListener(delegate { DistributeSlider(s); });
        }
    }



    public void Update()
    {
        m_bankDisplay.text = m_bankValue.ToString();
    }



    public void DistributeSlider(Slider a_slider)
    {
        float sliderMax = m_totalValue - GetSlidersTotal(GetSlidersMinusOne(m_sliders, a_slider));
        a_slider.value = Mathf.Clamp(a_slider.value, m_minValue, sliderMax + (m_bankValue > 0f ? m_bankValue : 0f));
        m_bankValue = m_totalValue - GetSlidersTotal(m_sliders);
    }

    public static Slider[] GetSlidersMinusOne(Slider[] a_sliders, Slider a_exemptSlider)
    {
        List<Slider> returnSliders = new List<Slider>();
        
        foreach(Slider s in a_sliders)
        {
            if(s != a_exemptSlider)
            {
                returnSliders.Add(s);
            }
        }

        return returnSliders.ToArray();
    }

    public static float GetSlidersTotal(Slider[] a_sliders)
    {
        float sliderTotal = 0f;

        foreach (Slider s in a_sliders)
        {
            sliderTotal += s.value;
        }

        return sliderTotal;
    }
}
