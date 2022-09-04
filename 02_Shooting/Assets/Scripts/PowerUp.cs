using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    float lifeTime = 10.0f;

    private void Start()
    {
        Destroy(this.gameObject, lifeTime);
    }

}
// PowerUp 아이템은 1초에 한번씩 움직일 방향을 랜덤으로 결정한다.
// PowerUp 아이템 Border에 부딪치면 반사된다.
// PowerUp 아이템은 10초 후에 사라진다.