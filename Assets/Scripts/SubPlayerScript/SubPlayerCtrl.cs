using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum ATKType
{
    atk0,
    atk1,
    atk2,
    atk3,
    atk4
}
public class SubPlayerCtrl : MonoBehaviour
{
    private bool isTrace;

    /*[HideInInspector]*/ public Transform subChar_Tr;
    [SerializeField] ATKType atkAnim_Type;
    [SerializeField] GameObject atkVFX;
    [SerializeField] float trace_range_Half_Rad = 0;
    [SerializeField] private float speed;
    private Animator animator;
    
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void LateUpdate()
    {
        if (Message.Instance().ReceiveMessage() != GameState.Pause)
        {
            Chase();
            AnimCheck();
        }
    }
    public void Cast_Anim()
    {
        switch (atkAnim_Type)
        {
            case ATKType.atk0:
                animator.SetTrigger("ATK0");
                break;
            case ATKType.atk1:
                animator.SetTrigger("ATK1");
                break;
            case ATKType.atk2:
                animator.SetTrigger("ATK2");
                break;
            case ATKType.atk3:
                animator.SetTrigger("ATK3");
                break;
            case ATKType.atk4:
                animator.SetTrigger("ATK4");
                break;
        }
        if (atkVFX != null)
        {
            Instantiate(atkVFX, transform.position, atkVFX.transform.rotation);
        }
        
    }
    bool CalDistanceTo_Player()
    {
        float temp_distance =
            (subChar_Tr.position - transform.position).magnitude;
        if (temp_distance > trace_range_Half_Rad)
        {
            isTrace = true;
            return true;
        }
        else
        {
            isTrace=false;
            return false;
        }
    }
    void Chase()
    {
        if (CalDistanceTo_Player())
        {
            Vector3 temp_MoveDir = (subChar_Tr.position - transform.position).normalized;
            transform.position += temp_MoveDir * speed * Time.deltaTime;
            MathProblem.Instance().angleCal(transform, temp_MoveDir);
        }

    }
    void AnimCheck()
    {
        if (isTrace)
        {
            animator.SetBool("IsTrace", true);
        }
        else
        {
            animator.SetBool("IsTrace", false);
        }
    }
}
