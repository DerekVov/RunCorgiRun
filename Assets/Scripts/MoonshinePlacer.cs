using UnityEngine;

public class MoonshinePlacer : TimedObjectPlacer
{
    public Sounds Sounds;
    public void Start()
    {

    
        MinimumSecondsToWait = GameParameters.MoonshineMinimumSecondsToWait;
        MaximumSecondsToWait = GameParameters.MoonshineMaximumSecondsToWait;
    }

    protected override void Place()
    {
        Instantiate(BonePrefab, SpawnTools.RandomTopOfScreenLocationWorldSpace(), Quaternion.identity);
        Sounds.PlayFallingSound();
    }
}
