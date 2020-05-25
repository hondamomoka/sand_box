using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_penguin : MonoBehaviour
{
    int float_time;
    Vector3 add;

    // Start is called before the first frame update
    void Start()
    {
        float_time = 0;
        add = new Vector3(0.0f, 40.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(float_time>0)
        {
            float_time--;

            
            this.GetComponent<Rigidbody>().AddForce(add);
        }
        else if (float_time < 0)
        {
            float_time = 0;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("wind"))
        {
           this.GetComponent<Rigidbody>().AddForce(add);
           
        }
    }
}
