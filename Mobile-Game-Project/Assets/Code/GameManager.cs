using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject pauseBtn;
    public int enemyCount;
    public GameObject portal;
    public Text timer;
    float timePassed = 0;
    // Start is called before the first frame update
    void Start()
    {
        Resume();
        portal.SetActive(false);
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemyCount = enemies.Length;
    }

    // Update is called once per frame
    void Update(){
        timePassed += Time.deltaTime;
        timer.text = "" + timePassed;
    }
    void FixedUpdate()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemyCount = enemies.Length;
        if(enemyCount <= 0){
            portal.SetActive(true);
        }
    }

    public void Pause()
    {
        PublicVars.paused = true;
        Time.timeScale = 0;
        pauseBtn.SetActive(false);
        pauseMenu.SetActive(true);
    }

    public void Resume()
    {
        PublicVars.paused = false;
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        pauseBtn.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Home(){
        SceneManager.LoadScene("Hub");
        Time.timeScale = 1;
        
    }

}
