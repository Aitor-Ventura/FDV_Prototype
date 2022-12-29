using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using DG.Tweening;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class SoulBehaviour : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _rigidbody.gravityScale = 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Gate"))
        {
            SaveSoul();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _rigidbody.gravityScale = 1;
        }

        if (other.gameObject.CompareTag("Limit"))
        {
            DestroySoul();
        }
    }
    
    private void SaveSoul()
    {
        transform.DOComplete();
        transform.DOScale(Vector3.zero, 0.20f).From(transform.localScale).OnComplete(() =>
        {
            Destroy(gameObject);
        });
    }
    
    private void DestroySoul()
    {
        transform.DOComplete();
        transform.DOScale(Vector3.zero, 0.20f).From(transform.localScale).OnComplete(() =>
        {
            Destroy(gameObject);
        });
    }
}