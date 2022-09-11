using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2.0f;

    private void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.left, Space.World);
    }
}
