using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Formulas/KPI_B")]
public class KPI_B : GameFormula
{
    public override void Calculate()
    {
        Results = new List<float>();


        var C3 = KFloats[2];
        var C2 = KFloats[1];
        var C1 = KFloats[0];

        var CO = 1;
        var CN = 1;
        var A = 1;

        for (var PD = 0; PD < numYears; PD++)
        {
            var yearResult = 0.0f;

            yearResult = 50 + C1 * CO + C2 * CN + C3 * A;


            Results.Add(yearResult);
        }
    }
}