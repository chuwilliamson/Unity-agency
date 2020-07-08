using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Formulas/KPI_P")]
public class KPI_P : GameFormula
{
    public GameFormula B_KPI;
    public GameFormula CS_BASE;

    public GameFormula TR_BASE;
    public GameFormula U_KPI;

    public override void Init()
    {
        numConstants = 4;
    }

    public override void Calculate()
    {
        Results = new List<float>();


        var C4 = KFloats[3];
        var C3 = KFloats[2];
        var C2 = KFloats[1];
        var C1 = KFloats[0];


        for (var PD = 1; PD <= numYears; PD++)
        {
            var TR = TR_BASE.input;
            var CS = CS_BASE.input;
            var B = B_KPI.input;
            var U = U_KPI.input;


            var yearResult = 0.0f;

            yearResult = 50 + C1 * TR + C2 * CS + C3 * B + C4 * U;


            Results.Add(Mathf.Clamp(yearResult, minClamp, maxClamp));
        }
    }
}