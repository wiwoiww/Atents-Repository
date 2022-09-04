using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Bullet : MonoBehaviour
{
    public float speed = 1.0f;

    void Update()
    {
        transform.Translate(speed * Time.deltaTime * Vector3.right, Space.Self);
    }

}
