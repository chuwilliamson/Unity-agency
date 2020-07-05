using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Formulas/BASE_SM")]
public class BASE_SM : GameFormula
{
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

        var PSM = input;

        for (var PD = 1; PD <= numYears; PD++)
        {
            var yearResult = 0.0d;

            if (PSM >= 10)
                yearResult = (PSM - C1) / C2 * (0.1412198912 * Mathf.Pow(PD, 3) - 2.537878788 * Mathf.Pow(PD, 2) +
                    16.56449106 * PD - 2.559440559);


            else
                yearResult = (PSM - C3) / C4 * (0.1412198912 * Mathf.Pow(PD, 3) - 2.537878788 * Mathf.Pow(PD, 2) +
                    16.56449106 * PD - 2.559440559);


            Results.Add((float) yearResult);
        }
    }
}