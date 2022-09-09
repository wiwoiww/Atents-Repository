using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float speed = 1.0f;
    Vector3 dir;
    PlayerInputAction inputActions;

    private void Awake()
    {
        inputActions = new PlayerInputAction();
    }

    private void OnEnable()
    {
        inputActions.Player.Enable();
        inputActions.Player.Move.performed += OnMove;
        inputActions.Player.Move.canceled += OnMove;
        inputActions.Player.Fire.performed += OnFire;
        inputActions.Player.Fire.canceled += OnFire;
    }

    private void OnDisable()
    {
        inputActions.Player.Fire.canceled -= OnFire;
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

        transform.position += (speed * Time.deltaTime * dir);
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        Vector2 inputDir = context.ReadValue<Vector2>();
        dir = inputDir;
        Debug.Log("이동 입력");
    }

    private void OnFire(InputAction.CallbackContext context)
    {
        Debug.Log("Fire!!!");
    }
}
