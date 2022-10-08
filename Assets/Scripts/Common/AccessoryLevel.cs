using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessoryLevel : MonoBehaviour
{
    private PlayerAccessorys playerAccessorys;

    public int heartLevel = 0;
    public int swordLevel = 0;
    public int lightningLevel = 0;
    public int stopwatchLevel = 0;

    private void Awake()
    {
        playerAccessorys = FindObjectOfType<PlayerAccessorys>();

        PlayerPrefs.SetInt("HeartLevel", heartLevel);
        PlayerPrefs.SetInt("SwordLevel", swordLevel);
        PlayerPrefs.SetInt("LightningLevel", lightningLevel);
        PlayerPrefs.SetInt("StopwatchLevel", stopwatchLevel);
    }

    public void HeartLevelUp()
    {
        heartLevel += 1;
        Heart heart = FindObjectOfType<Heart>();
        PlayerPrefs.SetInt("HeartLevel", heartLevel);
        playerAccessorys.ActiveAccessory(Accessory.Heart);
    }

    public void SwordLevelUp()
    {
        swordLevel += 1;
        Sword sword = FindObjectOfType<Sword>();
        PlayerPrefs.SetInt("SwordLevel", swordLevel);
        playerAccessorys.ActiveAccessory(Accessory.Sword);
    }

    public void LightningLevelUp()
    {
        lightningLevel += 1;
        Lightning lightning = FindObjectOfType<Lightning>();
        PlayerPrefs.SetInt("LightningLevel", lightningLevel);
        playerAccessorys.ActiveAccessory(Accessory.Lightning);
    }

    public void StopwatchLevelUp()
    {
        stopwatchLevel += 1;
        Stopwatch stopwatch = FindObjectOfType<Stopwatch>();
        PlayerPrefs.SetInt("StopwatchLevel", stopwatchLevel);
        playerAccessorys.ActiveAccessory(Accessory.Stopwatch);
    }
}
