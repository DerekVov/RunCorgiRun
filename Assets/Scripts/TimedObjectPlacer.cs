using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class TimedObjectPlacer : MonoBehaviour
{
    public GameObject BonePrefab;
    
    private bool isOkToCreate = true;
    private bool isActive = false;
    private Coroutine countdownCoroutine;
    

    public float MinimumSecondsToWait = 1f;
    public float MaximumSecondsToWait = 3f;
    
    public void Update()
    {
        if (!isActive)
        {
            return;
        }
        if (isOkToCreate)
        {
            countdownCoroutine = StartCoroutine(CountdownUntilCreation());
        }
    }

    public void StartPlacing()
    {
        isActive = true;
        isOkToCreate = true;
    }

    public void StopPlacing()
    {
        isActive = false;
        isOkToCreate = false;
        if (countdownCoroutine != null)
        {
            StopCoroutine(countdownCoroutine);
        }

        CleanupPlacedObjects();
    }

    private void CleanupPlacedObjects()
    {
        List<GameObject> placedObjects = GameObject.FindGameObjectsWithTag(BonePrefab.tag).ToList();
        for (int i = 0; i < placedObjects.Count; i++)
        {
            Destroy(placedObjects[i]);
        }
    }

    IEnumerator CountdownUntilCreation()
    {
        isOkToCreate = false;
        float secondsToWait = Random.Range(MinimumSecondsToWait, MaximumSecondsToWait);
        yield return new WaitForSeconds(secondsToWait);
        Place();
        isOkToCreate = true;
    }
    protected virtual void Place()
    {
        Instantiate(BonePrefab, SpawnTools.RandomLocationWorldSpace(), Quaternion.identity);
    }
}
