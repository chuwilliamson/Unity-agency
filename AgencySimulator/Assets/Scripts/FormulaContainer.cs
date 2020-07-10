using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FormulaContainer")]
public class FormulaContainer : ScriptableObject
{
    public List<GameFormula> Formulas;

    public void Calculate()
    {
        Formulas.ForEach(f => f.Calculate());
    }
}