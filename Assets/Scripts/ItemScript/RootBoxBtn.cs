using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

enum BoxType
{
    Normal = 0,
    Epic = 1,
    Rare = 2
}

public class RootBoxBtn : MonoBehaviour
{
    [SerializeField] Sprite closedBox;
    [SerializeField] Sprite openedBox;
    [SerializeField] GameObject particle_normal;
    [SerializeField] EquipmentType equipmentType;
    [SerializeField] GameObject itemImage;

    GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        GetComponent<Button>().onClick.AddListener(Clicked);
        itemImage.SetActive(false);
    }

    public void ActiveButton()
    {
        itemImage.SetActive(false);
        this.GetComponent<Image>().sprite = closedBox;
        this.GetComponent<Button>().enabled = true;
    }

    private void ActiveVFX()
    {
        GameObject temp = Instantiate(particle_normal, this.transform.position, this.transform.rotation);
        temp.transform.parent = this.transform;
        Destroy(temp, 3.0f);
    }

    private void Clicked()
    {
        StartCoroutine(PrintImage());
        this.GetComponent<Image>().sprite = openedBox;
        ActiveVFX();
        if (equipmentType == EquipmentType.Melee)
        {
            player.GetComponent<SkillLevel>().MeleeAttackLevelUp();
        }
        else if (equipmentType == EquipmentType.ShotGun)
        {
            player.GetComponent<SkillLevel>().ShotGunLevelUp();
        }
        else if (equipmentType == EquipmentType.CircleBomb)
        {
            player.GetComponent<SkillLevel>().CircleBombLevelUp();
        }
        else if (equipmentType == EquipmentType.FireBall)
        {
            player.GetComponent<SkillLevel>().FireBallLevelUP();
        }
        else if (equipmentType == EquipmentType.Meteor)
        {
            player.GetComponent<SkillLevel>().MeteorLevelUp();
        }
        else if (equipmentType == EquipmentType.Heart)
        {
            player.GetComponent<AccessoryLevel>().HeartLevelUp();
        }
        else if (equipmentType == EquipmentType.Lightning)
        {
            player.GetComponent<AccessoryLevel>().LightningLevelUp();
        }
        else if (equipmentType == EquipmentType.Stopwatch)
        {
            player.GetComponent<AccessoryLevel>().StopwatchLevelUp();
        }
        else if (equipmentType == EquipmentType.Sword)
        {
            player.GetComponent<AccessoryLevel>().SwordLevelUp();
        }
        this.GetComponent<Button>().enabled = false;
    }

    IEnumerator PrintImage()
    {
        itemImage.SetActive(true);
        yield return new WaitForSeconds(3.0f);
    }
}
