using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "FormulaContainer")]
public class FormulaContainer : ScriptableObject
{

  public List<GameFormula> Formulas;

  public void Calculate()
  {
    Formulas.ForEach(f=> f.Calculate());
  }
 
 
}
