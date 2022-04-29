using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRender : MonoBehaviour
{
    private Vector2 _startPoint;
    private Vector2 _endPoint;
    private LineRenderer _lr;

    
    void Start()
    {
        _lr = GetComponent<LineRenderer>();
        _lr.startWidth = 0.3f;
        _lr.endWidth = 0.15f;
        _lr.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        _lr.SetPosition(0,_startPoint);
        _lr.SetPosition(1,_endPoint);
    }

    public void SetStarEndtPoint(Vector2 stp,Vector2 etp)
    {
        _startPoint = stp;
        _endPoint = etp;
    }

    public void SetEnableTrue()
    {
        _lr.enabled = true;
    }
    
    public void SetEnableFale()
    {
        _lr.enabled = false;
    }
}
