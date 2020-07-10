using ChuTools.Attributes;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class FormulaInputFieldBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private TMP_InputField _inputField;

    [ScriptVariable(typeof(GameFormula))]
    public GameFormula Formula;
 
    public int Index { get; set; } = 0;

    // Update is called once per frame
    private void Start()
    {
        if (_inputField == null)
            _inputField = GetComponent<TMP_InputField>();

        _inputField.onSubmit.AddListener(onEndEdit);
    }

    public void Init(int index, GameFormula formula)
    {
        Index = index;
        Formula = formula;
        _inputField.text = formula.KFloats[index].ToString();
        _inputField.ForceLabelUpdate();
    }
    
    private void onEndEdit(string arg0)
    {
        var value = float.Parse(arg0);
        Formula.KFloats[Index] = value;
        Formula.Calculate();
        
    }
}