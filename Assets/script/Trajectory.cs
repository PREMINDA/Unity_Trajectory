using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trajectory : MonoBehaviour
{
    [SerializeField]private int dotsNumber;
    [SerializeField]private GameObject dotsParent;
    [SerializeField]private GameObject dotPrefab;
    [SerializeField]private float dotSpacing;
    [SerializeField][Range (0.01f, 0.3f)] float dotMinScale;
    [SerializeField][Range (0.3f, 0.8f)] float dotMaxScale;
    
    private Transform[] _dotsList;
    private Vector2 _pos;
    private float _timeStamp;
    
    void Start()
    {
       Hide(); 
       PrepareDots ();
    }
    
    void Update()
    {
    }
    
    void PrepareDots ()
    {
        _dotsList = new Transform[dotsNumber];
        dotPrefab.transform.localScale = Vector3.one * dotMaxScale;

        float scale = dotMaxScale;
        float scaleFactor = scale / dotsNumber;

        for (int i = 0; i < dotsNumber; i++) {
            _dotsList [i] = Instantiate (dotPrefab, null).transform;
            _dotsList [i].parent = dotsParent.transform;

            _dotsList [i].localScale = Vector3.one * scale;
            if (scale > dotMinScale)
                scale -= scaleFactor;
        }
    }
    
    public void UpdateDots (Vector3 ballPos, Vector2 forceApplied)
    {
        _timeStamp = dotSpacing;
        for (int i = 0; i < dotsNumber; i++) {
            _pos.x = (ballPos.x + forceApplied.x * _timeStamp);
            _pos.y = (ballPos.y + forceApplied.y * _timeStamp) - (Physics2D.gravity.magnitude * _timeStamp * _timeStamp) / 2f;
            
            _dotsList [i].position = _pos;
            _timeStamp += dotSpacing;
        }
    }
    
    public void Show ()
    {
        dotsParent.SetActive (true);
    }

    public void Hide ()
    {
        dotsParent.SetActive (false);
    }
}
