using System.Collections.Generic;
using UnityEngine;

namespace ChuTools.Scripts
{
    public class GameEventArgsListener : MonoBehaviour 
    {
        public GameEventListener GameEvent;
        public List<GameEventArgsResponse> Responses;

        public void OnEventRaised(object[] args)
        {
            Responses.ForEach(r => r.Invoke(args));
        }

        public void Subscribe()
        {
            GameEvent.Subscribe();
        }

        public void Unsubscribe()
        {
            GameEvent.Unsubscribe();
        }

        public virtual void OnEnable()
        {
            Subscribe();
        }

        public virtual void OnDisable()
        {
            Unsubscribe();
        }
    }
}