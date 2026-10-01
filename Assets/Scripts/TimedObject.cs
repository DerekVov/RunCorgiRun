using System.Collections;
using UnityEngine;

public class TimedObject : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float secondsOnScreen;
    public void Start()
    {
        // Start death clock
        StartCoroutine(CountdownUntilDeath());

    }

    // Countdown and then go away
    IEnumerator CountdownUntilDeath()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }
}
