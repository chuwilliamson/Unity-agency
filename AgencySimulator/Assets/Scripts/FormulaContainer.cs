using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "FormulaContainer")]
public class FormulaContainer : ScriptableObject
{
    public List<GameFormula> Formulas;
    public List<float> game_formula_inputs;
    public List<float> user_game_inputs;

    public void Calculate()
    {
        Formulas.ForEach(f => f.Calculate());
    }
}