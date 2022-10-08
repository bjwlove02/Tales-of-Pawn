using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapCtrl : MonoBehaviour
{

    [SerializeField] private GameObject[] prefabs;
    [SerializeField] private int start_Delay;
    [SerializeField] private float spawn_term;
    [SerializeField] private float spawnRange;
    [SerializeField] private Transform anchor;
    [SerializeField] private int maxSpawnNum;
    [SerializeField] public List<GameObject> spawned_obstacles;
    Vector3 GetRandPos()
    {
        Vector3 temp_tr=Vector3.zero;

        temp_tr = new Vector3(anchor.position.x + Random.Range(-spawnRange, spawnRange)
            , 0
            , anchor.position.z + Random.Range(-spawnRange, spawnRange));
        return temp_tr;
       
    }
    
    GameObject GetRandomObstacle()
    {
        return prefabs[Random.Range(0, prefabs.Length)];
    }
    private void Start()
    {
        StartCoroutine(StartDelay());
    }
    private void FixedUpdate()
    {
        CheckDelete();
    }
    public IEnumerator StartDelay()
    {
        int temp_count = 0;
        while (true)
        {
            yield return new WaitForSeconds(1.0f);
            temp_count++;
            if (Message.Instance().ReceiveMessage() == GameState.Playing)
            {
                if (temp_count > start_Delay)
                {
                    StartCoroutine(TrapSpawn());
                    break;
                }
            }
        }
    }
    public IEnumerator TrapSpawn()
    {
        while (true)
        {
            if(Message.Instance().ReceiveMessage()!=GameState.Pause)
            {
                if (spawned_obstacles.Count < maxSpawnNum)
                {
                    GameObject spawned_obj = Instantiate(GetRandomObstacle(), GetRandPos(), Quaternion.identity);
                    spawned_obj.transform.parent = transform;
                    spawned_obstacles.Add(spawned_obj);
                }
            }
            yield return new WaitForSeconds(spawn_term);
        }
    }

    public void CheckDelete()
    {
        for(int i = 0; i < spawned_obstacles.Count; i++)
        {
            if( (anchor.position- spawned_obstacles[i].transform.position).magnitude > spawnRange)
            {
                Destroy(spawned_obstacles[i]);
                spawned_obstacles.Remove(spawned_obstacles[i]);

            }
            else if (spawned_obstacles[i].GetComponent<Traps>().trap_end)
            {
                Destroy(spawned_obstacles[i]);
                spawned_obstacles.Remove(spawned_obstacles[i]);
            }
        }
    }
}
