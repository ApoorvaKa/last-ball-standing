using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChecker : MonoBehaviour
{
    public GameObject blue1Star;
    public GameObject blue2Star;
    public GameObject red1Star;
    public GameObject red2Star;
    public GameObject purp1Star;
    public GameObject purp2Star;

    void Start()  //checks to see if level/game is complete
    {
        if(PublicVars.blue1){
            activateStar(blue1Star);
        } else {
            deactivateStar(blue1Star);
        }

        if(PublicVars.blue2){
            activateStar(blue2Star);
        } else {
            deactivateStar(blue2Star);
        }

        if(PublicVars.red1){
            activateStar(red1Star);
        } else {
            deactivateStar(red1Star);
        }
            
        if(PublicVars.red2){
            activateStar(red2Star);
        } else {
            deactivateStar(red2Star);
        }
            
        if(PublicVars.purp1) {
            activateStar(purp1Star);
        } else {
            deactivateStar(purp1Star);
        }
            
        if(PublicVars.purp2) {
            activateStar(purp2Star);
        } else {
            deactivateStar(purp2Star);
        }
           
        if(PublicVars.blue1 && PublicVars.blue2 && PublicVars.red1 && PublicVars.red2 && PublicVars.purp1 && PublicVars.purp2){
            PublicVars.completionCount += 1;
            SceneManager.LoadScene("Victory");

        }
    }

    void activateStar(GameObject star){
        star.SetActive(true);

    }

    void deactivateStar(GameObject star){
        star.SetActive(false);
    }
}
