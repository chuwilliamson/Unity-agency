using System;
using UnityEngine.Events;

namespace ChuTools.Scripts
{
    [Serializable]
    public class GameEventArgsResponse : UnityEvent<object[]>
    {
    }
    
    [System.Serializable]
    public class GameEventResponse: UnityEvent{}
}