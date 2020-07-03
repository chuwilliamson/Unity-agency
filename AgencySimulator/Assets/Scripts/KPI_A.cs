using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Formulas/KPI_A")]
public class KPI_A : GameFormula
{
    public GameFormula CN_BASE;
    public GameFormula CO_BASE;

    public GameFormula SM_BASE;

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


        for (var PD = 0; PD < numYears; PD++)
        {
            var SM = SM_BASE.Results[PD];
            var CO = CO_BASE.Results[PD];
            var CN = CN_BASE.Results[PD];

            var yearResult = 0.0f;

            yearResult = 50 + C1 * SM + C2 * CO + C3 * CN;


            Results.Add(yearResult);
        }
    }
}