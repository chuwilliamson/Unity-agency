using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FormulaContainer")]
public class FormulaContainer : ScriptableObject
{
    public List<GameFormula> Formulas;
    public GameFormula this[int index] => Formulas[index];
    
    public void Calculate()
    {
        Formulas.ForEach(f => f.Calculate());
    }
}