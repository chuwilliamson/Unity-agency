using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Formulas/KPI_B")]
public class KPI_B : GameFormula
{
    public GameFormula A_KPI;
    public GameFormula CN_BASE;
    public GameFormula CO_BASE;

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
            var CO = CO_BASE.input;
            var CN = CN_BASE.input;
            var A = A_KPI.input;
            var yearResult = 0.0f;

            yearResult = 50 + C1 * CO + C2 * CN + C3 * A;


            Results.Add(Mathf.Clamp(yearResult, minClamp, maxClamp));
            base.Calculate();
        }
    }
}