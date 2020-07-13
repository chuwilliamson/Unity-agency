using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

[CreateAssetMenu(menuName = "FormulaContainer")]
public class FormulaContainer : ScriptableObject
{
    public List<GameFormula> Formulas;
    public GameFormula this[int index] => Formulas[index];
    [SerializeField]
    private Dictionary<string, GameFormula> _formulaDictionary;

    private void OnEnable()
    {
        _formulaDictionary = new Dictionary<string, GameFormula>();

        if (Formulas != null)
        {
            foreach (var formula in Formulas)
            {
                _formulaDictionary.Add(formula.name, formula);
            }
        }
    }

    public void Calculate()
    {
        Formulas.ForEach(
            f => { f.Calculate(); });
    }


    public List<float> Calculate(string formulaName, float input)
    {
        _formulaDictionary.TryGetValue(formulaName, out var gameFormula);
        if (gameFormula != null)
        {
            gameFormula.input = input;
            gameFormula.Calculate();
        }

        return (gameFormula != null) ? gameFormula.Results : new List<float>();
    }
}