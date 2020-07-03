using System.Collections.Generic;
using UnityEngine;

public class KPI_U
{
    [TextArea(10, 50)] public string description;

    [Range(0, 100)] public float input;
    public List<float> KFloats;
    public int numYears = 10;

    [SerializeField] public List<float> Results;

    public void Calculate()
    {
        Results = new List<float>();


        var C3 = KFloats[2];
        var C2 = KFloats[1];
        var C1 = KFloats[0];

        var TR = 1;
        var CS = 1;
        var B = 1;

        for (var PD = 0; PD < numYears; PD++)
        {
            var yearResult = 0.0f;

            yearResult = 50 + C1 * TR + C2 * CS + C3 * B;


            Results.Add(yearResult);
        }
    }
}