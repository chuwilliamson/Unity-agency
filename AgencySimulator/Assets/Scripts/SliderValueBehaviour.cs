using UnityEngine;
using UnityEngine.UI;

public class SliderValueBehaviour : MonoBehaviour
{
    public Slider slider;

    public Text Text;
    // Start is called before the first frame update

    // Update is called once per frame
    private void Update()
    {
        Text.text = slider.value.ToString();
    }
}