using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Formulas/KPI_S")]
public class KPI_S : GameFormula
{
    public GameFormula B_KPI;
    public GameFormula CO_BASE;
    public GameFormula CS_BASE;
    public GameFormula P_KPI;
    public GameFormula SM_BASE;
    public GameFormula TR_BASE;

    public override void Init()
    {
        numConstants = 6;
    }

    public override void Calculate()
    {
        Results = new List<float>();


        var C6 = KFloats[5];
        var C5 = KFloats[4];
        var C4 = KFloats[3];
        var C3 = KFloats[2];
        var C2 = KFloats[1];
        var C1 = KFloats[0];


        for (var PD = 1; PD <= numYears; PD++)
        {
            var SM = SM_BASE.input;
            var CO = CO_BASE.input;
            var TR = TR_BASE.input;
            var CS = CS_BASE.input;
            var B = B_KPI.input;
            var P = P_KPI.input;

            var yearResult = 0.0f;

            yearResult = 50 + C1 * SM + C2 * CO + C3 * TR + C4 * CS + C5 * B + C6 * P;


            Results.Add(Mathf.Clamp(yearResult, minClamp,maxClamp));
        }
    }
}