using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(FormulaContainer))]
public class FormulaContainerEditor : UnityEditor.Editor
{
    
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        var mt = target as FormulaContainer;
        EditorGUILayout.LabelField("Formulas");
        var formulas = mt.Formulas;
        
        foreach(var f in formulas)
        {

            EditorGUILayout.Separator();
            EditorGUILayout.LabelField(f.name);
            EditorGUILayout.LabelField("input: "  + f.input.ToString());
            EditorGUILayout.Space();
            foreach (var result in f.Results)
            {
                              EditorGUILayout.LabelField(result.ToString());
            }
            EditorGUILayout.Separator();
        }

    }
}