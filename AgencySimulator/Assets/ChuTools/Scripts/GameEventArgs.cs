using System.Collections.Generic;
using UnityEngine;

namespace ChuTools.Scripts
{
    [CreateAssetMenu]
    public class GameEventArgs : ScriptableObject 
    {
        public List<GameEventArgsListener > Listeners = new List<GameEventArgsListener >();

        public void Raise(params object[] args)
        {
            for (var i = Listeners.Count - 1; i >= 0; i--)
                Listeners[i].OnEventRaised(args);
        }

        public void RegisterListener(GameEventArgsListener listener)
        {
            if (Listeners.Contains(listener))
            {
                Debug.LogError("listener is already in list");
                return;
            }

            Listeners.Add(listener);
        }

        public void UnregisterListener(GameEventArgsListener  listener)
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