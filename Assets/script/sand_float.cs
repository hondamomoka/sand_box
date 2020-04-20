using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sand_float : MonoBehaviour
{

    public int float_time = 0;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rb = this.GetComponent<Rigidbody>();

        if (Input.GetKey(KeyCode.R))
        {
            rb.isKinematic = true;
        }
        else
        {
            rb.isKinematic = false;
        }


        if (float_time > 0)
        {
            float_time--;

            Vector3 add = new Vector3(0.0f, 3.0f, 0.0f);

            rb.AddForce(add);

        }
        else
        {
            float_time = 0;
        }

        Transform tra = this.transform;

        //削除処理
        if (tra.position.y < -5)
        {
            Destroy(this.gameObject);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = this.GetComponent<Rigidbody>();

        if (other.gameObject.CompareTag("rain"))
        {
            float_time = 300;
            //rb.constraints = RigidbodyConstraints.FreezePositionX;
            //rb.constraints = RigidbodyConstraints.FreezePositionZ;
        }
    }
}
