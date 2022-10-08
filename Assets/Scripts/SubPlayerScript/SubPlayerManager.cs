using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SubPlayerType
{
    Archer,
    BlackKnight,
    NANA,
    RedMage,
    SwordMan
}
//in GameManager
public class SubPlayerManager : MonoBehaviour
{
    public GameObject[] subPlayer_prefabs;
    public Transform[] pos_Tr;

    public void Instantiate_obj(SubPlayerType subPlayer)
    {
        GameObject temp_obj = Instantiate(subPlayer_prefabs[(int)subPlayer]
            , pos_Tr[(int)subPlayer].position
            , Quaternion.identity);
        temp_obj.GetComponent<SubPlayerCtrl>().subChar_Tr = pos_Tr[(int)subPlayer];
        temp_obj.transform.parent = transform;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
