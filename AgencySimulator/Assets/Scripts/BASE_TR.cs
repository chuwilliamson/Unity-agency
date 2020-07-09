using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Formulas/BASE_TR")]
public class BASE_TR : GameFormula
{
    public override void Init()
    {
        numConstants = 12;
    }

    public override void Calculate()
    {
        Results = new List<float>();


        var C12 = KFloats[11];
        var C11 = KFloats[10];
        var C10 = KFloats[9];
        var C9 = KFloats[8];
        var C8 = KFloats[7];
        var C7 = KFloats[6];
        var C6 = KFloats[5];
        var C5 = KFloats[4];
        var C4 = KFloats[3];
        var C3 = KFloats[2];
        var C2 = KFloats[1];
        var C1 = KFloats[0];

        var PTR = input;

        for (var PD = 1; PD <= numYears; PD++)
        {
            var yearResult = 0.0f;

            if (PTR >= 35)
                yearResult = Mathf.Pow(C1 * (Mathf.Pow(PTR - 34, C2) * Mathf.Pow(PD, C3)), C4);


            else if (PTR < 35 && PTR >= 20)
                yearResult = Mathf.Pow(C5 * (Mathf.Pow(PTR - 19, C6) * Mathf.Pow(PD, C7)), C8);


            else if (PTR < 20)
                yearResult = 0 - Mathf.Pow(C9 * (Mathf.Pow(20 - PTR, C10) * Mathf.Pow(PD, C11)), C12);


            Results.Add(Mathf.Clamp(yearResult, minClamp,maxClamp));
            base.Calculate();
        }
    }
}