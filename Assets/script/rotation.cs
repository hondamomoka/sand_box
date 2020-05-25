using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{
    private bool        contFlag;

    private string[]    stControll;

    void Start()
    {
        var controll = Input.GetJoystickNames();

        //if (controll[2] == "")
        //    contFlag = false;
        //else
        //    contFlag = true;

        Debug.Log(controll.Length);
        //Debug.Log(contFlag);
    }

    void Update()
    {
        Rigidbody rb = this.GetComponent<Rigidbody>();

        if (contFlag == true)
        {

            if (Input.GetKey(KeyCode.Joystick1Button5))
            {
                transform.Rotate(0, 0, -10.0f * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.Joystick1Button4))
            {
                transform.Rotate(0, 0, 10.0f * Time.deltaTime);
            }
        }
        else
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(0, 0, -120.0f * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(0, 0, 120.0f * Time.deltaTime);
            }
        }
    }
}
