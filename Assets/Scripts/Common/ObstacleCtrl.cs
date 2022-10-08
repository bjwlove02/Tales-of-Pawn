using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCtrl : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabs;
    [SerializeField] private float minRange;
    [SerializeField] private float maxRange;
    [SerializeField] private Transform anchor;
    [SerializeField] private int maxSpawnNum;
    [SerializeField] public List<GameObject> spawned_obstacles;
    Vector3 GetRandPos()
    {
        Vector3 temp_tr=Vector3.zero;
        int RandomPos = Random.Range(0, 4);
        switch (RandomPos)
        {
            case 0:
                temp_tr =
            new Vector3(anchor.position.x+ Random.Range(minRange,maxRange)
            ,0
            ,anchor.position.z+Random.Range(-maxRange,maxRange));
                break;
            case 1:
                temp_tr =
            new Vector3(anchor.position.x - Random.Range(minRange, maxRange)
            , 0
            , anchor.position.z + Random.Range(-maxRange, maxRange));
                break;
            case 2: 
                temp_tr =
            new Vector3(anchor.position.x + Random.Range(-maxRange,maxRange)
            , 0
            , anchor.position.z + Random.Range(minRange, maxRange));
                break;
            case 3:
                temp_tr =
            new Vector3(anchor.position.x + Random.Range(-maxRange, maxRange)
            , 0
            , anchor.position.z - Random.Range(minRange, maxRange));
                break;
        }
        return temp_tr;
       
    }
    
    GameObject GetRandomObstacle()
    {
        return prefabs[Random.Range(0, prefabs.Length)];
    }
    private void Start()
    {
        StartCoroutine(ObstacleSpawn());
    }
    public IEnumerator ObstacleSpawn()
    {
        while (true)
        {
            if (Message.Instance().ReceiveMessage() == GameState.Playing)
            {
                if (spawned_obstacles.Count < maxSpawnNum)
                {
                    GameObject spawned_obj = Instantiate(GetRandomObstacle(), GetRandPos(), Quaternion.identity);
                    spawned_obj.transform.parent= transform;
                    spawned_obstacles.Add(spawned_obj);
                }
                CheckDelete();
            }
            yield return new WaitForSeconds(0.1f);
        }
        yield return null;
    }

    public void CheckDelete()
    {
        for(int i = 0; i < spawned_obstacles.Count; i++)
        {
            if( (anchor.position- spawned_obstacles[i].transform.position).magnitude > maxRange)
            {
                Destroy(spawned_obstacles[i]);
                spawned_obstacles.Remove(spawned_obstacles[i]);

            }
        }
    }
}
