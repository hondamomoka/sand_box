using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_penguin : MonoBehaviour
{
    int float_time;

    // Start is called before the first frame update
    void Start()
    {
        float_time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(float_time>0)
        {
            float_time--;

            Vector3 add = new Vector3(0.0f, 150.0f, 0.0f);
            Rigidbody rb = this.GetComponent<Rigidbody>();
            rb.AddForce(add);
        }
        else if (float_time < 0)
        {
            float_time = 0;
            Rigidbody rb = this.GetComponent<Rigidbody>();
            rb.mass = 10.0f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("wind"))
        {
            Rigidbody rb = this.GetComponent<Rigidbody>();
            //rb.mass = 5.0f;
            float_time = 200;
        }
    }
}
