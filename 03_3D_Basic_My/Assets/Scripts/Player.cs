using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float rotateSpeed = 180.0f;
    public float jumpPower = 3.0f;

    float moveDir = 0.0f;
    float rotateDir = 0.0f;
    bool isJumping = false;


    GroundChecker checker;

    //Vector3 dir;
    Rigidbody rigid;
    Animator anim;

    PlayerInputActions inputActions;                //PlayerInputActions타입이고 inputActions 이름을 가진 변수를 선언.

    public Action onObjectUse;

    private void Awake()
    {
        inputActions = new PlayerInputActions();     // 인스턴스 생성. 실제 메모리를 할당 받고 사용할 수 있도록 만드는 것.
        rigid = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        checker = GetComponentInChildren<GroundChecker>();
        checker.onGrounded += OnGround;
    }

    private void OnEnable()
    {
        inputActions.Player.Enable();               // Player 액션맵에 들어있는 액션들을 처리하겠다.
        inputActions.Player.Move.performed += OnMoveInput; // Move 액션에 연결된 키가 눌러졌을 때 실행되는 함수를 연결(바인딩)
        inputActions.Player.Move.canceled += OnMoveInput;
        inputActions.Player.Jump.performed += OnJumpInput;
        inputActions.Player.Use.performed += OnUseInput;

    }

    private void OnDisable()
    {
        inputActions.Player.Use.performed -= OnUseInput;
        inputActions.Player.Jump.performed -= OnJumpInput;
        inputActions.Player.Move.canceled -= OnMoveInput;
        inputActions.Player.Move.performed -= OnMoveInput; // 바인딩 해제
        inputActions.Player.Disable();              // Player 액션맵에 있는 액션들은 처리하지 않겠다.
    }

    private void FixedUpdate()
    {
        Move();
        Rotate();
        //rigid.MovePosition(transform.position +  moveSpeed * Time.fixedDeltaTime * dir);

        if( isJumping )
        {
            if(rigid.velocity.y < 0)
            {
                checker.gameObject.SetActive(true);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Platform"))
        {
            Elevator platform = collision.gameObject.GetComponent<Elevator>();
            platform.onMove += OnMovingObject;     // 델리게이트 연결
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            Elevator platform = collision.gameObject.GetComponent<Elevator>();
            platform.onMove -= OnMovingObject;     // 델리게이트 해제
        }
    }

    private void OnMoveInput(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();       // 입력된 값을 읽어오기
        //Vector3 inputDir = context.ReadValue<Vector2>();
        //dir = inputDir;
        moveDir = input.y;      // w : +1, s : -1     전진인지 후진인지 결정
        rotateDir = input.x;    // a : -1, d : +1     좌회전인지 우회전인지 결정


        anim.SetBool("IsMove", !context.canceled);   // 이동키를 눌렀으면 true, 아니면 false
    }
    private void OnJumpInput(InputAction.CallbackContext _)
    {
        if (!isJumping) // 점프 중이 아닐 때만 점프
        {
            isJumping = true;
            JumpStart();
        }
    }

    private void OnUseInput(InputAction.CallbackContext _)
    {
        anim.SetTrigger("Use");
        onObjectUse?.Invoke();
    }

    void Move()
    {
        ///rigid.MovePosition(transform.position +  moveSpeed * Time.fixedDeltaTime * dir);
        rigid.MovePosition(rigid.position + moveSpeed * Time.fixedDeltaTime * moveDir * transform.forward );//리지드바디로 이동 설정
    }

    void Rotate()
    {
        // 리지드바디로 회전 설정
        rigid.MoveRotation(rigid.rotation * Quaternion.AngleAxis(rotateDir * rotateSpeed * Time.fixedDeltaTime, transform.up));

        // Quaternion.Euler(0,rotateDir * rotateSpeed * Time.fixedDeltaTime,0)    // x,z축은 회전 없고 y축 기준으로 회전
        // Quaternion.AngleAxis(rotateDir * rotateSpeed * Time.fixedDeltaTime, transform.up); // 플레이어의 y축 기준으로 회전

    }

    void JumpStart()
    {
        // 플레이어의 위쪽 방향(Up)으로 jumpPower만큼 즉시 힘을 추가한다.(질량 영향있음)
        rigid.AddForce(transform.up * jumpPower, ForceMode.Impulse);
        
        checker.gameObject.SetActive(false);
    }

    void OnGround()
    {
        isJumping = false;
    }

    void OnMovingObject(Vector3 delta)
    {
        rigid.velocity = Vector3.zero;              // 원래 플레이어의 벨로시티 제거
        rigid.MovePosition(rigid.position + delta); // 엘베가 이동한만큼 이동시키기
    }

}
