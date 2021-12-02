using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemy : MonoBehaviour
{
    Rigidbody2D _rigidbody;
    LineRenderer guideline;
    Vector2 startpos;
    float delay = 0;
    float passed = 0;
    GameObject _player;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        guideline = GetComponent<LineRenderer>();
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        passed += Time.deltaTime;
        Vector2 difference = _player.transform.position - transform.position;
        if(difference.magnitude <= 10 && delay <= passed){
            print("HIT");
            _rigidbody.AddForce(100*Random.Range(0.5f, 3) * difference.normalized);
            delay = Random.Range(0.2f, 2);
            passed = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D other){
        if (other.gameObject.CompareTag("Obstacle")){
            print("died");
            Destroy(this.gameObject);
        }
    }
}
