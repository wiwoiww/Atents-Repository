using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background_Planet : MonoBehaviour
{
    public float moveSpeed = 10.0f;
    public float minRightEnd = 40.0f;
    public float maxRightEnd = 60.0f;

    public Transform bgSlots;

    const float movePositionX = -10.0f;

    private void Update()
    {
        // 이 오브젝트는 왼쪽으로 매 초 moveSpeed만큼 이동한다.
        transform.Translate(moveSpeed * Time.deltaTime * -transform.right);

        // 이 오브젝트는 movePositionX보다 왼쪽으로 이동하면 오른쪽 끝으로 이동한다.
        if(transform.position.x < movePositionX )
        {
            // 오른쪽 끝의 위치는 minRightEnd ~ maxRightEnd 사이를 랜덤으로 결정한다.
            transform.Translate(transform.right * Random.Range(minRightEnd, maxRightEnd));

        }

    }



}
