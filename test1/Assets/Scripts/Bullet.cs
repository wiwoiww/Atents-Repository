using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5.0f;

    private void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.right, Space.Self);
    }
}
