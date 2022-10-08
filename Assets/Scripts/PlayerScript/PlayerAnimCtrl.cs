using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimCtrl : MonoBehaviour
{
    [SerializeField] Animator playerAnimator;

    //함수는 PlayerCtrl에서 참조(관리를 쉽게 하기 위함)
    public void Animation_Move(bool isMove)
    {
        playerAnimator.SetBool("IsMove", isMove);
    }

    public void Animation_IsDie(bool isDie)
    {
        playerAnimator.SetBool("IsDie", isDie);
    }

    public void Animation_Damaged()
    {
        playerAnimator.SetTrigger("IsDamage");
    }
    public void Animation_Melee_Motion()
    {
        playerAnimator.SetTrigger("MeleeAttack");
    }
}
