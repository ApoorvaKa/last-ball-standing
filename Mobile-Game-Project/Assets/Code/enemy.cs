using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemy : MonoBehaviour
{
    Rigidbody2D _rigidbody;
    AudioSource _audiosource;
    LineRenderer guideline;
    Vector2 startpos;
    float delay = 0;
    float passed = 0;
    public float detection = 10;

    GameObject _player;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        guideline = GetComponent<LineRenderer>();
        _player = GameObject.FindGameObjectWithTag("Player");
        _audiosource = GetComponent<AudioSource>();
    }

    void Update()
    {
        passed += Time.deltaTime;
        Vector2 difference = _player.transform.position - transform.position;
        if(difference.magnitude <= detection && delay <= passed){
            print("Enemy Launched");
            _rigidbody.AddForce(100*Random.Range(0.5f, 3) * difference.normalized);
            delay = Random.Range(0.2f, 2);
            passed = 0;
        }
    }

    private void OnCollisionEnter2D(Collision2D other){
        if (!(other.gameObject.CompareTag("Player"))){
            _audiosource.volume = _rigidbody.velocity.magnitude/20;

            // half the volume if 2 enemies collide
            if(other.gameObject.CompareTag("enemy")){
                _audiosource.volume /= 2;
            }
            _audiosource.Play();
            _audiosource.volume = 1;
        }
        if (other.gameObject.CompareTag("Obstacle")){
            print("died");
            Destroy(this.gameObject);
            PublicVars.enemiesSlain++;
        }
    }
}
