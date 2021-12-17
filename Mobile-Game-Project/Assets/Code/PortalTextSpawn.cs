using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortalTextSpawn : MonoBehaviour
{
    private int enemyCount;
    private bool firstTime;
    private GameObject[] enemies;

    // Start is called before the first frame update
    void Start()
    {
        firstTime = true;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemyCount = enemies.Length;
        Debug.Log(enemyCount);
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemyCount = enemies.Length;
        Debug.Log(enemyCount);
        if(firstTime && enemyCount <= 0){
            Debug.Log("ding");
            StartCoroutine(ShowText(4f, GetComponent<Text>()));
        }
    }

    public IEnumerator ShowText(float t, Text i){
        firstTime = false;
        i.color = new Color(i.color.r, i.color.g, i.color.b, 0);
        while(i.color.a < 1.0f){
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (Time.deltaTime / t));
        }
        yield return new WaitForSeconds(2f);
        StartCoroutine(WaitForFade(4f, i));
    }

    public IEnumerator WaitForFade(float t, Text i){
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while(i.color.a > 0.0f){
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t)); 
            yield return null;
        }
    }
}
