using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5.0f;
    public GameObject hitEffect;
    public float lifeTime = 3.0f;

    private void Start()
    {
        Destroy(this.gameObject, lifeTime);
    }  // 일정시간 후 삭제 하는 코드  // this는 이 클래스의 인스턴스

    private void Update()
    {
        //transform.Translate(speed * Time.deltaTime * new Vector3(1,0));
        transform.Translate(speed * Time.deltaTime * Vector3.right, Space.Self);  // Space.Self : 자기 기준, Space.World : 씬 기준
    }
    
    // 충돌한 대상이 컬라이더일 때 실행
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log($"Collision : {collision.gameObject.name}");
        if (collision.gameObject.CompareTag("Enemy"))
        {
            hitEffect.transform.parent = null;
            hitEffect.transform.position = collision.contacts[0].point; // 끝에 point는 부딪친 위치
            // collision.contactCount[0].normal : 법선 벡터(노멀 벡터)
            // 노멀 벡터 : 특정 평면에 수직인 벡터
            // 노멀 벡터는 반사를 계산하기 위해 반드시 필요하다.=> 반사를 이용해서 그림자를 계산한다. 물리적인 반사도 계산한다.
            // 노멀 벡터를 구하기 위해 벡터의 외적을 사용한다.
            hitEffect.gameObject.SetActive(true);
            //Destroy(collision.gameObject);
            Destroy(this.gameObject); //  (this.gameObject)에서 this만 쓰면 bullet에 script만 삭제
        }

        // 매우 좋지 못한 코드
        //if(collision.gameObject.tag == "Enemy")
        //{
        //}
        // 1. CompareTag는 숫자와 숫자를 비교하지만 '==' 은 문자열 비교라서 더 느리다.
        // 2. 필요없는 가비지가 생긴다.
    }

    // 충돌한 대상이 트리거일 때 실행
    private void OnTriggerEnter2D(Collider2D collision)// 마지막 콜리젼이 충돌한 대상
    {
       // Debug.Log($"Trigger : {collision.gameObject.name}");
    }

    // 충돌한 대상이 트리거일때 실행
    //private void OnTriggerExit2D(Collider2D collision) 
    //{
    //    Debug.Log($"Trigger : {collision.gameObject.name}");
    //}
}
