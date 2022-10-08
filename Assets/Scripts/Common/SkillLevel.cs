using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillLevel : MonoBehaviour
{
    public int meleeAttackLevel = 0;
    public int shotGunLevel = 0;
    public int circleBombLevel = 0;
    public int fireBallLevel = 0;
    public int meteorLevel = 0;
    private void Awake()
    {
        PlayerPrefs.SetInt("MeleeAttackLevel", meleeAttackLevel);
        PlayerPrefs.SetInt("ShotGunLevel", shotGunLevel);
        PlayerPrefs.SetInt("CircleBombLevel", circleBombLevel);
    }

    public void MeleeAttackLevelUp()
    {
        meleeAttackLevel += 1;
        PlayerPrefs.SetInt("MeleeAttackLevel", meleeAttackLevel);
    }

    public void ShotGunLevelUp()
    {
        shotGunLevel += 1;
        PlayerPrefs.SetInt("ShotGunLevel", shotGunLevel);
    }
    public void CircleBombLevelUp()
    {
        circleBombLevel += 1;
        PlayerPrefs.SetInt("CircleBombLevel", circleBombLevel);
    }

    public void FireBallLevelUP()
    {
        fireBallLevel += 1;
        PlayerPrefs.SetInt("FireBallLevel", fireBallLevel);
    }
    public void MeteorLevelUp()
    {
        meteorLevel += 1;
        PlayerPrefs.SetInt("MeteorLevel", meteorLevel);
    }
}
