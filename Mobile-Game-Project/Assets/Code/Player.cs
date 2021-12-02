using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody2D _rigidbody;
    LineRenderer guideline;
    Vector2 startpos;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        guideline = GetComponent<LineRenderer>();
    }

    void Update()
    {
        if(Input.touchCount > 0){
            Touch touch = Input.GetTouch(0);
            Vector2 change = touch.position - startpos;
            if (change.magnitude > 100){
                change = change.normalized * 100;
            }
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
                _rigidbody.AddForce(-4*change);
                guideline.SetPosition(1, Vector3.zero);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("PickUp")){
            Destroy(other.gameObject);
            PublicVars.itemsCollected++;
            // Will add UI and audio changes when decided
        }
    }

    private void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.CompareTag("Obstacle")){
            print("died");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
