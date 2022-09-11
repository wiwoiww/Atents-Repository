//using System;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{
    public float speed = 5.0f;
    public GameObject bullet;
    public float fireInterval = 0.5f;
    float boost = 1.0f;

    //bool isFiring = false;
    //float fireTimeCount = 0.0f;

    Vector3 dir;

    PlayerInputAction inputActions;

    IEnumerator fireCoroutine;

    Rigidbody2D rigid;
    Animator anim;

    private void Awake()
    {
        inputActions = new PlayerInputAction();
        rigid = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        fireCoroutine = Fire();
    }

    private void OnEnable()
    {
        inputActions.Player.Enable();
        inputActions.Player.Move.performed += OnMove;
        inputActions.Player.Move.canceled += OnMove;
        inputActions.Player.Fire.performed += OnFireStart;
        inputActions.Player.Fire.canceled += OnFireStop;
        inputActions.Player.Boost.performed += BoostOn;
        inputActions.Player.Boost.canceled += BoostOff;
    }

    private void OnDisable()
    {
        inputActions.Player.Boost.canceled -= BoostOff;
        inputActions.Player.Boost.performed -= BoostOn;
        inputActions.Player.Fire.performed -= OnFireStart;
        inputActions.Player.Move.canceled -= OnMove;
        inputActions.Player.Move.performed -= OnMove;
        inputActions.Player.Disable();
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

    private void OnFireStart(InputAction.CallbackContext _)
    {
        //Instantiate(bullet, transform.position, Quaternion.identity);
        //isFiring = true;
        StartCoroutine(fireCoroutine);
    }
    private void OnFireStop(InputAction.CallbackContext _)
    {
        //isFiring = false;
        StopCoroutine(fireCoroutine);
    }

    IEnumerator Fire()
    {
        while (true)
        {
            Instantiate(bullet, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(fireInterval);
        }
    }

    private void BoostOn(InputAction.CallbackContext context)
    {
        boost *= 2.0f;
    }

    private void BoostOff(InputAction.CallbackContext context)
    {
        boost = 1.0f;
    }

}
