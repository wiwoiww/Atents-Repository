using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroid;
    public float interval = 0.5f;

    float minY = -4.0f;
    float maxY = 4.0f;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            GameObject obj = Instantiate(asteroid, transform);
            obj.transform.Translate(0, Random.Range(minY, maxY), 0);
            yield return new WaitForSeconds(interval);
        }
    }
}
