using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [SerializeField] PlayerCtrl playerCtrl;
    [SerializeField] float cam_hight;
    [SerializeField] float adjust_x;
    [SerializeField] float adjust_z;
    Transform camTransform;
    // Start is called before the first frame update
    void Start()
    {
        camTransform = GetComponent<Transform>();  
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        FollowPlayer();
    }
    private void FollowPlayer()
    {
        Vector3 tempPos = new Vector3(
             playerCtrl.transform.position.x + adjust_x,
             cam_hight,
             playerCtrl.transform.position.z + adjust_z);
        camTransform.position = Vector3.Lerp(camTransform.position, tempPos, Time.deltaTime * 5);
    }
}
