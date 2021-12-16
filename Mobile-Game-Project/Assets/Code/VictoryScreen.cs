using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryScreen : MonoBehaviour
{
    public void replayGame(){
        PublicVars.blue1 = false;
        PublicVars.blue2 = false;
        PublicVars.red1 = false;
        PublicVars.red2 = false;
        PublicVars.purp1 = false;
        PublicVars.purp2 = false;
        SceneManager.LoadScene("Hub");
    }

    public void viewStats(){
        SceneManager.LoadScene("Stats");
    }
}
