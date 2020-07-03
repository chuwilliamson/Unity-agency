using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
 

[CustomEditor(typeof(GameFormula))]
public class GameFormulaEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        var myTarget = (GameFormula) target;
        if (GUILayout.Button("Calculate")) myTarget.Calculate();
    }
}