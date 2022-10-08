using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DMGCtrl : MonoBehaviour
{
    public float characterHP;
    [SerializeField] private float dmgDelay = 0.1f;
    public bool isDie = false;

    public float GetHP()
    {
        return characterHP;
    }
    public void ReceiveDamage(float dmg)
    {
        if (!isDie)
        {
            characterHP -= dmg;
            if (characterHP <= 0)
            {
                isDie = true;
            }
        }
    }
}
