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
    public Text countChalkText;

    string sceneName;
    float bestTime;

    public Text bestTimeText;

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
        PublicVars.timePassed += Time.deltaTime;
        int minutes = Mathf.FloorToInt(PublicVars.timePassed / 60F);
        int seconds = Mathf.FloorToInt(PublicVars.timePassed - minutes * 60);
        string niceTime = string.Format("{0:00}:{1:00}", minutes, seconds);
        timer.text = niceTime;
        countChalkText.text = PublicVars.itemsCollectedThisLevel.ToString();
        

        sceneName = SceneManager.GetActiveScene().name;
        bestTime = PlayerPrefs.GetFloat(sceneName, 0);
        // print(sceneName);
        // print(bestTime);
        int best_minutes = Mathf.FloorToInt(bestTime / 60F);
        int best_seconds = Mathf.FloorToInt(bestTime - minutes * 60);
        if (best_minutes >= 0 && best_seconds >= 0){
            string bestTimeString = string.Format("Best: {0:00}:{1:00}", best_minutes, best_seconds);
            bestTimeText.text = bestTimeString;
        }
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
        PublicVars.timePassed = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Home(){
        PublicVars.timePassed = 0;
        SceneManager.LoadScene("Hub");
        Time.timeScale = 1;
        
    }

}
