using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PublicVars : MonoBehaviour
{
    // timing and high score 
    public static float timePassed;

    // item collection
    public static int itemsCollected;


    // pause menu
    public static bool paused = false;

    public static bool alive = true;
    // level checker for win state

    public static bool blue1 = false;
    public static bool blue2 = false;
    public static bool red1 = false;
    public static bool red2 = false;
    public static bool purp1 = false;
    public static bool purp2 = false;
    
    public static int completionCount = 0;
}
