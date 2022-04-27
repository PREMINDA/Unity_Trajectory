using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sq : MonoBehaviour
{
    private Vector2 _mouseScreenPosition;
    private Camera _cam;
    private Rigidbody2D _rb;
    private Vector2 _lookDir;
    
    [SerializeField]private Transform tr;
    [SerializeField] AnimationCurve ac;
 
    // Start is called before the first frame update
    void Start()
    {
        _cam = Camera.main;
        _rb = GetComponent<Rigidbody2D>();
    }
 
    // Update is called once per frame
    void Update()
    {
        transform.position = transform.parent.transform.position;
        _mouseScreenPosition = _cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate()
    {
        
        _lookDir = (_mouseScreenPosition - _rb.position).normalized;
        float angle = Mathf.Atan2(_lookDir.y, _lookDir.x) * Mathf.Rad2Deg;
        _rb.rotation = angle;
    }

    public Vector2 getLookDir()
    {
        return _lookDir;
    }
}
