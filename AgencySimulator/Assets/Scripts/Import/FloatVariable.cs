using UnityEngine;
using UnityEngine.Events;

namespace ChuTools.Scripts
{
    [CreateAssetMenu(menuName = "ScriptableObjects/Variables/FloatVariable")]
    public class FloatVariable : ScriptableObject
    {
        public UnityEvent<float> OnPropertyChanged;
        public float Value;

        public float SetValue
        {
            set
            {
                Value = value;
                if (OnPropertyChanged != null)
                    OnPropertyChanged.Invoke(Value);
            }
            get => Value;
        }
    }
}