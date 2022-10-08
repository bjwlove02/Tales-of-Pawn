using UnityEngine;

public class GetItem : MonoBehaviour
{
    public float exp;
    public float gold;

    GameManager gameManager;
    InGameUICtrl inGameUICtrl;
    PlayerDMGCtrl playerDMGCtrl;

    public AudioSource expAudioSource;
    public AudioSource goldAudioSource;
    public AudioSource foodAudioSource;

    private void Awake()
    {
        inGameUICtrl = GameObject.Find("InGameUI").GetComponent<InGameUICtrl>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        playerDMGCtrl = GetComponent<PlayerDMGCtrl>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            Item item = other.GetComponent<Item>();
            switch (item.type)
            {
                case Item.Type.Exp:
                    exp += item.value;
                    SoundManager.instance.SFXPlay("Exp", expAudioSource);
                    break;
                case Item.Type.Gold:
                    gold += item.value;
                    gameManager.getGold++;
                    SoundManager.instance.SFXPlay("Gold", goldAudioSource);
                    break;
                case Item.Type.Food:
                    playerDMGCtrl.characterHP += item.value;
                    playerDMGCtrl.GetHP();
                    SoundManager.instance.SFXPlay("Food", foodAudioSource);
                    if (playerDMGCtrl.characterHP > PlayerPrefs.GetInt("p_HP"))
                        playerDMGCtrl.characterHP = PlayerPrefs.GetInt("p_HP");
                    break;
                case Item.Type.Box:
                    //랜덤 박스 선택 패널 활성화
                    inGameUICtrl.ActiveRandomBox();
                    gameManager.GamePause();
                    break;
            }
            Destroy(other.gameObject);
        }
    }
}
