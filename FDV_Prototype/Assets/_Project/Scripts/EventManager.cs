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
    [Tooltip("Score the player needs to meet in order to win the level.")]
    [SerializeField] private int winScore;

    public delegate void GameOver();
    public static event GameOver OnGameOver;
    
    public delegate void GameWon();
    public static event GameWon OnGameWon;
    
    private int _currentScore = -1;
    private int _soulsLeftToWin;

    private SoulBehaviour[] _soulsExistingInScene;

    private GameManager _gameManager;

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
        _gameManager = GameManager.Instance.GetComponent<GameManager>();
        
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
            if (OnGameWon != null)
            {
                OnGameWon();
            } 
            _gameManager.Invoke("LoadMainMenu", 0.3f);
        }

        if (_soulsExistingInScene.Length < _soulsLeftToWin)
        {
            // Game Over
            if (OnGameOver != null)
            {
                OnGameOver();
            }
            _gameManager.Invoke("LoadTutorial", 0.3f);
        }
    }
}
