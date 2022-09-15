using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float rotateSpeed = 180.0f;

    float moveDir = 0.0f;
    float rotateDir = 0.0f;
    //Vector3 dir;
    Rigidbody rigid;
    PlayerInputActions inputActions;                //PlayerInputActions타입이고 inputActions 이름을 가진 변수를 선언.

    private void Awake()
    {
        inputActions = new PlayerInputActions();     // 인스턴스 생성. 실제 메모리를 할당 받고 사용할 수 있도록 만드는 것.
        rigid = GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        inputActions.Player.Enable();               // Player 액션맵에 들어있는 액션들을 처리하겠다.
        inputActions.Player.Move.performed += OnMoveInput; // Move 액션에 연결된 키가 눌러졌을 때 실행되는 함수를 연결(바인딩)
        inputActions.Player.Move.canceled += OnMoveInput;

    }

    private void OnDisable()
    {
        inputActions.Player.Move.canceled -= OnMoveInput;
        inputActions.Player.Move.performed -= OnMoveInput; // 바인딩 해제
        inputActions.Player.Disable();              // Player 액션맵에 있는 액션들은 처리하지 않겠다.
    }

    private void FixedUpdate()
    {
        Move();
        Rotate();
        //rigid.MovePosition(transform.position +  moveSpeed * Time.fixedDeltaTime * dir);
    }

    private void OnMoveInput(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();       // 입력된 값을 읽어오기
        //Vector3 inputDir = context.ReadValue<Vector2>();
        //dir = inputDir;
        moveDir = input.y;      // w : +1, s : -1     전진인지 후진인지 결정
        rotateDir = input.x;    // a : -1, d : +1     좌회전인지 우회전인지 결정
    }

    void Move()
    {
        ///rigid.MovePosition(transform.position +  moveSpeed * Time.fixedDeltaTime * dir);
        rigid.MovePosition(rigid.position + moveSpeed * Time.fixedDeltaTime * moveDir * transform.forward );
    }

    void Rotate()
    {

    }
}
