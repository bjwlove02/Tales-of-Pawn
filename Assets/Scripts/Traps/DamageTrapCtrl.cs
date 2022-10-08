using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTrapCtrl : Traps
{
    [SerializeField] public float DMG;
    [SerializeField] public float range;
    [SerializeField] GameObject explode;
    Collider coll;

    private void Start()
    {
        coll = GetComponent<Collider>();
        transform.localScale = new Vector3(range, 1, range);
        coll.enabled = false;
        StartCoroutine(DoActive());
    }
    private void Update()
    {
        transform.Rotate(new Vector3(0, 10.0f, 0) * Time.deltaTime);
    }
    IEnumerator DoActive()
    {
        yield return new WaitForSeconds(1.5f);
        SoundManager.instance.SFXPlay("DMGTrap", audioSource);
        Instantiate(explode, this.transform);
        coll.enabled = true;
        yield return new WaitForSeconds(0.5f);
        coll.enabled = false;

        yield return new WaitForSeconds(3.0f);
        trap_end = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<DMGCtrl>().ReceiveDamage(DMG);
            coll.enabled = false;
        }
    }
}
