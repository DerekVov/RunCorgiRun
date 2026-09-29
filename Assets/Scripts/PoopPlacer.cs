using UnityEngine;

public class PoopPlacer : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject PoopPrefab;
    public void Place(Vector3 position)
    {
        Instantiate(PoopPrefab, position, Quaternion.identity);
    }
}
