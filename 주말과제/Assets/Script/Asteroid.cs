using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float rotateSpeed = 360.0f;
    private void Update()
    {
        transform.rotation *= Quaternion.Euler(new(0, 0, 90));
        transform.rotation *= Quaternion.Euler(new(0, 0, rotateSpeed *Time.deltaTime));
        transform.Rotate(new(0, 0, rotateSpeed * Time.deltaTime));
        transform.Rotate(rotateSpeed * Time.deltaTime * Vector3.forward);
    }
}
