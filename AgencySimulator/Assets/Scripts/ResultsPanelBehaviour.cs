using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using ChartAndGraph;
using Michsky.UI.ModernUIPack;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ResultsPanelBehaviour : MonoBehaviour
{
    public GameFormula Formula;
    public List<float> results;

    [FormerlySerializedAs("labels")] public List<ButtonManager> buttonManagers;
    public TMP_Text Tip;

    private void Start()
    {
        Tip.text = Formula.name;
        buttonManagers = new List<ButtonManager>(GetComponentsInChildren<ButtonManager>());
        results = new List<float>();
        SetResults();
    }

    public void SetResults()
    {
        results.Clear();
        results.AddRange(Formula.Results);
    }

    public void Populate()
    {
        SetResults();

        for (int i = 0; i < results.Count; i++)
        {
            buttonManagers[i].buttonText = results[i].ToString(CultureInfo.CurrentCulture);
            buttonManagers[i].UpdateUI();
        }
    }

    public GraphChart graph;
    void SetGraphResults()
    {
        graph = GetComponent<GraphChart>();
        if (graph != null)
        {
            graph.DataSource.StartBatch(); // start a new update batch 
     

            for (var i = 0; i < results.Count; i++)
            {
//add 30 random points , each with a category and an x,y value 
                graph.DataSource.AddPointToCategory("Period" + " " + i.ToString(),  results[i], 0);
            }

            graph.DataSource.EndBatch(); // end the update batch . this call will render the graph 
        }
    }
}