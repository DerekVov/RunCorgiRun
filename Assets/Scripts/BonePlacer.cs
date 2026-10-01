using UnityEngine;
using System.Collections;

public class BonePlacer: TimedObjectPlacer
{
    public void Start()
    {
        MinimumSecondsToWait = GameParameters.BoneMinimumSecondsToWait;
        MaximumSecondsToWait = GameParameters.BoneMaximumSecondsToWait;
    }
}
