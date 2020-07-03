using System.Collections.Generic;
using UnityEngine;

public class BASE_SM
{
    public int numYears = 10;

    [Range(-100, 100)] public double input;
    public List<float> KFloats;

    [SerializeField] public List<double> Results;

    [TextArea(10, 50)] public string description;

    public void Calculate()
    {
        Results = new List<double>();



        var C4 = KFloats[3];
        var C3 = KFloats[2];
        var C2 = KFloats[1];
        var C1 = KFloats[0];

        var PSM = input;
		
        for (var PD = 0; PD < numYears; PD++)
        {
            double yearResult = 0.0d;
            
            if (PSM >= 10)
                yearResult = ((PSM - C1) / C2) * (0.1412198912 * Mathf.Pow(PD,3) - 2.537878788 * Mathf.Pow(PD,2) + 16.56449106 * PD - 2.559440559);
			

            else 
                yearResult = ((PSM - C3) / C4) * (0.1412198912 * Mathf.Pow(PD,3) - 2.537878788 * Mathf.Pow(PD,2) + 16.56449106 * PD - 2.559440559);
			

  
  
            Results.Add(yearResult);
        }
    }
}