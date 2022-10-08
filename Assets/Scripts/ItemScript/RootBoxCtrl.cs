using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum EquipmentType
{
    Melee = 0,
    ShotGun = 1,
    CircleBomb = 2,
    FireBall = 3,
    Meteor = 4,
    Heart = 5,
    Lightning = 6,
    Stopwatch = 7,
    Sword = 8
}
public class RootBoxCtrl : MonoBehaviour
{
    [SerializeField] private Skills[] _skills;
    [SerializeField] private Accessories[] accessories;
    [SerializeField] private GameObject[] weapon_Box;
    [SerializeField] private GameObject[] accessory_Box;
    [SerializeField] List<GameObject> temp_Equitment_arry;

    public void ActivePanel()
    {
        gameObject.SetActive(true);
        
        temp_Equitment_arry = new List<GameObject>();

        for (int i = 0; i < weapon_Box.Length; i++)
        {
            weapon_Box[i].SetActive(false);
            weapon_Box[i].GetComponent<RootBoxBtn>().ActiveButton();
        }
        for (int i = 0; i < accessory_Box.Length; i++)
        {
            accessory_Box[i].SetActive(false);
            accessory_Box[i].GetComponent<RootBoxBtn>().ActiveButton();
        }

        for (int i = 0; i < _skills.Length; i++)
        {
            if (_skills[i].isActive && !_skills[i].max_LVup)
            {
                temp_Equitment_arry.Add(weapon_Box[i]);
            }
        }
        for (int i = 0; i < accessories.Length; i++)
        {
            if (accessories[i].isActive && !accessories[i].max_LVup)
            {
                temp_Equitment_arry.Add(accessory_Box[i]);
            }
        }
        int temp = Random.Range(0, temp_Equitment_arry.Count);
        temp_Equitment_arry[temp].SetActive(true);
    }

    public void PanelClose()
    {
        gameObject.SetActive(false);
    }
    public void DisableBtn()
    {
        for (int i = 0; i < weapon_Box.Length; i++)
        {
            weapon_Box[i].GetComponent<Button>().enabled = false;
        }
    }
}
