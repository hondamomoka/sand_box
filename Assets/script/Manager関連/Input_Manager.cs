using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input_Manager : MonoBehaviour
{
    private enum xBoxController : int
    {

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button0))
            Debug.Log("A");
        if (Input.GetKeyDown(KeyCode.Joystick1Button1))
            Debug.Log("B");
        if (Input.GetKeyDown("joystick button 2"))
            Debug.Log("X");
        if (Input.GetKeyDown("joystick button 3"))
            Debug.Log("Y");
        if (Input.GetKeyDown("joystick button 4"))
            Debug.Log("LB");
        if (Input.GetKeyDown("joystick button 5"))
            Debug.Log("RB");
        if (Input.GetKeyDown("joystick button 6"))
            Debug.Log("View");
        if (Input.GetKeyDown("joystick button 7"))
            Debug.Log("Menu");
        if (Input.GetKeyDown("joystick button 8"))
            Debug.Log("L Stick (押し込み)");
        if (Input.GetKeyDown("joystick button 9"))
            Debug.Log("R Stick (押し込み)");

        //L Stick
        float lsh = Input.GetAxis("L_Stick_H");
        float lsv = Input.GetAxis("L_Stick_V");
        if ((lsh != 0) || (lsv != 0))
        {
            Debug.Log("L stick:" + lsh + "," + lsv);
        }

        //R Stick
        float rsh = Input.GetAxis("R_Stick_H");
        float rsv = Input.GetAxis("R_Stick_V");
        if ((rsh != 0) || (rsv != 0))
        {
            Debug.Log("R stick:" + rsh + "," + rsv);
        }

        //D-Pad
        float dph = Input.GetAxis("D_Pad_H");
        float dpv = Input.GetAxis("D_Pad_V");
        if ((dph != 0) || (dpv != 0))
        {
            Debug.Log("D Pad:" + dph + "," + dpv);
        }

        //Trigger
        float tri = Input.GetAxis("L_R_Trigger");
        if (tri > 0)
        {
            Debug.Log("L trigger:" + tri);
        }
        else if (tri < 0)
        {
            Debug.Log("R trigger:" + tri);
        }
    }
}
