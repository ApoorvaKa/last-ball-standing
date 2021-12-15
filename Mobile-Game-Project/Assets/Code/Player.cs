using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    Rigidbody2D _rigidbody;
    AudioSource _audiosource;
    public Animator animator;
    public AudioClip coinSnd;
    public AudioClip collision;
    LineRenderer guideline;
    Vector2 startpos;

    private IEnumerator deathCoroutine;
    void Start()
    {   
        _rigidbody = GetComponent<Rigidbody2D>();
        guideline = GetComponent<LineRenderer>();
        _audiosource = GetComponent<AudioSource>();
        animator.SetBool("Dying", false);
        deathCoroutine = WaitAndDie(3);
    }

    void Update()
    {
        if(Input.touchCount > 0 && PublicVars.alive){
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
            _audiosource.PlayOneShot(coinSnd);
            PublicVars.itemsCollected++;
        }
    }

    private void OnCollisionEnter2D(Collision2D other){
        _audiosource.volume = _rigidbody.velocity.magnitude/20;
        Debug.Log(_audiosource.volume);
        _audiosource.PlayOneShot(collision);
        _audiosource.volume = 1;
        if (other.gameObject.CompareTag("Obstacle")){
            PublicVars.alive = false;
            _rigidbody.velocity = Vector2.zero;
            Debug.Log("touched the pointy thing");
            animator.SetBool("Dying", true);
            StartCoroutine(deathCoroutine);

        }
    }

    IEnumerator WaitAndDie(float waitTime){
        Debug.Log("starting the death coroutine");
        yield return new WaitForSeconds(1.5f);
        PublicVars.itemsCollected = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        PublicVars.alive = true;
        PublicVars.timePassed = 0;
        Debug.Log("finished");
        
    }
}
