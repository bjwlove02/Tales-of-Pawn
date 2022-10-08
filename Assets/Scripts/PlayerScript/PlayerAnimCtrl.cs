using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimCtrl : MonoBehaviour
{
    [SerializeField] Animator playerAnimator;

    //�Լ��� PlayerCtrl���� ����(������ ���� �ϱ� ����)
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
