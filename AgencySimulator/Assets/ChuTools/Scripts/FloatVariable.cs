using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace ChuTools.Scripts
{
    [CreateAssetMenu(menuName = "FloatVariable")]
    public class FloatVariable : ScriptableObject
    {
        public PropertyChangedEvent OnPropertyChanged;
        [SerializeField]
        [FormerlySerializedAs("Value")] private float _value;

        private void OnEnable()
        {
            if(OnPropertyChanged == null)
                OnPropertyChanged= new PropertyChangedEvent();
        }

        public float Value
        {
            set
            {
                _value = value;
                if (OnPropertyChanged != null)
                    OnPropertyChanged.Invoke(_value);
            }
            get => _value;
        }
    }
}