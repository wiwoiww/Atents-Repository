using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5.0f;
    //public float lifeTime = 0.5f;

    //private void Start()
    //{
    //    Destroy(this.gameObject, lifeTime);
    //}  // 일정시간 후 삭제 하는 코드

    private void Update()
    {
        //transform.Translate(speed * Time.deltaTime * new Vector3(1,0));
        transform.Translate(speed * Time.deltaTime * Vector3.right, Space.Self);  // Space.Self : 자기 기준, Space.World : 씬 기준
    }
}
