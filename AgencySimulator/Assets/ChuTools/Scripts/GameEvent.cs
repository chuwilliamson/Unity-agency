using System.Collections.Generic;
using UnityEngine;

namespace ChuTools.Scripts
{
    [CreateAssetMenu]
    public class GameEvent : ScriptableObject 
    {
        public List<GameEventListener> Listeners = new List<GameEventListener>();

        public void Raise(params object[] args)
        {
            for (var i = Listeners.Count - 1; i >= 0; i--)
                Listeners[i].OnEventRaised(args);
        }

        public void RegisterListener(GameEventListener listener)
        {
            if (Listeners.Contains(listener))
            {
                Debug.LogError("listener is already in list");
                return;
            }

            Listeners.Add(listener);
        }

        public void UnregisterListener(GameEventListener listener)
        {
            if (!Listeners.Contains(listener))
            {
                Debug.LogError("listener is not in list");
                return;
            }

            Listeners.Remove(listener);
        }
    }
}