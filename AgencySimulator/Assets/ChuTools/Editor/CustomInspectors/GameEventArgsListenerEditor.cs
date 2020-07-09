using System.Reflection;
using ChuTools.Scripts;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace ChuTools.CustomInspectors
{
    [CustomEditor(typeof(GameEventArgsListener))]
    public class GameEventArgsListenerEditor : UnityEditor.Editor
    {
        public Object GameEventRef;
        public ReorderableList List;
        public FieldInfo Field => target.GetType().GetField("GameEvent");
        public static MethodInfo Raisemethod => typeof(GameEventArgs).GetMethod("Raise"); //some function

        protected virtual void OnEnable()
        {
            List =
                new ReorderableList(serializedObject, serializedObject.FindProperty("Responses"), true, true, true,
                    true)
                {
                    drawElementCallback = DrawElementCallback,
                    elementHeightCallback = ElementHeightCallback,
                    drawHeaderCallback = DrawHeaderCallback
                };
        }

        private void DrawHeaderCallback(Rect rect)
        {
            EditorGUI.LabelField(rect, "Callbacks");
        }

        private void DrawElementCallback(Rect rect, int index, bool isactive, bool isfocused)
        {
            var element = List.serializedProperty.GetArrayElementAtIndex(index);
            EditorGUI.PropertyField(new Rect(rect.x, rect.y, rect.width, EditorGUIUtility.singleLineHeight),
                element,
                GUIContent.none);
        }

        private float ElementHeightCallback(int index)
        {
            var element = List.serializedProperty.GetArrayElementAtIndex(index);
            var elementHeight = EditorGUI.GetPropertyHeight(element);
            // optional, depending on the situation in question and the defaults you like
            // you may want to subtract the margin out in the drawElementCallback before drawing
            var margin = EditorGUIUtility.standardVerticalSpacing;
            return elementHeight + margin;
        }

        public override void OnInspectorGUI()
        {
            EditorGUILayout.Space();
            EditorGUI.BeginChangeCheck();
            EditorGUILayout.Space();

            var prop = serializedObject.FindProperty("GameEvent");
            
            EditorGUILayout.PropertyField(prop);
            
            List.DoLayoutList();

            serializedObject.ApplyModifiedProperties();
            serializedObject.Update();
        }

        public static void Label(string value)
        {
            EditorGUILayout.LabelField(value);
        }
    }
}