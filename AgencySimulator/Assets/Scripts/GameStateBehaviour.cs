using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Principal;
using ChuTools.Attributes;
using ChuTools.Scripts;
using JetBrains.Annotations;
using Michsky.UI.ModernUIPack;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class GameStateBehaviour : MonoBehaviour
{
    [Header("References")]
    [SerializeField]
    private TMP_InputField _playerNameInputField;

    [SerializeField]
    private WindowManager _windowManager;

    public AnimationCurve ac;


    [Header("Configuration")]
    [SerializeField]
    private float duration = 3;

    [SerializeField]
    public GameEventResponse ErrorNotificationShow;

    public FormulaContainer FormulaContainerRef;
    public FormulaContainer BaseFormulas;
    public FormulaContainer KPIFormulas;
    [SerializeField, ScriptVariable(typeof(GameEventArgs))]
    private GameEventArgs InputComplete;

    [Header("Events")]
    [SerializeField]
    [ScriptVariable(typeof(GameEventArgs))]
    private GameEventArgs InvalidBudgetAmountEvent;

    [SerializeField]
    private GameEventResponse InvalidCharacterNotificationShow;

    [SerializeField]
    private GameEventResponse OnSuccessfulNameEntered;
    [SerializeField]
    private GameEventResponse OpenInputWindowResponse;

    [SerializeField]
    public float playerCount;

    [SerializeField]
    private GameEventArgsResponse PlayerNameEntered;

    [SerializeField]
    public static List<PlayerObject> Players = new List<PlayerObject>();

    public RadialSlider RadialSlider;

    [SerializeField]
    private List<float> sliderInputs;

    public List<SliderManager> SliderManagers;

    public float t;

    [SerializeField]
    private float timer = 0;

    public void OnValidatePlayerCount(object[] args)
    {
        var sender = args[0] as GameObject;
        var input = args[1] as string;

        var valid = float.TryParse(input, out playerCount);
        if (string.IsNullOrEmpty(input))
        {
            ErrorNotificationShow.Invoke();
            return;
        }

        if (!valid)
        {
            InvalidCharacterNotificationShow.Invoke();
        }
        else
        {
            OpenInputWindowResponse.Invoke();
        }
    }

    public void ResetInputWindow()
    {
        StopAllCoroutines();
        StartCoroutine(nameof(SlideValues));
        _playerNameInputField.SetTextWithoutNotify("");
        _playerNameInputField.gameObject.SetActive(false);
        _playerNameInputField.gameObject.SetActive(true);
    }

    private void Start()
    {
        sliderInputs    = new List<float>();
       
    }

    public IEnumerator SlideValues()
    { 
        sliderInputs = SliderManagers.Select(s => s.mainSlider.value).ToList();
        var radialStart = RadialSlider.SliderValue;
        while (timer < duration)
        {
            t = timer / duration;
            for(var i = 0; i < SliderManagers.Count;i++)
            {
                SliderManagers[i].mainSlider.value = Mathf.Lerp(sliderInputs[i], 0, ac.Evaluate(t));
            }

            RadialSlider.SliderValue = Mathf.Lerp(radialStart, 0, ac.Evaluate(t));
            RadialSlider.UpdateUI();
            
            timer += Time.deltaTime; 
            
            yield return null;
        } 
        timer = 0;
    }

    public void OnPlayerNameEntered(object[] args)
    {
        var sender = args[0];
        var playerName = args[1].ToString();
        if (sender == null)
            return;

        if (RadialSlider.SliderValue < 100)
        {
            InvalidBudgetAmountEvent.Raise(this);
            return;
        }

        var player = new PlayerObject()
        {
            Inputs = SliderManagers.Select(sm=> sm.mainSlider.value).ToList(),
            Name = playerName,
            ResultsDictionary = new Dictionary<string, List<float>>()
            
            
        };

        var sliderindex = 0;
        sliderInputs = SliderManagers.Select(s => s.mainSlider.value).ToList();
        foreach (var formula in FormulaContainerRef.Formulas)
        {
            if (sliderindex < 4)
            {
                formula.input = sliderInputs[sliderindex];
                sliderindex++;    
            }
            
            formula.Calculate();
            player.ResultsDictionary.Add(formula.name, formula.Results);
            
        }
        

        Players.Add(player);

        if (Players.Count >= playerCount)
        {
            InputComplete.Raise(this);
        }
        else
        {
            OnSuccessfulNameEntered.Invoke();
        }
    }


}