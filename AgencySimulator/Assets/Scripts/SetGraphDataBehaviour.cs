using ChartAndGraph;
using ChuTools.Attributes;
using UnityEngine;

public class SetGraphDataBehaviour : MonoBehaviour
{
    public BarChart barChart;

    public FormulaContainer FormulaContainer;

    [SerializeField]
    [ScriptVariable(typeof(GameFormula))]
    public GameFormula formulaReference;

    [SerializeField]
    private Material playerMaterial;

    void Start()
    {
        formulaReference = FormulaContainer[0];
        formulaReference.OnCalculate.AddListener(SetGraphValues);
        formulaReference.Calculate();
    }

    private void SetGraphValues()
    {
        var pcount = 1;
        playerMaterial = Instantiate(playerMaterial);

        barChart.DataSource.ClearValues();
        barChart.DataSource.ClearGroups();
        barChart.DataSource.ClearCategories();
        barChart.DataSource.AutomaticMaxValue = true;


        for (int i = 0; i < pcount; i++)
        {
            var category = "Player" + i;
            barChart.DataSource.AddCategory(category, playerMaterial);
            for (int j = 0; j < formulaReference.Results.Count; j++)
            {
                var group = "Period" + j;

                barChart.DataSource.AddGroup(@group);
                barChart.DataSource.SlideValue(category, @group, formulaReference.Results[j], 1);
            }
        }
    }

    private void SetFormula(GameFormula formula)
    {
        if (formulaReference.OnCalculate == null) return;
        formulaReference.OnCalculate.RemoveListener(SetGraphValues);
        formulaReference = formula;

        formulaReference.OnCalculate.AddListener(SetGraphValues);
    }


    public void OnDropdownChanged(int index)
    {
        Debug.Log("new formula is " + FormulaContainer[index].name);
        SetFormula(FormulaContainer[index]);
    }
}