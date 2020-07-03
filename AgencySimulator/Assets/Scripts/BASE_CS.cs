using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Formulas/BASE_CS")]
public class BASE_CS : GameFormula
{
    public GameFormula PTR_BASE;

    public override void Init()
    {
        numConstants = 8;
    }

    public override void Calculate()
    {
        Results = new List<float>();


        var C8 = KFloats[7];
        var C7 = KFloats[6];
        var C6 = KFloats[5];
        var C5 = KFloats[4];
        var C4 = KFloats[3];
        var C3 = KFloats[2];
        var C2 = KFloats[1];
        var C1 = KFloats[0];

        var PCS = input;

        //IS this input a reference to an existing TR Calculation?
        //or
        //IS this an additional input slider


        for (var PD = 0; PD < numYears; PD++)
        {
            var PTR = PTR_BASE.Results[PD];
            var yearResult = 0.0f;

            if (PCS >= 25 && PCS > 0.5 * PTR)
                yearResult = C6 * (PCS - C7) * C1 * (1 / Mathf.Pow(1 + Mathf.Exp(-C2 * PD), C3));


            else if (PCS >= 25 && PCS <= 0.5 * PTR)
                yearResult = C5 * C6 * (PCS - C7) * C1 * (1 / Mathf.Pow(1 + Mathf.Exp(-C2 * PD), C3));


            else if (PCS < 25 && PCS > 0.5 * PTR)
                yearResult = 0 - (C8 - PCS) * C4 * (1 / Mathf.Pow(1 + Mathf.Exp(-C2 * PD), C3));


            else if (PCS < 25 && PCS <= 0.5 * PTR)
                yearResult = 0 - (C8 - PCS) * C4 * (2 - C5) * (1 / Mathf.Pow(1 + Mathf.Exp(-C2 * PD), C3));


            Results.Add(yearResult);
        }
    }
}