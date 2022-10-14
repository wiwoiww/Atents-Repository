using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomIdleSelector : StateMachineBehaviour
{
    //OnStateExit is called before OnStateExit is called on any state inside this state machine
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!animator.IsInTransition(0))    // 0번째 레이어가 트랜지션 중인지 아닌지 확인해서 아닐경우 아래 코드 실행
        {
            animator.SetInteger("IdleSelect", RandomSelect());
        }
    }

    int RandomSelect()
    {
        int select = Random.Range(0, 5);
        Debug.Log(select);
        
        return select;
    }
}
