using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRender : MonoBehaviour
{
    [SerializeField][Range (0.1f, 1f)] float lengthMultiplier;
    
    private Vector2 _startPoint;
    private Vector2 _endPoint;
    private LineRenderer _lr;
    

    
    void Start()
    {
        _lr = GetComponent<LineRenderer>();
        _lr.startWidth = 0.3f;
        _lr.endWidth = 0.15f;
        _lr.enabled = false;
        _lr.material.SetColor("_Color", new Color(1f, 1f, 1f, 0.3f));
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 enp = Vector2.Lerp(_startPoint, _endPoint, lengthMultiplier);
        _lr.SetPosition(0,_startPoint);
        _lr.SetPosition(1,enp);
    }

    public void SetStarEndtPoint(Vector2 stp,Vector2 enp)
    {
        _startPoint = stp;
        _endPoint = enp;
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
