using System.Collections.Generic;
using UnityEngine;

public class GameFormula : ScriptableObject
{
    [TextArea(10, 50)] public string description;
    [Range(0, 100)] public float input;
    public List<float> KFloats;
    public int numYears = 10;

    public List<float> Results;

    public virtual void Calculate()
    {
    }
}