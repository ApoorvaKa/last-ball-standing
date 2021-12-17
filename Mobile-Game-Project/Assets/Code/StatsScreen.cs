using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class StatsScreen : MonoBehaviour
{
    public Text timesCompleted;
    public Text timeSpent;
    public Text chalkScore;
    public Text enemiesSlain;
    
    void Start(){
        int minutes = Mathf.FloorToInt(PublicVars.timePassedTotal / 60F);
        int seconds = Mathf.FloorToInt(PublicVars.timePassedTotal - minutes * 60);
        string niceTime = string.Format("{0:00}:{1:00}", minutes, seconds);
        timesCompleted.text = "You've completed this game: " + PublicVars.completionCount + " times";
        timeSpent.text = "You've spent: " + niceTime + " playing";
        chalkScore.text = "You've collected: " + PublicVars.itemsCollectedTotal.ToString() + " chalk pieces";
        enemiesSlain.text = "You've slain: " + PublicVars.enemiesSlain.ToString() + " enemies";
    }
    public void returnVS(){
        SceneManager.LoadScene("Victory");
    }
}
