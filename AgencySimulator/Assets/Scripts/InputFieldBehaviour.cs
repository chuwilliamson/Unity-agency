using System;
using ChuTools.Attributes;
using ChuTools.Scripts;
using Michsky.UI.ModernUIPack;
using TMPro;
using UnityEngine;

public class InputFieldBehaviour : MonoBehaviour
{
    [ScriptVariableAttribute(typeof(GameEventArgs))]
    public GameEventArgs OnEndEditEvent;

    [SerializeField]
    private TMP_InputField _inputField;
    private void Start()
    {
        if (_inputField == null)
        {
            _inputField = GetComponent<TMP_InputField>();
        }
            
                
        _inputField.onEndEdit.AddListener((s)=>OnEndEditEvent.Raise(new object[]{this, s}));
    }
}