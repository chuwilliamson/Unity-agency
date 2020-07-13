using System.Collections.Generic;
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
        
    }

    public List<PlayerObject> Players;
    private static readonly int Tint = Shader.PropertyToID("_Tint");

    public void SetPlayers()
    {
        Players = new List<PlayerObject>(GameStateBehaviour.Players);
    }

    [ContextMenu("SetGraphValues")]
    public void SetGraphValues()
    { 
        barChart.DataSource.ClearValues();
        barChart.DataSource.ClearGroups();
        barChart.DataSource.ClearCategories();
        barChart.DataSource.AutomaticMaxValue = true;


        foreach(var player in Players)
        {
            var category = player.Name;
            if (barChart.DataSource.HasCategory(category))
                continue;
            
            var mat = Instantiate(playerMaterial);
            mat.color = Random.ColorHSV();
            barChart.DataSource.AddCategory(category, mat);
        }

        int year = 2020;
        for (int j = 0; j < formulaReference.Results.Count; j++)
        {
            var group = year.ToString();
            if(barChart.DataSource.HasGroup(group))
                continue;
            barChart.DataSource.AddGroup(group);
            year++;
        }

        year = 2020;
        for (int j = 0; j < formulaReference.Results.Count; j++)
        {
            foreach(var player in Players)
            {
                var category = player.Name;
                var group = year.ToString();
                Debug.Log("getting " + formulaReference.name);
                var results = player.ResultsDictionary[formulaReference.name];
                barChart.DataSource.SetValue(category, group, results[j]);
                
            }
            year++;
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