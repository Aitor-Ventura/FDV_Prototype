using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerationConstraint : MonoBehaviour
{
    [SerializeField] private Vector2 constraint;

    private Rigidbody2D _rigidbody;
    private Vector2 _newVelocity;
    
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        CheckVelocity();
    }

    private void CheckVelocity()
    {
        if (_rigidbody.velocity.x >= 0)
        {
            if (_rigidbody.velocity.x > constraint.x)
            {
                _newVelocity.x = constraint.x;
            }
            else
            {
                _newVelocity.x = _rigidbody.velocity.x;
            }
        }
        else
        {
            if (_rigidbody.velocity.x < -constraint.x)
            {
                _newVelocity.x = -constraint.x;
            }
            else
            {
                _newVelocity.x = _rigidbody.velocity.x;
            }
        }
        
        if (_rigidbody.velocity.y >= 0)
        {
            if (_rigidbody.velocity.y > constraint.y)
            {
                _newVelocity.y = constraint.y;
            }
            else
            {
                _newVelocity.y = _rigidbody.velocity.y;
            }
        }
        else
        {
            if (_rigidbody.velocity.y < -constraint.y)
            {
                _newVelocity.y = -constraint.y;
            }
            else
            {
                _newVelocity.y = _rigidbody.velocity.y;
            }
        }

        _rigidbody.velocity = _newVelocity;
    }
}
