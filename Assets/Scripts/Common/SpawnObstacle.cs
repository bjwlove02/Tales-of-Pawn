using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    [SerializeField] GameObject[] obstacles;
    [SerializeField] Transform target_tr;
    [SerializeField] int spawnNum = 10;
    private int currNum;
    private void LateUpdate()
    {
        if (currNum < spawnNum)
        {
            Instantiate(obstacles[currNum]);
        }
    }
    private void InstantiateObstacle(int obstacle_num)
    {
        GameObject temp_obj =
            Instantiate(obstacles[currNum]
            ,target_tr.position+getRandom()
            ,Quaternion.identity);
        currNum++;
    }
    private void checkNum()
    {

    }
    private Vector3 getRandom()
    {
        float pos_x = Random.Range(-10, 10);
        float pos_z = Random.Range(-10, 10);
        return new Vector3(pos_x, 0, pos_z);
    }
}
