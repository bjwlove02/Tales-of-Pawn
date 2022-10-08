using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerGold : MonoBehaviour
{
    public GameObject GoldPanel;
    public Text GoldText;
    public int beforeGameGold;
    public int allPlayerGold;
    public int currPlayerGold;

    private void Awake()
    {
        GoldText.text = PlayerPrefs.GetInt("CurrPlayerGold").ToString();
    }

    private void Start()
    {
        currPlayerGold = PlayerPrefs.GetInt("CurrPlayerGold");
        allPlayerGold = PlayerPrefs.GetInt("AllPlayerGold");
        GoldText.text = currPlayerGold.ToString();
    }

    public void UpdateGold()
    {
        PlayerPrefs.SetInt("CurrPlayerGold", currPlayerGold);
        GoldText.text = currPlayerGold.ToString();
    }
}
