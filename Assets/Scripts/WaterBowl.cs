using UnityEngine;
using System.Collections;

public class WaterBowl : TimedObject
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {  
        secondsOnScreen = GameParameters.WaterBowlSecondsOnScreen;
        base.Start();
    }

}
