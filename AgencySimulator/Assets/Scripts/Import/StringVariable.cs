﻿using UnityEngine;

namespace ChuTools.Scripts
{
    [CreateAssetMenu]
    public class StringVariable : ScriptableObject
    {
        [SerializeField] private string value;

        public string Value
        {
            get => value;
            set => this.value = value;
        }
    }
}