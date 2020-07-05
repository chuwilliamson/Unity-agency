using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(FormulaContainer))]
    public class EditorFormulaContainer : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            var mt = target as FormulaContainer;
            base.OnInspectorGUI();
            if (GUILayout.Button("Calculate"))
            {
                if (mt != null) mt.Calculate();
            }
 
        }
    }
}