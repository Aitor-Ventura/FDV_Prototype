using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Vector3 velocity;
    [SerializeField] private SpriteRenderer spriteRenderer;
    
    private Rigidbody2D _rigidbody;
    private Vector3 _mOffset;
    private float _mZCoord;
    private Vector3 _newPosition;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _newPosition = transform.position;
    }

    private void FixedUpdate()
    {
        _rigidbody.MovePosition(_newPosition + velocity * Time.fixedDeltaTime);
    }

    private void OnMouseDown()
    {
        var position = gameObject.transform.position;
        _mZCoord = Camera.main.WorldToScreenPoint(position).z;
        _mOffset = position - GetMouseWorldPos();
        
        spriteRenderer.transform.DOComplete();
        spriteRenderer.transform.DOPunchScale(new Vector3(
            spriteRenderer.transform.localScale.x - 0.65f,
            spriteRenderer.transform.localScale.y - 0.65f,
            spriteRenderer.transform.localScale.z - 0.65f), 
            0.35f, 10, 1f);
    }

    private void OnMouseDrag()
    {
        _newPosition = GetMouseWorldPos() + _mOffset;
    }

    private Vector3 GetMouseWorldPos()
    {
        Vector3 mousePoint = Input.mousePosition;
        mousePoint.z = _mZCoord;
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
}
