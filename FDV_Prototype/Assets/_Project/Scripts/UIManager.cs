using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    private void Awake()
    {
        if (Instance != null){
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    
    [Header("Main Menu References")]
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private CanvasGroup titleCanvasGroup;
    [SerializeField] private CanvasGroup clickToStartCanvasGroup;
    [SerializeField] private CanvasGroup creditsCanvasGroup;
    
    [Header("Tutorial References")]
    [SerializeField] private GameObject tutorial;
    [SerializeField] private CanvasGroup tutorialCanvasGroup;

    private bool _canClickCanvasGroups = false;
    
    private void DisableEverything()
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }
    
    public void ShowMainMenu()
    {
        DisableEverything();
        mainMenu.SetActive(true);
        titleCanvasGroup.DOFade(1f, 5f).From(0, true);
        clickToStartCanvasGroup.DOFade(1f, 1f).From(0, true).SetDelay(2f).SetLoops(-1, LoopType.Yoyo);
        creditsCanvasGroup.DOFade(1f, 5f).From(0, true).SetDelay(2f).OnPlay(() =>
        {
            _canClickCanvasGroups = true;
        });
    }

    public void HideMainMenu()
    {
        titleCanvasGroup.DOKill();
        clickToStartCanvasGroup.DOKill();
        creditsCanvasGroup.DOKill();

        titleCanvasGroup.DOFade(0f, 1f);
        clickToStartCanvasGroup.DOFade(0f, 1f);
        creditsCanvasGroup.DOFade(0f, 1f).OnComplete(() =>
        {
            GameManager.Instance.LoadTutorial();
        });
    }

    public void ShowTutorial()
    {
        DisableEverything();
        tutorial.SetActive(true);
        tutorialCanvasGroup.DOFade(1f, 1.5f).From(0, true).SetDelay(2f);
        tutorialCanvasGroup.DOFade(0, 1.5f).SetDelay(8f);
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && _canClickCanvasGroups)
        {
            _canClickCanvasGroups = false;
            HideMainMenu();
        }
    }
}
