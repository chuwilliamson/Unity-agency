using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Formulas/KPI_U")]
public class KPI_U : GameFormula
{
    public GameFormula B_KPI;
    public GameFormula CS_BASE;

    public GameFormula TR_BASE;

    public override void Init()
    {
        numConstants = 3;
    }

    public override void Calculate()
    {
        Results = new List<float>();


        var C3 = KFloats[2];
        var C2 = KFloats[1];
        var C1 = KFloats[0];


        for (var PD = 1; PD <= numYears; PD++)
        {
            var TR = TR_BASE.Results[PD];
            var CS = CS_BASE.Results[PD];
            var B = B_KPI.Results[PD];
            var yearResult = 0.0f;

            yearResult = 50 + C1 * TR + C2 * CS + C3 * B;


            Results.Add(yearResult);
        }
    }
}