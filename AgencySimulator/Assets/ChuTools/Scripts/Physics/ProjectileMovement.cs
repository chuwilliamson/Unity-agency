using UnityEditor;
using UnityEngine;

namespace ChuTools.Scripts.Physics
{
    [CreateAssetMenu(menuName = "Scriptables/Moveables")]
    public class ProjectileMovement : ScriptableObject
    {
        public Vector2 current_Position;
        public Vector2 current_Velocity;
        public Vector2 initial_Position;
        public Vector2 initial_Velocity;
    }

    [CustomEditor(typeof(ProjectileMovement))]
    public class ProjectileMovementEditor : Editor
    {
        private ProjectileMovement _mt;
        private float _time;
        private GUIContent _xFormula, _yFormula;

        private GUIStyle gs;
        public Vector2 Result;

        private void OnEnable()
        {
            _mt = target as ProjectileMovement;
            _xFormula = new GUIContent("x = x0 + t * v0");
            _yFormula = new GUIContent("y = y0 + 1 / (2 * g * t^2 + t* u0)");
            gs = new GUIStyle
            {
                normal = new GUIStyleState
                {
                    textColor = Color.white
                },
                fontSize = 25
            };
        }

        public void Header()
        {
            GUILayout.Label("Equations", gs);
            var rect = GUILayoutUtility.GetLastRect();
            GUI.enabled = false;
            EditorGUILayout.RectField(rect);
            GUI.enabled = true;
            rect.Set(rect.x, rect.y, Screen.width - 15, rect.height + 15);
            GUILayout.BeginArea(rect);
            GUI.Box(rect, "Projectile Motion");
            GUILayout.EndArea();
            DrawSpacer();
        }

        public static void DrawSpacer()
        {
            var rect = GUILayoutUtility.GetLastRect();
            Handles.DrawLine(new Vector2(rect.x, rect.yMax), new Vector2(rect.xMax, rect.yMax));
        }

        public void Section_1()
        {
            EditorGUILayout.LabelField(_xFormula);
            EditorGUILayout.LabelField(_yFormula);
            EditorGUI.BeginChangeCheck();
            _mt.initial_Position = EditorGUILayout.Vector2Field("Start Position", _mt.initial_Position);
            _mt.initial_Velocity = EditorGUILayout.Vector2Field("Start Velocity", _mt.initial_Velocity);

            _time = EditorGUILayout.IntSlider("Time", (int) _time, 1, 100);
            var x0 = _mt.initial_Position.x;
            var y0 = _mt.initial_Position.y;
            var v0 = _mt.initial_Velocity.x;
            var u0 = _mt.initial_Velocity.y;
            var g = 9.8f;
            var x = _time * v0;
            var y = 1 / (2 * g * (_time * _time) + _time * u0);

            if (EditorGUI.EndChangeCheck() || GUILayout.Button("Calculate"))
                Result = new Vector2(x, Mathf.Clamp(y, 0, y));

            GUI.enabled = false;
            EditorGUILayout.Vector2Field("result", Result);
            GUI.enabled = true;

            DrawSpacer();
        }

        public override void OnInspectorGUI()
        {
            Header();
            Section_1();
        }
    }
}