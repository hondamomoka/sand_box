using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sand : MonoBehaviour {

    int freeze_time = 0;
  

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if(freeze_time>0)
        {
            freeze_time--;
        }
        else
        {
            freeze_time = 0;

            Rigidbody rb = this.GetComponent<Rigidbody>();
            rb.constraints = RigidbodyConstraints.None;
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
            freeze_time = 100;
            rb.constraints = RigidbodyConstraints.FreezePosition;
        }
    }

    private void OnCollisionEnter(Collision other)
    { 
        Rigidbody rb = this.GetComponent<Rigidbody>();

        if (other.gameObject.CompareTag("wall"))
        {
            freeze_time = 0;
            rb.constraints = RigidbodyConstraints.None;
        }
    }
}
