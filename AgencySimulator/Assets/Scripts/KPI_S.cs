using System.Collections.Generic;

public class KPI_S : GameFormula
{
    public override void Calculate()
    {
        Results = new List<float>();


        var C6 = KFloats[5];
        var C5 = KFloats[4];
        var C4 = KFloats[3];
        var C3 = KFloats[2];
        var C2 = KFloats[1];
        var C1 = KFloats[0];

        var SM = 1;
        var CO = 1;
        var TR = 1;
        var CS = 1;
        var B = 1;
        var P = 1;

        for (var PD = 0; PD < numYears; PD++)
        {
            var yearResult = 0.0f;

            yearResult = 50 + C1 * SM + C2 * CO + C3 * TR + C4 * CS + C5 * B + C6 * P;


            Results.Add(yearResult);
        }
    }
}