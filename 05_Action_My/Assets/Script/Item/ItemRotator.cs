using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 이 스크립트를 가진 오브젝트는 y축을 기준으로 계속 회전(시계방향)하면서 위아래로 올라갔다 내려갔다 한다(삼각함수 활용).
public class ItemRotator : MonoBehaviour
{
    public float rotateSpeed = 360.0f;      // 오브젝트의 회전 속도
    public float minHeight = 0.5f;          // 오브젝트의 가장 낮은 높이
    public float maxHeight = 1.5f;          // 오브젝트의 가장 높은 높이


    private void Update()
    {
        transform.Rotate(0, rotateSpeed * Time.deltaTime, 0);
    }
}
