using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 1.0f;
    private void Start()
    {

    }

    private void Update()
    {
        transform.position += (speed * Time.deltaTime * Vector3.right);
    }
}
