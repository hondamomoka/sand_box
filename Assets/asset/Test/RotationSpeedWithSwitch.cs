using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationSpeedWithSwitch : MonoBehaviour
{
    public GameObject Switch;
    public float timemax;
    public float timecnt;
    public float speed_plus;

    float speed_trigger;
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Switch.activeSelf == true)
        {
            speed_trigger = 45.0f;
            speed = 35.0f;
        }
        else
        {
            speed_trigger = 45.0f + speed_plus;
            speed = 35.0f + speed_plus;
            timecnt += Time.deltaTime;

            if (timecnt >= timemax)
            {
                timecnt = 0;
                Switch.SetActive(true);
            }
        }

        float tri = Input.GetAxis("L_R_Trigger");

        if (tri > 0)
        {
            transform.Rotate(0, 0, tri * -speed_trigger * Time.deltaTime);
        }
        else if (tri < 0)
        {
            transform.Rotate(0, 0, tri * -speed_trigger * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, 0, -speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, 0, speed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0, 0, -80.0f * Time.deltaTime, Space.World);
        }
        else if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0, 0, 80.0f * Time.deltaTime, Space.World);
        }
    }
}
