using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteMap : MonoBehaviour
{
    [SerializeField]private GameObject player;      //player 오브젝트
    [SerializeField]private Transform main_groundTr;//9개의 ground 오브젝트 중 중간 오브젝트
    private Transform groundChunkTr;                //ground 덩어리
    private float map_width;                        //main ground 의 가로 넓이
    private float map_height;                       //main ground 의 세로 넓이


    private void Awake()
    {
        groundChunkTr = GetComponent<Transform>(); 
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //플레이어 캐릭터가 main ground 오브젝트의 경계선을 넘어갈 시 넘어간 방향으로 groundChunk 이동
    public void CheckPos()  
    {
        if (player.transform.position.z > groundChunkTr.position.z+(map_width / 2))
        {
            groundChunkTr.position += new Vector3(0, 0, map_width);
        }
        else if(player.transform.position.z < groundChunkTr.position.z - (map_width / 2))
        {
            groundChunkTr.position += new Vector3(0, 0, -map_width);
        }
        if (player.transform.position.x > groundChunkTr.position.x + (map_height / 2))
        {
            groundChunkTr.position += new Vector3(map_height, 0, 0);
        }
        else if (player.transform.position.x < groundChunkTr.position.x - (map_height / 2))
        {
            groundChunkTr.position += new Vector3(-map_height, 0, 0);
        }
    }

    private void Update()
    {
        //중간에 맵의 크기를 임의로 변화시키는 것을 확인하기 위함, scale 사용
        map_width = main_groundTr.localScale.x * 10;
        map_height = main_groundTr.localScale.z * 10;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        CheckPos();
    }
}
