using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
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
            GameObject obj = Instantiate(enemy, transform);
            obj.transform.Translate(0, Random.Range(minY, maxY),0);
            yield return new WaitForSeconds(interval);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, new(1, Mathf.Abs(maxY) + Mathf.Abs(minY) + 2, 1));
    }
}
