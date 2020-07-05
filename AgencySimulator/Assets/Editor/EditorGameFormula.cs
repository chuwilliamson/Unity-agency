using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(GameFormula), true ) ]
    public class GameFormulaEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();
            var myTarget = (GameFormula) target;
            if (GUILayout.Button("Calculate")) myTarget.Calculate();
        }
    }
}