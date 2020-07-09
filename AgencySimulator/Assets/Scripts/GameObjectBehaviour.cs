using System;
using ChuTools.Scripts;
using UnityEngine;
using UnityEngine.Events;


public class GameObjectBehaviour : MonoBehaviour
{
    public GameEventArgsResponse OnStart;

    private void Start()
    {
        OnStart.Invoke(new object[]{this});
    }
}
