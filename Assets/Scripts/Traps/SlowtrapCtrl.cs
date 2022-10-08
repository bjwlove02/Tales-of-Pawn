using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowtrapCtrl :Traps
{
    [SerializeField] public float slow_rate;
    [SerializeField] public float hold_time;
    [SerializeField] public float range;
    [SerializeField] GameObject explode;
    [SerializeField] GameObject slowAffectOBJ;
    Collider coll;

    private void Start()
    {
        coll=GetComponent<Collider>();
        transform.localScale = new Vector3(range, 1, range);
        coll.enabled = false;
        trap_end = false;
        StartCoroutine(DoActive());
    }
    private void Update()
    {
        transform.Rotate(new Vector3(0,10.0f,0)*Time.deltaTime);
    }
    IEnumerator DoActive()
    {
        yield return new WaitForSeconds(2.0f);
        SoundManager.instance.SFXPlay("SlowTrap", audioSource);
        Instantiate(explode,this.transform);
        coll.enabled = true;
        yield return new WaitForSeconds(5.0f);
        trap_end =true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            coll.enabled = false;
            StopCoroutine(DoActive());
            GameObject tempObj = Instantiate(slowAffectOBJ);
            tempObj.GetComponent<SlowAffect>().rate_value = slow_rate;
            tempObj.GetComponent<SlowAffect>().time_value = hold_time;
        }
    }

}
