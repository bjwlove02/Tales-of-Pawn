using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteMap : MonoBehaviour
{
    [SerializeField]private GameObject player;      //player ������Ʈ
    [SerializeField]private Transform main_groundTr;//9���� ground ������Ʈ �� �߰� ������Ʈ
    private Transform groundChunkTr;                //ground ���
    private float map_width;                        //main ground �� ���� ����
    private float map_height;                       //main ground �� ���� ����


    private void Awake()
    {
        groundChunkTr = GetComponent<Transform>(); 
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //�÷��̾� ĳ���Ͱ� main ground ������Ʈ�� ��輱�� �Ѿ �� �Ѿ �������� groundChunk �̵�
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
        //�߰��� ���� ũ�⸦ ���Ƿ� ��ȭ��Ű�� ���� Ȯ���ϱ� ����, scale ���
        map_width = main_groundTr.localScale.x * 10;
        map_height = main_groundTr.localScale.z * 10;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        CheckPos();
    }
}
