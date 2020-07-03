using ChuTools.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class SliderBehaviour : MonoBehaviour
{
    [SerializeField] private float oldValue;

    public FloatVariable resourceVariable;
    public Slider slider;


    public float textVariable;

    private void Start()
    {
        if (slider == null)
            slider = GetComponent<Slider>();
        slider.onValueChanged.AddListener(OnSliderValueChanged);

        oldValue = slider.value;
    }

    public void OnSliderValueChanged(float value)
    {
        var deltaValue = value - oldValue;
        var newValue = value;

        if (resourceVariable.Value - deltaValue > 0)
            oldValue = value;
        else
            slider.value = oldValue;
    }
}