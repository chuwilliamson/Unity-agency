using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace ChuTools.Extensions
{
    public static class Extensions
    {
        public static Rect MoveDown(this Rect rect, float amount)
        {
            var arect = rect;
            arect.position = new Vector2(rect.x, rect.y + amount);
            return arect;
        }
        public static Vector3 ClampToScreen(this Vector3 v3)
        {
            var viewportPosition = Camera.main.WorldToViewportPoint(v3);
             
            if (viewportPosition.x > 1 || viewportPosition.x < 0)
                v3.x = 0;

            if (viewportPosition.y > 1 || viewportPosition.y < 0)
                v3.y = 0;

            return v3;
        }
        public static void SetX(this Vector3 v3, float value)
        {
            v3 = new Vector3(value, v3.y, v3.z);
        }

        public static void SetY(this Vector3 v3, float value)
        {
            v3 = new Vector3(v3.x, value, v3.z);
        }
        public static string ReplaceWithStringBuilder(this string value, IEnumerable<Tuple<string, string>> toReplace)
        {
            var result = new StringBuilder(value);
            foreach (var item in toReplace)
            {
                result.Replace(item.Item1, item.Item2);
            }
            return result.ToString();
        }
        public static void SetZ(this Vector3 v3, float value)
        {
            v3 = new Vector3(v3.x, v3.y, value);
        }

        public static void SetX(this Vector2 v2, float value)
        {
            v2 = new Vector3(value, v2.y);
        }

        public static void SetY(this Vector2 v2, float value)
        {
            v2 = new Vector3(v2.x, value);
        }
    }
}