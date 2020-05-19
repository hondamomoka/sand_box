using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour {

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update() {

        Rigidbody rb = this.GetComponent<Rigidbody>();

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, 0, -1.0f);

        }
        else if (Input.GetKey("joystick button 5"))
        {
            transform.Rotate(0, 0, -1.0f);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, 0, 1.0f);
        }
        else if (Input.GetKey("joystick button 4"))
        {
            transform.Rotate(0, 0, 1.0f);
        }

        //右９０度
        if (Input.GetKeyDown(KeyCode.R))
        {
            transform.Rotate(0, 0, 90.0f);
        }

        //左９０度
        if (Input.GetKeyDown(KeyCode.L))
        {
            transform.Rotate(0, 0, -90.0f);
        }

       

       
    }
}
