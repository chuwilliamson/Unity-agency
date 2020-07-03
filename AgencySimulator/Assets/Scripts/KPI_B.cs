using System.Collections.Generic;
using UnityEngine;

public class KPI_B
{
    public int numYears = 10;

    [Range(0, 100)] public float input;
    public List<float> KFloats;

    [SerializeField] public List<float> Results;

    [TextArea(10, 50)] public string description;

    public void Calculate()
    {
        Results = new List<float>();



        var C3 = KFloats[2];
        var C2 = KFloats[1];
        var C1 = KFloats[0];

        var CO = 1;
		var CN = 1;
		var A = 1;
		
        for (var PD = 0; PD < numYears; PD++)
        {
            var yearResult = 0.0f;
            
            yearResult = 50 + C1 * CO + C2 * CN + C3 * A;
			

            
  
            Results.Add(yearResult);
        }
    }
}