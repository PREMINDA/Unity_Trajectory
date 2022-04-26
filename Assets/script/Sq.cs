using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sq : MonoBehaviour
{
    
    [SerializeField]private Transform tr;
    
 
    [SerializeField] AnimationCurve ac;
 
    // Start is called before the first frame update
    void Start()
    {
        
    }
 
    // Update is called once per frame
    void Update()
    {
        //transform.position = tr.position;
        Vector2 mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
 
        // get direction you want to point at
        Vector2 direction = (mouseScreenPosition - (Vector2) transform.position).normalized;
 
        // set vector of transform directly
        transform.up = direction;
    }
}
