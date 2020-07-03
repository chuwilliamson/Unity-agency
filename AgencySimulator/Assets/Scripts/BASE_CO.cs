using System.Collections.Generic;
using UnityEngine;

public class BASE_CO
{
    public int numYears = 10;

    [Range(0, 100)] public float input;
    public List<float> KFloats;

    [SerializeField] public List<float> Results;

    [TextArea(10, 50)] public string description;

    public void Calculate()
    {
        Results = new List<float>();


        var C6 = KFloats[5];
        var C5 = KFloats[4];
        var C4 = KFloats[3];
        var C3 = KFloats[2];
        var C2 = KFloats[1];
        var C1 = KFloats[0];

        var PCO = input;

        for (var PD = 0; PD < numYears; PD++)
        {
            var yearResult = 0.0f;
            
            if (PCO >= 40 && PD < 6)
                yearResult = Mathf.Sin(Mathf.PI * PD / 10) * 10;

            else if (PCO >= 40 && PD >= 6)
                yearResult = Mathf.Sin(Mathf.PI * (PD + (PCO / (PCO + C6)) * (PD - 5)) / 10) * 100;
            
            else if (PCO < 40 && PCO >= 20)
                yearResult = C2 * PCO * PD / 10;

            else if (PCO < 10)
                yearResult = -C4 * (10 - PCO) * Mathf.Pow(PD, C5);

            Results.Add(yearResult);
        }
    }
}