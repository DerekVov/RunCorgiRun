using UnityEngine;

public class PillPlacer : TimedObjectPlacer
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        MinimumSecondsToWait = GameParameters.PillMinimumSecondsToWait;
        MaximumSecondsToWait = GameParameters.PillMaximumSecondsToWait;
    }

    
}
