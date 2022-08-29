using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject Asteroid;
    public float interval = 0.5f;
    public float speed = 1.0f;

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
            GameObject obj = Instantiate(Asteroid, transform);  
            obj.transform.Translate(0, Random.Range(minY, maxY), 0);
            yield return new WaitForSeconds(interval);  
        }
    }

}
