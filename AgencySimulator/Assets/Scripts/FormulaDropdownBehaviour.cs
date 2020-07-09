using System;
using System.Collections;
using System.Collections.Generic;
using Michsky.UI.ModernUIPack;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class FormulaDropdownBehaviour : MonoBehaviour
{
    [SerializeField]
    private CustomDropdown _dropdown;

    [SerializeField]
    private FormulaContainer _formulaContainer;

    [SerializeField]
    private FormulaSliderBehaviour _formulaSliderBehaviour;

    [SerializeField]
    private Transform resultsParent;

    [SerializeField]
    private GameObject inputFieldPrefab;
    [SerializeField]
    private Transform constantsParent;
    private void Start()
    {
        _dropdown.dropdownItems.Clear();
        foreach (var formula in _formulaContainer.Formulas)
        {
            var item = new CustomDropdown.Item();
            item.itemName = formula.name;
            item.OnItemSelection = new UnityEvent();
            item.OnItemSelection.AddListener(() =>
            {
                _formulaSliderBehaviour.SetFormula(formula);
                DestroyChildren(resultsParent);
                
                for (var i = 0; i < formula.Results.Count; i++)
                { 
                    var go = Instantiate(new GameObject("result"), resultsParent);
                    var text = go.AddComponent<TextMeshProUGUI>();
                    text.enableAutoSizing = true;
                    text.SetText(formula.Results[i].ToString());
                }

                DestroyChildren(constantsParent);
                for (var i = 0; i < formula.numConstants; i++)
                {
                    var go = Instantiate(inputFieldPrefab, constantsParent);
                    var inputFieldBehaviour = go.GetComponent<FormulaInputFieldBehaviour>();
                    inputFieldBehaviour.Init(i, formula);
                }
                
                
                
            });
            _dropdown.dropdownItems.Add(item);
            _dropdown.SetupDropdown();
        }
    }

    private void DestroyChildren(Transform parent)
    {
        var children = parent.GetComponentsInChildren<Transform>();

        foreach (var child in children)
        {
            if (child == parent)
                continue;
            GameObject.Destroy(child.gameObject);
        }
    }
}