using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

#if UNITY_EDITER
using UnityEditor;
#endif

public class Player : MonoBehaviour, IBattle, IHealth, IMana
{
    /// <summary>
    /// 무기에 붙어있는 파티클 시스템 컴포넌트
    /// </summary>
    ParticleSystem weaponPS;

    /// <summary>
    /// 무기가 붙어있을 게임오브젝트의 트랜스폼
    /// </summary>
    Transform weapon_r;

    /// <summary>
    /// 방패가 붙어있을 게임 오브젝트의 트랜스폼
    /// </summary>
    Transform weapon_l;

    /// <summary>
    /// 무기가 데미지를 주는 영역의 트리거
    /// </summary>
    Collider weaponBlade;

    Animator anim;  // 애니메이터 컴포넌트

    public float attackPower = 10.0f;      // 공격력
    public float defencePower = 3.0f;      // 방어력
    public float maxHP = 100.0f;    // 최대 HP
    float hp = 100.0f;              // 현재 HP

    public float maxMP = 100.0f;    // 최대 MP
    float mp = 100.0f;              // 현재 MP

    bool isAlive = true;            // 살았는지 죽었는지 확인용

    Inventory inven;

    public float itemPickupRange = 2.0f;

    int money = 0;

    // 프로퍼티 ------------------------------------------------------------------------------------
    public float AttackPower => attackPower;

    public float DefencePower => defencePower;

    public float HP
    {
        get => hp;
        set
        {
            if (isAlive && hp != value) // 살아있고 HP가 변경되었을 때만 실행
            {
                hp = value;

                if (hp < 0)
                {
                    Die();
                }

                hp = Mathf.Clamp(hp, 0.0f, maxHP);

                onHealthChange?.Invoke(hp / maxHP);
            }
        }
    }

    public float MaxHP => maxHP;
    public bool IsAlive => isAlive;
    public float MP
    {
        get => mp;
        set
        {
            if (isAlive && mp != value) // 살아있고 mp가 변경되었을 때만 실행
            {
                mp = Mathf.Clamp(value, 0.0f, maxMP);

                onManaChange?.Invoke(mp / maxMP);
            }
        }
    }
    public float MaxMP => maxMP;

    public int Money
    {
        get => money;
        set
        {
            if(money != value)
            {
                money = value;
                onMoneyChange?.Invoke(money);
            }
        }
    }

    // 델리게이트 ----------------------------------------------------------------------------------
    public Action<int> onMoneyChange;   // 돈이 변경되면 실행될 델리게이트

    public Action<float> onHealthChange { get; set; }

    public Action<float> onManaChange { get; set; } 

    public Action onDie { get; set; }

    // --------------------------------------------------------------------------------------------

    private void Awake()
    {
        anim = GetComponent<Animator>();

        weapon_r = GetComponentInChildren<WeaponPosition>().transform;  // 무기가 붙는 위치를 컴포넌트의 타입으로 찾기
        weapon_l = GetComponentInChildren<ShieldPositon>().transform;   // 방패가 붙는 위치를 컴포넌트의 타입으로 찾기

        // 장비교체가 일어나면 새로 설정해야 한다.
        weaponPS = weapon_r.GetComponentInChildren<ParticleSystem>();   // 무기에 붙어있는 파티클 시스템 가져오기
        weaponBlade = weapon_r.GetComponentInChildren<Collider>();      // 무기의 충돌 영역 가져오기

        inven = new Inventory(this);
    }

    private void Start()
    {
        hp = maxHP;
        isAlive = true;

        GameManager.Inst.InvenUI.InitializeInventory(inven);
    }

    /// <summary>
    /// 무기의 이팩트를 키고 끄는 함수
    /// </summary>
    /// <param name="on">true면 무기 이팩트를 켜고, flase면 무기 이팩트를 끈다.</param>
    public void WeaponEffectSwitch(bool on)
    {
        if (weaponPS != null)
        {
            if (on)
            {
                weaponPS.Play();    // 파티클 이팩트 재생 시작
            }
            else
            {
                weaponPS.Stop();    // 파티클 이팩트 재생 중지
            }
        }
    }

    /// <summary>
    /// 무기가 공격 행동을 할 때 무기의 트리거 켜는 함수
    /// </summary>
    public void WeaponBladeEnable()
    {
        if (weaponBlade != null)
        {
            weaponBlade.enabled = true;
        }
    }

    /// <summary>
    /// 무기가 공격 행동이 끝날 때 무기의 트리거를 끄는 함수
    /// </summary>
    public void WeaponBladeDisable()
    {
        if (weaponBlade != null)
        {
            weaponBlade.enabled = false;
        }
    }

    /// <summary>
    /// 무기와 방패를 표시하거나 표시하지 않는 함수
    /// </summary>
    /// <param name="isShow">ture면 표시하고, false면 표시하지 않는다.</param>
    public void ShowWeaponAndShield(bool isShow)
    {
        weapon_r.gameObject.SetActive(isShow);
        weapon_l.gameObject.SetActive(isShow);
    }

