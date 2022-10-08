using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LaserBlast : SkillHitCheck
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private float DMG;
    [SerializeField] private float damage_ratio;
    [SerializeField] private float holding_time;
    [SerializeField] private float knock_back_rate;
    [SerializeField] private int coolTime;
    [SerializeField] Slider slider;
    public bool onActive;
    private Collider coll;
    // Start is called before the first frame update
    private void Awake()
    {
        coll = GetComponent<Collider>();
        Damage = DMG;
        Knock_back = knock_back_rate;
        coll.enabled = false;
        onActive = false;
        StartCoroutine(LoadCoolTime());
    }

    private void FixedUpdate()
    {
        slider.maxValue = coolTime;
        if (Message.Instance().ReceiveMessage() == GameState.Playing && onActive)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                UseItem();
                onActive = false;
            }
        }
    }
    //사용 아이템 획득처는 수성이와 상의 필요 => 시간 기준으로 일정 시간 지나면 다시 차게
    public void GetActiveItem()
    {
        onActive = true;
    }
    void UseItem()
    {
        StartCoroutine(DoActive());
        StartCoroutine(LoadCoolTime());
    }
    IEnumerator LoadCoolTime()
    {
        int temp_count = 0;
        while (true)
        {
            
            slider.value = temp_count;
            if (Message.Instance().ReceiveMessage() == GameState.Playing)
            {
                temp_count++;
                if (temp_count > coolTime)
                {
                    GetActiveItem();
                    break;
                }
                
            }
            yield return new WaitForSeconds(1.0f);

        }
        
    }
    IEnumerator DoActive()
    {

        float currTime = 0;
        GameObject temp_laser = Instantiate(prefab, transform);
        temp_laser.transform.localScale = transform.localScale;
        while (true)
        {
            coll.enabled = false;

            yield return new WaitForSeconds(damage_ratio / 2);
            if (Message.Instance().ReceiveMessage() == GameState.Playing)
            {
                coll.enabled = true;
            }
            yield return new WaitForSeconds(damage_ratio / 2);
            currTime += damage_ratio;
            if (currTime >= holding_time)
            {
                break;
            }
        }
        coll.enabled = false;
        Destroy(temp_laser);
        yield return null;
    }
}
