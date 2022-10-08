using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootFireBall : SkillHitCheck
{
            
   
    [HideInInspector]public float deadT;
    [HideInInspector]public float speed;
    [HideInInspector] public int penetration_num;
    Rigidbody rb;
    Collider collider_col;
    // Start is called before the first frame update
    protected void Awake()
    {
        collider_col = GetComponent<Collider>();
        //rb = GetComponent<Rigidbody>();
    }
    protected void Start()
    {
        collider_col.enabled = true;
        Destroy(gameObject, deadT);
        // rb.AddForce(transform.up * -speed);
        StartCoroutine(Shoot());
    }
    IEnumerator Shoot()
    {
        while (collider_col.enabled)
        {
            transform.position += transform.forward * speed * Time.deltaTime;

            yield return null;
        }
        yield return null;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" || other.tag == "Skill"|| other.tag=="Item")
        {
        }
        else
        {
            if (penetration_num <= 0)
            {
                collider_col.enabled = false;
                Destroy(gameObject);
            }
            else
            {
                penetration_num--;
            }
        }
    }
}
