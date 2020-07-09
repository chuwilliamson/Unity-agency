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
/*
 *ToDo:
1. ENter number of players
2. ENter player names and entry parameters
3. show results for all players for first KPI 
4. Iterate through all KPIs
5. Show final scores for all users (average of all KPIs)
6. Option to go to menu or play again
 */
    private void Start()
    {
        _slider.sliderEvent.AddListener(SetInput);
        Title.SetText(Formula.name);
        _slider.mainSlider.value = Formula.input;
        
        
        _slider.sliderEvent.AddListener((s)=>
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