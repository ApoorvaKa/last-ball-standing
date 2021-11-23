using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatyBox : MonoBehaviour
{
    Rigidbody2D _rigidbody;
    LineRenderer guideline;
    Vector2 startpos;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        guideline = GetComponentInChildren<LineRenderer>();
    }

    void Update()
    {
        if(Input.touchCount > 0){
            Touch touch = Input.GetTouch(0);
            Vector2 change = touch.position - startpos;
            if (touch.phase == TouchPhase.Began)
            {
                startpos = touch.position;
            }
            if (touch.phase == TouchPhase.Moved)
            {
                guideline.SetPosition(1, change*-0.05f);
            }
            if (touch.phase == TouchPhase.Ended)
            {
                _rigidbody.AddForce(-2*change);
                guideline.SetPosition(1, Vector3.zero);
            }
        }
    }
}
