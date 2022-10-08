using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightCtrl : MonoBehaviour
{
    GameManager gameManager;
    private int process_state;
    [SerializeField] private float start_Angle;
    [SerializeField] private float end_Angle;
    [SerializeField] private float lerp_value;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        transform.eulerAngles = new Vector3(start_Angle, -50, 0);
        StartCoroutine(LightMove());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
    }
    IEnumerator LightMove()
    {
        while (true)
        {
            
            if (Message.Instance().ReceiveMessage() == GameState.Playing)
            {
                float process_percentage =
                    (float)gameManager.timeProcess / (float)gameManager.PlayTime_sec;
                float angle_value = (end_Angle - start_Angle)/ (float)gameManager.PlayTime_sec;
                //Vector3 temp_angle =
                //    new Vector3(start_Angle + angle_value * process_percentage, -50, 0);
                transform.Rotate(new Vector3(1,0,0),angle_value/lerp_value,Space.Self);
            }
            yield return new WaitForSecondsRealtime(1.0f/lerp_value);
        }
    }
}
