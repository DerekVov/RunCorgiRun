using UnityEngine;

public class MoonshinePlacer : TimedObjectPlacer
{
    public void Start()
    {
        MinimumSecondsToWait = GameParameters.MoonshineMinimumSecondsToWait;
        MaximumSecondsToWait = GameParameters.MoonshineMaximumSecondsToWait;
    }

    protected override void Place()
    {
        Instantiate(BonePrefab, SpawnTools.RandomTopOfScreenLocationWorldSpace(), Quaternion.identity);
    }
}
