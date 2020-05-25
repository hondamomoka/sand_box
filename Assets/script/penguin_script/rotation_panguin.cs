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
        float tri = Input.GetAxis("L_R_Trigger");

        if (rot>-20.0f)
        {
            if (tri > 0)
            {
                rot -= tri * -44.5f * Time.deltaTime;
                transform.Rotate(0, 0, -44.5f * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                rot -= 33.4f * Time.deltaTime;
                transform.Rotate(0, 0, -33.4f * Time.deltaTime);
            }
        }

        if (rot<20.0f)
        {
            if (tri < 0)
            {
                rot += tri * -44.5f * Time.deltaTime;
                transform.Rotate(0, 0, tri * -44.5f * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                rot += 33.4f * Time.deltaTime;
                transform.Rotate(0, 0, 33.4f * Time.deltaTime);
            }
        }



    }
}
