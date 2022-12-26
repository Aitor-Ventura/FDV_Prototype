using System;
using DG.Tweening;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float _startPositionX;
    private float _startPositionY;
    private bool _isBeingHeld;
    
    private void Update()
    {
        if (!_isBeingHeld) return;
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        gameObject.transform.localPosition = new Vector3(mousePosition.x - _startPositionX, mousePosition.y - _startPositionY, 0);
    }

    private void OnMouseDown()
    {
        if (!Input.GetMouseButtonDown(0)) return;
        if (Camera.main == null) return;

        gameObject.transform.DOScale(new Vector3(0.6f, 0.6f, 0.6f), 0.15f).SetLoops(2, LoopType.Yoyo).SetEase(Ease.InQuart);

        Vector3 localPosition = transform.localPosition;
        Vector3 screenToWorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
        _startPositionX = screenToWorldPoint.x - localPosition.x;
        _startPositionY = screenToWorldPoint.y - localPosition.y;

        _isBeingHeld = true;
    }

    private void OnMouseUp()
    {
        _isBeingHeld = false;
    }
}
