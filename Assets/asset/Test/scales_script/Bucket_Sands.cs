using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket_Sands : MonoBehaviour
{
    public GameObject Scales;
    public GameObject Bucket;
    public int sand_cnt;

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
        if (other.gameObject.CompareTag("sands"))
        {
            other.transform.parent = Bucket.transform;
            // layer: wall_through_player
            other.gameObject.layer = 14;
            Scales.GetComponent<ScalesBehaviour>().weights[0] += other.GetComponent<Rigidbody>().mass;
            sand_cnt++;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("sands"))
        {
            other.transform.parent = GameObject.Find("Stage").transform;
            // layer: sand_normal
            other.gameObject.layer = 8;
            Scales.GetComponent<ScalesBehaviour>().weights[0] -= other.GetComponent<Rigidbody>().mass;
            sand_cnt--;
        }
    }
}
