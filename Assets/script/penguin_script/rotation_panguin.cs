using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation_panguin : MonoBehaviour
{

    float rot;

    // Start is called before the first frame update
    void Start()
    {
        rot = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rb = this.GetComponent<Rigidbody>();

        if(rot>-20.0f)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(0, 0, -1.0f);
                rot -= 1.0f;
            }
            else if (Input.GetKey("joystick button 5"))
            {
                transform.Rotate(0, 0, -1.0f);
                rot -= 1.0f;
            }
        }

        if(rot<20.0f)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(0, 0, 1.0f);
                rot += 1.0f;
            }
            else if (Input.GetKey("joystick button 4"))
            {
                transform.Rotate(0, 0, 1.0f);
                rot += 1.0f;
            }
        }
     

       
    }
}
