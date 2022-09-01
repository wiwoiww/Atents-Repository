using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public float rotateSpeed = 360.0f;          // 회전 속도
    public float moveSpeed = 3.0f;              // 이동 속도
    public Vector3 direction = Vector3.left;    // 운석이 이동할 방향
    public int hitPoint = 3;

    public float minMoveSpeed = 2.0f;
    public float maxMoveSpeed = 4.0f;
    public float minRotateSpeed = 30.0f;
    public float maxRotateSpeed = 360.0f;

    float lifeTime = 3.0f;
    public float minLifeTime = 3.0f;
    public float maxLifeTime = 5.0f;

    public GameObject small;
    [Range(1,16)] // 컴포넌트창에 자유롭게 숫자를 쓰던게 1~16만 쓸수잇게끔 바꿔줌
    public int splitCount = 3;

    private GameObject explosion;

    SpriteRenderer sprite;

    private void Awake()
    {
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();

        //sprite.flipX = true;
        //sprite.flipY = false;
        //int rand = Random.Range(0, 100) & 2;
        ////if(rand == 0)
        ////{
        ////    sprite.flipX = true;
        ////}
        ////else
        ////{
        ////    sprite.flipX = false;
        ////}
        //sprite.flipX = (rand == 0);

        int rand = Random.Range(0, 4);          // rand에다가 0(0b_00),1(0b_01),2(0b_10),3(0b_11) 중 하나의 숫자를 랜덤으로 준다.

        //rand & 0b_01 : rand의 제일 오른쪽 비트가 0인지 1인지 확인하는 작업
        //((rand & 0b_01) != 0) : rand의 제일 오른쪽 비트가 1이면 true, 0이면 false를 리턴
        sprite.flipX = ((rand & 0b_01) != 0);

        //rand & 0b_10 : rand의 제일 오른쪽에서 두번째 비트가 0인지 1인지 확인하는 작업
        //((rand & 0b_10) != 0) : rand의 제일 오른쪽에서 두번째 비트가 1이면 true, 0이면 false를 리턴
        sprite.flipY = ((rand & 0b_10) != 0);

        moveSpeed = Random.Range(minMoveSpeed,maxMoveSpeed);
        float ratio =(moveSpeed - minMoveSpeed) / (maxMoveSpeed - minMoveSpeed);
        //rotateSpeed = ratio * (maxRotateSpeed - minRotateSpeed) + minRotateSpeed;
        rotateSpeed = Mathf.Lerp(minRotateSpeed, maxRotateSpeed, ratio);
        //rotateSpeed = Random.Range(30.0f, 360.0f);
        //Debug.Log($"calc : {rotateSpeed}");
        //Debug.Log($"Larp : {Mathf.Lerp(minRotateSpeed, maxRotateSpeed, ratio)}");

        lifeTime = Random.Range(minLifeTime,maxLifeTime);
    }

    private void Start()
    {
        explosion = transform.GetChild(0).gameObject;

        StartCoroutine(SelfCrush());
        
    }

    IEnumerator SelfCrush()
    {
        yield return new WaitForSeconds(lifeTime);

        Crush();
    }
    void Update()
    {
        //transform.rotation *= Quaternion.Euler(new(0, 0, 90));    // 계속 90도씩 회전
        //transform.rotation *= Quaternion.Euler(new(0, 0, rotateSpeed * Time.deltaTime));    // 1초에 360도씩 회전
        transform.Rotate(rotateSpeed * Time.deltaTime * Vector3.forward);   // Vector3.forward 축을 기준으로 1초에 rotateSpeed도씩 회전

        transform.Translate(moveSpeed * Time.deltaTime * direction, Space.World);

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position,transform.position + direction * 1.5f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            hitPoint--;

            if (hitPoint <= 0)
            {
                Crush();
            }
        }
    }
    void Crush()
    {
        explosion.SetActive(true);
        explosion.transform.parent = null;

        float angleGap = 360.0f / (float)splitCount;  // 작은 운석들의 진행 방향의 사이각
        float rand = Random.Range(0.0f, 360.0f);      // 첫 운석 방향 변화용
        for(int i=0;i<splitCount;i++)
        {
            Instantiate(small, transform.position, Quaternion.Euler(0, 0, (angleGap * i) + rand)); 
        }

        Destroy(this.gameObject);
    }
}

