using System.Collections.Generic;
using ChartAndGraph;
using ChuTools.Attributes;
using Michsky.UI.ModernUIPack;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class ResultsPanelBehaviour : MonoBehaviour
{
    [SerializeField]
    private FormulaSliderBehaviour _formulaSliderBehaviour;

    [FormerlySerializedAs("labels")]
    public List<ButtonManager> buttonManagers;

    public GameObject constantInputFields;
    public Transform constantInputFieldsParent;
    [ScriptVariable(typeof(GameFormula))]
    public GameFormula Formula;

    public GraphChart graph;
    public UnityEvent OnStart;
    public List<float> results;
    public TMP_Text Tip;

    private void Start()
    {
        Tip.text = Formula.name;
        buttonManagers = new List<ButtonManager>(GetComponentsInChildren<ButtonManager>());
        results = new List<float>();
        var index = 0;
        _formulaSliderBehaviour.SetFormula(Formula);

        Formula.KFloats.ForEach(f =>
        {
            var go = Instantiate(constantInputFields, constantInputFieldsParent);
            var formulaInputFieldBehaviour = go.GetComponent<FormulaInputFieldBehaviour>();
            formulaInputFieldBehaviour.Formula = Formula;
            formulaInputFieldBehaviour.Index = index;
            index++;
        });

        OnStart.Invoke();
    }

    public void SetResults()
    {
        results.Clear();
        results.AddRange(Formula.Results);
        for (var i = 0; i < results.Count; i++)
        {
            buttonManagers[i].buttonText = results[i].ToString();
            buttonManagers[i].UpdateUI();
        }
    }

    public void Calculate()
    {
        Formula.Calculate();
    }

    public void SetGraphResults()
    {
        graph = GetComponent<GraphChart>();
        if (graph != null)
        {
            graph.DataSource.StartBatch(); // start a new update batch 


            for (var i = 0; i < results.Count; i++)
                //add 30 random points , each with a category and an x,y value 
                graph.DataSource.AddPointToCategory("Period" + " " + i, results[i], 0);

            graph.DataSource.EndBatch(); // end the update batch . this call will render the graph 
        }
    }
}