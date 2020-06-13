using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket_Player : MonoBehaviour
{
    public GameObject Scales;
    public GameObject Bucket;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            other.transform.parent = Bucket.transform;

            Transform[] children = other.GetComponentsInChildren<Transform>();

            for (int i = 0; i < children.Length; i++)
            {
                // layer: wall_through_sands
                children[i].gameObject.layer = 15;
                //Debug.Log("Length: " + children.Length.ToString());
            }

            Scales.GetComponent<ScalesBehaviour>().weights[1] += other.GetComponent<Rigidbody>().mass;
            //Debug.Log("weights[1]: " + Scales.GetComponent<ScalesBehaviour>().weights[1].ToString());
        }
    }
}
