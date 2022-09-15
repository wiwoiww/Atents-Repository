using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float rotateSpeed = 180.0f;

    //Vector3 dir;
    //Rigidbody rigid;
    PlayerInputActions inputActions;

    private void Awake()
    {
        inputActions = new PlayerInputActions();     // 인스턴스 생성
    //    rigid = GetComponent<Rigidbody>();
    }

    //private void OnEnable()
    //{
    //    inputActions.Player.Enable();
    //    inputActions.Player.Move.performed += OnMove;
    //    inputActions.Player.Move.canceled += OnMove;

    //}

    //private void OnDisable()
    //{
    //    inputActions.Player.Move.canceled -= OnMove;
    //    inputActions.Player.Move.performed -= OnMove;
    //    inputActions.Player.Disable();
    //}

    //private void FixedUpdate()
    //{
    //    rigid.MovePosition(transform.position +  moveSpeed * Time.fixedDeltaTime * dir);
    //}

    //private void OnMove(InputAction.CallbackContext context)
    //{
    //    Vector3 inputDir = context.ReadValue<Vector3>();
    //    dir = inputDir;
    //}
}
