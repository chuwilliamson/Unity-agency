using System.Collections.Generic;

public class KPI_P : GameFormula
{
    public override void Calculate()
    {
        Results = new List<float>();


        var C4 = KFloats[3];
        var C3 = KFloats[2];
        var C2 = KFloats[1];
        var C1 = KFloats[0];

        var TR = 1;
        var CS = 1;
        var B = 1;
        var U = 1;

        for (var PD = 0; PD < numYears; PD++)
        {
            var yearResult = 0.0f;

            yearResult = 50 + C1 * TR + C2 * CS + C3 * B + C4 * U;


            Results.Add(yearResult);
        }
    }
}