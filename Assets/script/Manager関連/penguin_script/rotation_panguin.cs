using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation_panguin : MonoBehaviour
{
    public float rot_limit;
    public float deviation;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rb = this.GetComponent<Rigidbody>();
        float tri = Input.GetAxis("L_R_Trigger");

        if (tri > 0)
        {
            transform.Rotate(0, 0, -44.5f * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, 0, -33.4f * Time.deltaTime);
        }

        if (tri < 0)
        {
            transform.Rotate(0, 0, tri * -44.5f * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, 0, 33.4f * Time.deltaTime);
        }

        if(transform.eulerAngles.z > rot_limit && transform.eulerAngles.z < rot_limit + deviation)
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, rot_limit);
        }

        if(transform.eulerAngles.z < 360.0f - rot_limit && transform.eulerAngles.z > 360.0f - (rot_limit + deviation))
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 360.0f - rot_limit);
        }
    }
}
