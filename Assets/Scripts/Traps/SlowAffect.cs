using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowAffect : MonoBehaviour
{
    [HideInInspector] public float rate_value;
    [HideInInspector] public float time_value;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DoSlow());
    }
    IEnumerator DoSlow()
    {

        float tempspeed = PlayerPrefs.GetFloat("p_Speed");
        PlayerPrefs.SetFloat("p_Speed", tempspeed - rate_value);
        yield return new WaitForSeconds(time_value);
        PlayerPrefs.SetFloat("p_Speed", tempspeed);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
