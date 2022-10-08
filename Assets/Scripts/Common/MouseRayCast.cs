using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRayCast : MonoBehaviour
{
    [SerializeField] Camera mainCam;
    [SerializeField] GameObject targetTerrian;
    [SerializeField] GameObject testCube;
    Transform raycastTransform;
    // Start is called before the first frame update
    void Start()
    {
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //RaycastHit hit;
        //Ray temp_ray = mainCam.ScreenPointToRay(Input.mousePosition);
        //if (Physics.Raycast(temp_ray, out hit))
        //{

        //        raycastTransform = hit.transform;
        //        testCube.transform.position = hit.transform.position;
        //    Debug.Log(hit.transform.position);
        //}
       
        Vector3 point =
            Camera.main.ScreenToWorldPoint(
                new Vector3(
                    Input.mousePosition.x
                    , Input.mousePosition.y
                    , -Camera.main.transform.position.z));
        testCube.transform.position = new Vector3(
                    Input.mousePosition.x * 50 / 1920
                    , Input.mousePosition.y * 50 / 1080
                    , -Camera.main.transform.position.z);
            //new Vector3(mousePos.x*50/1920,1.0f,mousePos.y*50/1080);
        //stickInCamera();
    }
    void stickInCamera()
    {
        Vector3 pos = Camera.main.WorldToViewportPoint(testCube.transform.position);

        if (pos.x < 0f) pos.x = 0f;
        if (pos.x > 1f) pos.x = 1f;
        if (pos.y < 0f) pos.y = 0f;
        if (pos.y > 1f) pos.y = 1f;

        testCube.transform.position = pos;
    }
}
