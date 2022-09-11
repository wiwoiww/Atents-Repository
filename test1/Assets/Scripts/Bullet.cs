using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5.0f;

    private void Update()
    {
        transform.Translate(transform.position + speed * Time.fixedDeltaTime * Vector3.right);
    }
}
