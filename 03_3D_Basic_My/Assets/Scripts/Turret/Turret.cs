using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    // sightRadius 아무런 영향을 주지 않는다.
    // turnSpeed가 아무런 형향을 주지 않는다. (총구가 즉시 회전한다.)

    public float turnSpeed = 2.0f;
    public float sightRadius = 5.0f;

    public GameObject bulletPrefab;
    public float fireInterval = 0.5f;

    Transform fireTransform;
    IEnumerator fireCoroutine;

    Transform target = null;
    Transform barrelBody;

    float currentAngle = 0.0f;
    float targetAngle = 0.0f;
    Vector3 initialForward;

    private void Awake()
    {
        barrelBody = transform.GetChild(2);
        fireTransform = barrelBody.GetChild(1);

        fireCoroutine = PeriodFire();
    }

    private void Start()
    {
        initialForward = transform.forward;
        SphereCollider col = GetComponent<SphereCollider>();
        col.radius = sightRadius;

        StartCoroutine(fireCoroutine);
    }

    /// <summary>
    /// 인스펙터 창에서 값이 성공적으로 변경되었을 때 호출되는 함수
    /// </summary>
    private void OnValidate()
    {
        
        SphereCollider col = GetComponent<SphereCollider>();
        if (col != null)
        {
            col.radius = sightRadius;
        }
    }

    private void Update()
    {
        LookTarget();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            target = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            target = null;
        }
    }

    private void LookTarget()
    {
        if (target != null)
        {
            //{보간을 사용한 경우 ( 감속하며 회전) 
            //// 총구(barrel)를 플레이어쪽으로 돌려야 함
            //Vector3 dir = target.position - barrelBody.position;    //  총구에서 플레이어의 위치로 가는 방향벡터 계산
            //dir.y = 0;      // 방향 벡터에서 y축의 영향을 제거 => xz 평면상의 방향만 남음

            //// turnSpeed초에 걸쳐서 0->로 변경된다.시작점에서 도착점까지 걸리는 시간이 turnSpeed초)
            //dir = Vector3.Lerp(barrelBody.forward, dir, turnSpeed * Time.deltaTime);    

            //barrelBody.rotation = Quaternion.LookRotation(dir); // 최종적인 방향을 바라보는 회전을 만들어서 총몸에 적용
            //}여기까지

            // 각도를 사용하는 경우(등속도로 회전)(변수 3개 추가함)
            Vector3 dir = target.position - barrelBody.position;    //  총구에서 플레이어의 위치로 가는 방향벡터 계산
            dir.y = 0;

            targetAngle = Vector3.SignedAngle(initialForward, dir, barrelBody.up);
            //if( Mathf.Abs(targetAngle) < 180.0f)
            //{
            //    if(targetAngle>0)
            //    {
            //        targetAngle = -360.0f + targetAngle;
            //    }
            //    else
            //    {
            //        targetAngle = 360.0f - targetAngle;
            //    }
            //    //targetAngle = 360.0f - Mathf.Abs(targetAngle);
            //}

            if (currentAngle < targetAngle)
            {
                currentAngle += (turnSpeed * Time.deltaTime);
                currentAngle = Mathf.Min(currentAngle, targetAngle);
            }
            else if (currentAngle > targetAngle)
            {
                currentAngle -= (turnSpeed * Time.deltaTime);
                currentAngle = Mathf.Max(currentAngle, targetAngle);
            }

            Vector3 targetDir = Quaternion.Euler(0, currentAngle, 0) * initialForward;
            barrelBody.rotation = Quaternion.LookRotation(targetDir);
        }
    }

    private void Fire()
    {
        // 총알을 발사한다.
        // 총알 프리팹. 총알이 발사될 방향과 위치. 총알이 발사되는 주기
        Instantiate(bulletPrefab, fireTransform.position, fireTransform.rotation);
    }

    IEnumerator PeriodFire()
    {
        while (true)
        {
            Fire();
            yield return new WaitForSeconds(fireInterval);
        }
}
