using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    private float _speed;
    private Renderer _renderer;
    
    private void Start()
    {
        _speed = Random.Range(0.05f, 0.1f);
        _renderer = GetComponent<Renderer>();
    }
    
    private void Update()
    {
        _renderer.material.SetTextureOffset($"_MainTex", new Vector2(Time.time * _speed, 0));
    }
}
