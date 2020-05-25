using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{
    void Update()
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
            transform.Rotate(0, 0, -33.4f * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, 0, 33.4f * Time.deltaTime);
        }
    }
}
