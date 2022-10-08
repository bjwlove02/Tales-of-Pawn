using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpChaser : MonoBehaviour
{
    Transform playertr;
    [SerializeField] float maxSpeed;
    [SerializeField] float distance_lim;
    private void Awake()
    {
        playertr = GameObject.FindWithTag("Player").transform;
    }
    private void FixedUpdate()
    {
        Chase(playertr.position, maxSpeed, distance_lim);
    }
    public void Chase(Vector3 targetPos, float MaxSpeed, float distance_limit)
    {
        float distance = (targetPos - this.transform.position).magnitude;
        targetPos.y = 1;

        if (distance > distance_limit)
        {
            Vector3 moveDir = (targetPos - transform.position).normalized;
            transform.position += moveDir * maxSpeed * Time.deltaTime;
            MathProblem.Instance().angleCal(transform, moveDir);
        }
    }
}
