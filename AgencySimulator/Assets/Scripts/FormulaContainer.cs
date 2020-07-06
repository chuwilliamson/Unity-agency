using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "FormulaContainer")]
public class FormulaContainer : ScriptableObject
{
  public List<float> user_game_inputs;
  public List<float> game_formula_inputs;
   
  public List<GameFormula> Formulas;

  public void Calculate()
  {
    Formulas.ForEach(f=> f.Calculate());
  } 
}
