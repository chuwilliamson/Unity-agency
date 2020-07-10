using System;
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
    [Header("Events")]
    [SerializeField]
    [ScriptVariable(typeof(GameEventArgs))]
    private GameEventArgs InvalidBudgetAmountEvent;

    [SerializeField, ScriptVariable(typeof(GameEventArgs))]
    private GameEventArgs InputComplete;

    [SerializeField]
    private GameEventArgsResponse PlayerNameEntered;

    [SerializeField]
    public GameEventResponse ErrorNotificationShow;

    [SerializeField]
    private GameEventResponse InvalidCharacterNotificationShow;

    [SerializeField]
    private GameEventResponse OpenInputWindowResponse;

    [Header("References")]
    [SerializeField]
    private TMP_InputField _playerNameInputField;

    public FormulaContainer FormulaContainerRef;

    [SerializeField]
    private WindowManager _windowManager;

    public RadialSlider RadialSlider;

    public List<SliderManager> SliderManagers;


    [Header("Configuration")]
    [SerializeField]
    private float duration = 3;

    [SerializeField]
    public float playerCount;

    [SerializeField]
    private List<PlayerObject> Players = new List<PlayerObject>();

    [SerializeField]
    private float timer = 0;

    public AnimationCurve ac;

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
    }

    private void Start()
    {
        sliderInputs    = new List<float>();
       
    }

    [SerializeField]
    private List<float> sliderInputs;

    public float t;
    
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
            FormulaContainer = Instantiate(FormulaContainerRef) as FormulaContainer,
            Name = playerName
        };

        
        
        for (var i = 0; i < player.FormulaContainer.Formulas.Count; i++)
        {
            var clone = Instantiate(player.FormulaContainer.Formulas[i]);
            player.FormulaContainer.Formulas[i] = clone;
        }

        Players.Add(player);

        if (Players.Count >= playerCount)
        {
            InputComplete.Raise(this);
        }
        else
        {
            ResetInputWindow();
        }
    }

    [Serializable]
    public class PlayerObject
    {
        public FormulaContainer FormulaContainer;
        public string Name;
    }
}