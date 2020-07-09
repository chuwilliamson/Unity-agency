using ChuTools.Attributes;
using Michsky.UI.ModernUIPack;
using TMPro;
using UnityEngine;

public class FormulaSliderBehaviour : MonoBehaviour
{
    [SerializeField]
    private SliderManager _slider;

    [ScriptVariable(typeof(GameFormula))]
    public GameFormula Formula;

    [SerializeField]
    private TMP_Text Title;

    public void SetInput(float input)
    {
        Formula.ChangeInput(input);
    }

    private void Start()
    {
        _slider.sliderEvent.AddListener(SetInput);
        Title.SetText(Formula.name);
        _slider.mainSlider.value = Formula.input;
        _slider.onValueChanged.AddListener((s)=>
        {
            Formula.Calculate();
        });
    }

    private void OnEnable()
    {
        Title.SetText(Formula.name);
    }

    public void SetFormula(GameFormula gameFormula)
    {
        Formula = gameFormula;
        Title.SetText(Formula.name);
    }
    
}