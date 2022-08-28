using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.InputSystem;
using UnityEngine;
using UnityEngine.InputSystem;
public class Move : MonoBehaviour
{
    public float speed = 1.0f;

    Vector3 dir;


    private void Start()
    {
        Debug.Log("Hello Unity");
    }

    public void Update()
    {
        transform.position += (speed * Time.deltaTime * dir);
    }

    public void MoveInput(InputAction.CallbackContext context)
    {
        if( context.started)             
        {
            Debug.Log("입력들어옴 - started");
        }
        if (context.performed)
        {
            Debug.Log("입력들어옴 - performed");
        }
        if (context.canceled)
        {
            Debug.Log("입력들어옴 - canceled");
        }
        Vector2 inputDir = context.ReadValue<Vector2>();
        Debug.Log(inputDir);
        dir = inputDir;
    }
    public void FireInput(InputAction.CallbackContext context)
    {
        if( context.performed)
        {
            Debug.Log("발사!");
        }
    }

   
}
