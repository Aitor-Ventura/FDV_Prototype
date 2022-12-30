using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    [Header("References")]
    [Tooltip("The text that displays the score to win.")]
    [SerializeField] private TextMeshPro gateText;

    [Header("Settings")] 
    [SerializeField] private int winScore;
    
    private int _currentScore = -1;
    private int _soulsLeftToWin;

    private SoulBehaviour[] _soulsExistingInScene;

    private void OnEnable()
    {
        SoulBehaviour.OnSaveSoul += IncreaseCurrentScore;
        SoulBehaviour.OnSaveSoul += UpdateGateText;
    }
    
    private void OnDisable()
    {
        SoulBehaviour.OnSaveSoul -= IncreaseCurrentScore;
        SoulBehaviour.OnSaveSoul -= UpdateGateText;
    }

    private void Start()
    {
        _soulsExistingInScene = FindObjectsOfType<SoulBehaviour>();
        
        Invoke(nameof(IncreaseCurrentScore), 0f);
        Invoke(nameof(UpdateGateText), 0f);
        
        InvokeRepeating(nameof(UpdateSoulsExistingInScene), 0f, 0.15f);
        InvokeRepeating(nameof(CheckWinCondition), 0f, 0.5f);
    }

    private void UpdateGateText()
    {
        if (_soulsLeftToWin < 0)
        {
            gateText.SetText("0");
            return;
        }
        gateText.SetText(_soulsLeftToWin.ToString());
    }
    
    private void IncreaseCurrentScore()
    {
        _currentScore += 1;
        _soulsLeftToWin = winScore - _currentScore;
    }

    private void UpdateSoulsExistingInScene()
    {
        _soulsExistingInScene = FindObjectsOfType<SoulBehaviour>();
    }
    
    private void CheckWinCondition()
    {
        if (_currentScore >= winScore)
        {
            // Win
            Debug.Log("Current values: " + _currentScore + " " + winScore);
        }

        if (_soulsExistingInScene.Length < _soulsLeftToWin)
        {
            // Game Over
            Debug.Log("Game Over");
        }
    }
}
