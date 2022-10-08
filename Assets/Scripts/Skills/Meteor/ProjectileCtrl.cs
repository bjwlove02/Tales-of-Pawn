using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    [HideInInspector] public Vector3 force_to_target;
    [SerializeField]float speed;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void LateUpdate()
    {
        rb.AddForce(force_to_target.normalized*speed);
    }
}
