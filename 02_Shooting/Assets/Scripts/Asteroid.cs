using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float rotateSpeed = 360.0f;
    void Update()
    {
        //transform.rotation *= Quaternion.Euler(new(0, 0, 90));    // 계속 90도씩 회전
        //transform.rotation *= Quaternion.Euler(new(0, 0, rotateSpeed * Time.deltaTime));    // 1초에 360도씩 회전
        transform.Rotate(rotateSpeed * Time.deltaTime * Vector3.forward);   // Vector3.forward 축을 기준으로 1초에 rotateSpeed도씩 회전

    }
}
// 운석이 화면 오른쪽 바깥의 랜덤한 지점에서 생성되서 화면 왼쪽 바깥의 랜덤한 지점으로 이동한다.
// - AsteroidSpawner 클래스를 생성한다.
// - AsteroidSpawner 클래스는 주기적으로 Asteroid 프리팹을 생성한다.
// - AsteroidSpawner가 Asteroid를 생성하는 위치는 y만 랜덤.
// - AsteroidSpawner는 Asteroid를 생성한 직후 화면 왼쪽의 랜덤한 지역을 목표로 지정한다.
// - Asteroid는 지정된 지점을 향해 직선으로 움직인다.
// - Asteroid는 자신의 진행방향을 기즈모(DrawLine)로표시한다.
