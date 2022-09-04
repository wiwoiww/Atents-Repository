using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class Move : MonoBehaviour
{
    // 유니티 이벤트 함수 : 유니티가 특정 타이밍에 실행 시키는 함수
    float speed = 1.0f;
    Vector3 dir;
    private void Start()
    {
        Debug.Log("Hello Unity");    
    }

    private void Update()
    {
        
        transform.position += (speed * Time.deltaTime * dir);
    }

    public void MoveInput(InputAction.CallbackContext context)
    {
        Vector2 inputDir = context.ReadValue<Vector2>();
        Debug.Log(inputDir);
        dir = inputDir;
    }
    public void FireInput(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            Debug.Log("space키가 눌려졌다.");
        }
    }
}
