using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RandomBall : MonoBehaviour
{
    private Rigidbody2D _rb;
    
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.gravityScale = 0;
    }
    
    void Update()
    {
        //Debug.Log(_rb.velocity.x);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        _rb.isKinematic = false;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        _rb.gravityScale = 1f;
    }
}
