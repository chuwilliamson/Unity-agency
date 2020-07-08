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

    public UnityEvent OnEndEdit;

    public TMP_Text titleText;
    public int Index { get; set; } = 0;

    // Update is called once per frame
    private void Start()
    {
        if (_inputField == null)
            _inputField = GetComponent<TMP_InputField>();

        _inputField.onEndEdit.AddListener(onEndEdit);
        var display = string.Format("C{0}", Index);
        titleText = transform.Find("Placeholder").GetComponent<TMP_Text>();

        titleText.SetText(display);
        _inputField.text = Formula.KFloats[Index].ToString();
    }

    private void onEndEdit(string arg0)
    {
        var value = float.Parse(arg0);
        Formula.KFloats[Index] = value;
        OnEndEdit.Invoke();
    }
}