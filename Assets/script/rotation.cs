using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class rotation : MonoBehaviour
{
    //クリア時やメニューの時に回転しないようのフラグ　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　
    public bool rotateFlag;

    void Start()
    {
        rotateFlag = true;
    }


    void Update()
    {
        if (rotateFlag)
        {
            Rigidbody rb = this.GetComponent<Rigidbody>();
            float tri = Input.GetAxis("L_R_Trigger");

            if (tri > 0)
            {
                transform.Rotate(0, 0, tri * -44.5f * Time.deltaTime);
            }
            else if (tri < 0)
            {
                transform.Rotate(0, 0, tri * -44.5f * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(0, 0, -44.5f * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(0, 0, 44.5f * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.PageDown))
            {
                transform.Rotate(0, 0, -80.0f * Time.deltaTime, Space.World);
            }
            else if (Input.GetKey(KeyCode.PageUp))
            {
                transform.Rotate(0, 0, 80.0f * Time.deltaTime, Space.World);
            }

            if (Input.GetKey(KeyCode.Joystick1Button7))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }

        }
    }
}