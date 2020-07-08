using System.Collections.Generic;
using UnityEngine;

public abstract class GameFormula : ScriptableObject
{
    [TextArea(10, 50)]
    public string description;

    [Range(0, 100)]
    public float input;

    public List<float> KFloats;
    public float maxClamp;

    public float minClamp;
    public int numConstants;
    public int numYears = 10;
    public List<float> Results;

    public void ChangeInput(float value)
    {
        input = value;
    }

    public void OnEnable()
    {
        Init();
        if (KFloats == null)
            KFloats = new List<float>();

        if (KFloats.Count <= 0)
            for (var i = 0; i < numConstants; i++)
                KFloats.Add(20);
    }

    public virtual void Calculate()
    {
    }

    public virtual void Init()
    {
    }
}