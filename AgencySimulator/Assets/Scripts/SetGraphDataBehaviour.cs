using ChartAndGraph;
using ChuTools.Attributes;
using UnityEngine;

public class SetGraphDataBehaviour : MonoBehaviour
{
    public BarChart barChart;
    [SerializeField]
    private Material playerMaterial;
    [SerializeField]
    private Material chartMaterial;
    [ScriptVariable(typeof(GameFormula))]
    public GameFormula target;
    void Start () 
    {
        var pcount = 1;
        playerMaterial = Instantiate(playerMaterial);
        chartMaterial = Instantiate(chartMaterial);
        for (int i = 0; i < pcount; i++)
        {
            barChart.DataSource.AddCategory("Player"+i.ToString(),playerMaterial );    
        }

        for (int i = 0; i < target.Results.Count; i++)
        {
            var pname = string.Format("Period{0}", i);
            Debug.Log("adding category for " +pname);
            barChart.DataSource.AddGroup(pname);  
            
        }
        
        barChart.DataSource.SetValue("Player0", "Period0",target.Results[0]);
      
    }  
}