using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    PlayerInputAction inputActions;
    public GameObject bullet;
    public float speed = 1.0f;
    float boost = 1.0f;
    Vector3 dir;
    Rigidbody2D rigid;
    Animator anim;
    private void Awake()
    {
        inputActions = new PlayerInputAction();
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        inputActions.Player.Enable();
        inputActions.Player.Move.performed += OnMove;
        inputActions.Player.Move.canceled += OnMove;
        inputActions.Player.Fire.performed += OnFire;
        inputActions.Player.Boost.performed += OnBoostOn;
        inputActions.Player.Boost.canceled += OnBoostOff;
    }


    private void OnDisable()
    {
        inputActions.Player.Boost.canceled -= OnBoostOff;
        inputActions.Player.Boost.performed -= OnBoostOn;
        inputActions.Player.Fire.performed -= OnFire;
        inputActions.Player.Move.canceled -= OnMove;
        inputActions.Player.Move.performed -= OnMove;
        inputActions.Player.Disable();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rigid.MovePosition(transform.position + boost * speed * Time.fixedDeltaTime * dir);
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        Vector2 inputDir = context.ReadValue<Vector2>();
        dir = inputDir;

        anim.SetFloat("InputY", dir.y);
    }

    private void OnFire(InputAction.CallbackContext context)
    {
        Debug.Log("Fire!!!");
        Instantiate(bullet, transform.position, Quaternion.identity);
    }

    private void OnBoostOn(InputAction.CallbackContext context)
    {
        boost *= 2.0f;
    }
    private void OnBoostOff(InputAction.CallbackContext context)
    {
        boost = 1.0f;
    }
}
