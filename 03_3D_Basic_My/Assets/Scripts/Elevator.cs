using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody)
        {
            Debug.Log("엘베기동.");
            anim.SetBool("IsEnter", true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.rigidbody)
        {
            Debug.Log("엘베멈춤.");
            anim.SetBool("IsEnter", false);
        }
    }
}
