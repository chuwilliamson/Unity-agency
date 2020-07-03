﻿using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Formulas")]
public class GameFormula : ScriptableObject
{
    public int numYears = 10;
    [Range(0, 100)] public float input;
    public List<float> KFloats;

    public List<float> Results;

    [TextArea(10, 50)] public string description;

    public void Calculate()
    {
        Results = new List<float>();


        var C5 = KFloats[4];
        var C4 = KFloats[3];
        var C3 = KFloats[2];
        var C2 = KFloats[1];
        var C1 = KFloats[0];

        var PCN = input;

        for (var PD = 0; PD < numYears; PD++)
        {
            var yearResult = 0.0f;
            if (input < 15)
                yearResult = -Mathf.Pow(PD, (15 - input) * C4 );
               
            else

            {
/*              C5 * (PCN - 14) /
                (
                    ( 1 - C1 * 
                        ( 
                            ( 1 / 
                                 ( 
                                    (PD / C2) * C3 * SQRT(2 * PI)
                                 )
                            )  
                (exp(-(((ln((PD/C2)))^2)/ (2*(C3^2))))))))
*/
                yearResult = C5 * (PCN - 14) /
                             (1 - C1 * (1 / (PD / C2 * C3 * Mathf.Sqrt(2 * Mathf.PI)) *
                                        Mathf.Exp(-(Mathf.Pow(Mathf.Log(PD / C2), 2)
                                                    / (2 * Mathf.Pow(C3, 2))))));
            }

            Results.Add(yearResult);
        }
    }
}
 