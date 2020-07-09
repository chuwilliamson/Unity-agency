using UnityEngine;
using UnityEngine.Serialization;

namespace ChuTools.Scripts
{
    [CreateAssetMenu(menuName = "FloatVariable")]
    public class FloatVariable : ScriptableObject
    {
        [SerializeField]
        [FormerlySerializedAs("Value")]
        private float _value;

        public PropertyChangedEvent OnPropertyChanged;

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

        private void OnEnable()
        {
            if (OnPropertyChanged == null)
                OnPropertyChanged = new PropertyChangedEvent();
        }
    }
}