using ChartAndGraph;
using ChuTools.Attributes;
using UnityEngine;

public class SetGraphDataBehaviour : MonoBehaviour
{
    public GraphChart graph;

    [ScriptVariable(typeof(GameFormula))]
    public GameFormula target;

    public void SetResults()
    {
        if (graph != null)
        {
            graph.DataSource.StartBatch(); // start a new update batch 

            var results = target.Results;
            for (var i = 0; i < results.Count; i++)
                //add 30 random points , each with a category and an x,y value 

                graph.DataSource.AddPointToCategory("Player 1", i * 5, results[i]);

            graph.DataSource.EndBatch(); // end the update batch . this call will render the graph 
        }
    }
}