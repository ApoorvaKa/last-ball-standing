using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    public string scene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("Player")){
            if(scene == "Hub"){
                string sceneName = SceneManager.GetActiveScene().name;
                print(sceneName);
                if(PublicVars.timePassed < PlayerPrefs.GetFloat(sceneName, Mathf.Infinity)){
                    PlayerPrefs.SetFloat(sceneName, PublicVars.timePassed);
                    print("New Record set");
                }
                handleCompletion();
            }
            PublicVars.timePassed = 0;
            SceneManager.LoadScene(scene);
        }
    }

    void handleCompletion(){
        string sceneName = SceneManager.GetActiveScene().name;
        switch(sceneName){
            case "Blue1": PublicVars.blue1 = true; break;
            case "Blue2": PublicVars.blue2 = true; break;
            case "Red12": PublicVars.red1 = true; break;
            case "Red2": PublicVars.red2 = true; break;
            case "Purp1": PublicVars.purp1 = true; break;
            case "Purp2": PublicVars.purp2 = true; break;
            default: Debug.Log("check names in Portal.cs"); break;
        }
    }
}
