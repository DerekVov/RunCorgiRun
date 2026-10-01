using UnityEngine;
using System.Collections;
using UnityEditor;

public class BeerPlacer: TimedObjectPlacer
{
    public void Start()
    {
        MinimumSecondsToWait = GameParameters.BeerMinimumSecondsToWait;
        MaximumSecondsToWait = GameParameters.BeerMaximumSecondsToWait;
    }
}