    /// <summary>
    /// 공격용 함수
    /// </summary>
    /// <param name="target">공격할 대상</param>
    public void Attack(IBattle target)
    {
        target?.Defence(AttackPower);
    }

    /// <summary>
    /// 방어용 함수
    /// </summary>
    /// <param name="damage">현재 입은 데미지</param>
    public void Defence(float damage)
    {
        if (isAlive)                // 살아있을 때만 데미지 입음.
        {
            anim.SetTrigger("Hit"); // 피격 애니메이션 재생            
            HP -= (damage - DefencePower);  // 기본 공식 : 실제 입는 데미지 = 적 공격 데미지 - 방어력
        }
    }

    /// <summary>
    /// 죽었을 때 실행될 함수
    /// </summary>
    public void Die()
    {
        isAlive = false;
        ShowWeaponAndShield(true);
        anim.SetLayerWeight(1, 0.0f);       // 애니메이션 레이어 가중치 제거
        anim.SetBool("IsAlive", isAlive);   // 죽었다고 표시해서 사망 애니메이션 재생
        onDie?.Invoke();
    }

    /// <summary>
    /// 플레이어 주변의 아이템을 획득하는 함수
    /// </summary>
    public void ItemPickup()
    {
        Collider[] items = Physics.OverlapSphere(transform.position, itemPickupRange, LayerMask.GetMask("Item"));

        foreach(var itemCollider in items)
        {
            Item item = itemCollider.gameObject.GetComponent<Item>();

            // 즉시 사용해야 하는 아이템인지 확인
            IConsumable consumable = item.data as IConsumable;
            if(consumable != null)
            {
                // 즉시 사용되는 아이템
                consumable.Consume(this.gameObject);        // 즉시 사용
                Destroy(itemCollider.gameObject);           // 삭제
            }
            else
            {
                // 인벤토리에 들어갈 아이템
                if (inven.AddItem(item.data))           // 인벤토리에 추가하고, 추가가 성공하면
                {
                    Destroy(itemCollider.gameObject);   // 아이템 오브젝트 삭제하기
                }
            }
        }
    }

    /// <summary>
    /// 마나 회복용 함수
    /// </summary>
    /// <param name="totalRegen">전체 회복량</param>
    /// <param name="duration">전체 회복하는데 걸리는 시간</param>
    public void ManaRegenerate(float totalRegen, float duration)
    {
        StartCoroutine(ManaRegeneration(totalRegen, duration));
        //StartCoroutine(ManaRegeneration_Tick(totalRegen, duration));
    }

    /// <summary>
    /// 마나 회복용 코루틴
    /// </summary>
    /// <param name="totalRegen">전체 회복량</param>
    /// <param name="duration">전체 회복하는데 걸리는 시간</param>
    /// <returns></returns>
    IEnumerator ManaRegeneration(float totalRegen, float duration)
    {
        //float timeStart = Time.realtimeSinceStartup;    // 시작 시간 기록
        //Debug.Log($"Regen Start");
        float regenPerSec = totalRegen / duration;       // 초당 회복량 계산
        float timeElapsed = 0.0f;                        // 진행 시간 기록용
        while(timeElapsed < duration)                    // 진행시간이 duration을 지날 때까지 반복
        {
            timeElapsed += Time.deltaTime;               // 진행시간 누적시키기
            MP += Time.deltaTime * regenPerSec;          // MP를 1초에 초당 회복량만큼 증가
            yield return null;                           // 다음 프레임 시작까지 대기
        }
        //Debug.Log($"Regen End time : ({Time.realtimeSinceStartup - timeStart})");   // 전체 걸린 시간 측정용
    }

    /// <summary>
    /// 틱마다 마나가 회복되는 코루틴
    /// </summary>
    /// <param name="totalRegen">전체 회복량</param>
    /// <param name="duration">전체 회복하는데 걸리는 시간</param>
    /// <returns></returns>
    IEnumerator ManaRegeneration_Tick(float totalRegen, float duration)
    {
        float tick = 1.0f;                                  // 1번 회복하는 시간 간격(1초에 한번씩 회복이 발생한다)
        int regenCount = Mathf.FloorToInt(duration / tick); // 전체 회복 횟수
        float regenPerTick = totalRegen / regenCount;       // 한 틱당 회복량
        for(int i=0; i<regenCount;i++)                      // 전체 반복 횟수만큼 for 진행
        {
            MP += regenPerTick;                             // 한 틱당 회복량을 추가
            //Debug.Log($"Regen : {regenPerTick}");
            yield return new WaitForSeconds(tick);          // 다음 틱까지 대기
        }
    }

#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Handles.DrawWireDisc(transform.position, transform.up, itemPickupRange);
    }
#endif


}

