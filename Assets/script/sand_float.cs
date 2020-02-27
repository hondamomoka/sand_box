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
        

        if (float_time > 0)
        {
            float_time--;

            Rigidbody rb = this.GetComponent<Rigidbody>();

            Vector3 add = new Vector3(0.0f, 3.0f, 0.0f);

            rb.AddForce(add);

        }
        else
        {
            float_time = 0;

            //Rigidbody rb = this.GetComponent<Rigidbody>();
            //rb.constraints = RigidbodyConstraints.None;
        }

        Transform tra = this.transform;

        //削除処理
        if (tra.position.y < -5)
        {
            Destroy(this.gameObject);
        }

    }

    private void OnCollisionEnter(Collision other)
    {
        Rigidbody rb = this.GetComponent<Rigidbody>();

        if (other.gameObject.CompareTag("water"))
        {
            float_time = 300;
            //rb.constraints = RigidbodyConstraints.FreezePositionX;
            //rb.constraints = RigidbodyConstraints.FreezePositionZ;
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
