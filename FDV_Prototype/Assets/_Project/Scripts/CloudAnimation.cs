using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudAnimation : MonoBehaviour
{
    [SerializeField] private Sprite idle;
    [SerializeField] private Sprite gameOver;
    [SerializeField] private Sprite win;
    
    private SpriteRenderer _spriteRenderer;

    private void OnEnable()
    {
        EventManager.OnGameOver += AnimationGameOver;
        EventManager.OnGameWon += AnimationGameWon;
    }

    private void OnDisable()
    {
        EventManager.OnGameOver -= AnimationGameOver;
        EventManager.OnGameWon -= AnimationGameWon;
    }

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _spriteRenderer.sprite = idle;
    }
    
    private void AnimationGameOver()
    {
        _spriteRenderer.sprite = gameOver;
    }

    private void AnimationGameWon()
    {
        _spriteRenderer.sprite = win;
    }
}
