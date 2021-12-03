using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int enemyCount;
    public GameObject portal;
    // Start is called before the first frame update
    void Start()
    {
        portal.SetActive(false);
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemyCount = enemies.Length;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemyCount = enemies.Length;
        if(enemyCount <= 0){
            portal.SetActive(true);
        }
    }
}
