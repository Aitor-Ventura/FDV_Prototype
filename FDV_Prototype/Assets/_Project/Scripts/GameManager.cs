using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState gameState;
    
    public enum GameState
    {
        MainMenu,
        Tutorial
    }

    private bool _isFirtTimeLoadMainMenu = true;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        LoadMainMenu();
    }

    public void LoadMainMenu()
    {
        if (!_isFirtTimeLoadMainMenu)
        {
            SceneManager.LoadScene("MainMenu");
        }
        gameState = GameState.MainMenu;
        UIManager.Instance.ShowMainMenu();
        _isFirtTimeLoadMainMenu = false;
    }
    
    public void LoadTutorial()
    {
        SceneManager.LoadScene("Tutorial");
        gameState = GameState.Tutorial;
        UIManager.Instance.ShowTutorial();
    }
}
