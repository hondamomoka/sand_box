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

        //入力の強さで回転の速度が変わるのを追加したい
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.Joystick1Button5))
        {
            transform.Rotate(0, 0, -1.0f);
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.Joystick1Button4))
        {
            transform.Rotate(0, 0, 1.0f);
        }
    }
}
