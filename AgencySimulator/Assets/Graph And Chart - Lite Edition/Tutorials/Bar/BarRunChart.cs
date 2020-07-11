using System;
using System.Collections.Generic;
using ChartAndGraph;
using UnityEngine;
using Random = UnityEngine.Random;

public class BarRunChart : MonoBehaviour
{
    private readonly List<RunChartEntry> mEntries = new List<RunChartEntry>();
    public Material SourceMaterial;

    public float switchTime = 0.1f;

    private float switchTimeCounter;

    // Use this for initialization
    private void Start()
    {
        switchTimeCounter = switchTime;


        var bar = GetComponent<BarChart>();
        bar.TransitionTimeBetaFeature = switchTime;
        bar.DataSource.ClearCategories();
        bar.DataSource.ClearGroups();
        bar.DataSource.AddGroup("Default");

        // generate a random run chart
        for (var i = 0; i < 10; i++)
        {
            var categoryName = "Item " + i;
            mEntries.Add(new RunChartEntry(categoryName, Random.value * 10));
            var mat = new Material(SourceMaterial);
            mat.color = new Color(
                Random.Range(0f, 1f),
                Random.Range(0f, 1f),
                Random.Range(0f, 1f)
            );
            bar.DataSource.AddCategory(categoryName, mat);
        }
    }

    private void AddValuesToCategories()
    {
        for (var i = 0; i < mEntries.Count; i++) mEntries[i].Amount += Random.Range(-0.3f, 0.3f);
    }

    // Update is called once per frame
    private void Update()
    {
        // changes are timed 
        switchTimeCounter -= Time.deltaTime;
        if (switchTimeCounter < 0f)
        {
            switchTimeCounter = switchTime;
            var bar = GetComponent<BarChart>();
            //position the categories according to the currently displayed values
            for (var i = 0; i < mEntries.Count; i++) bar.DataSource.MoveCategory(mEntries[i].Name, i);
            // add the changes
            AddValuesToCategories();
            // sort the changes
            mEntries.Sort((x, y) => Math.Sign(x.Amount - y.Amount));
            // animate the transition to the next values
            for (var i = 0; i < mEntries.Count; i++)
                bar.DataSource.SlideValue(mEntries[i].Name, "Default", mEntries[i].Amount, switchTime);
        }
    }

    private class RunChartEntry
    {
        public double Amount;
        public readonly string Name;

        public RunChartEntry(string name, double amount)
        {
            Name = name;
            Amount = amount;
        }
    }
}