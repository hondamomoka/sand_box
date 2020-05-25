using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandInScales : MonoBehaviour
{
    public GameObject Scales;
    public GameObject Bucket;
    public bool isInBucket;

    GameObject Stage;
    Rigidbody Sand_Rb;
    ScalesBehaviour Scales_Script;
    int sand_layer;

    // Start is called before the first frame update
    void Start()
    {
        Scales = GameObject.Find("Scales");
        Bucket = GameObject.Find("BucketLeft");
        Stage = GameObject.Find("Stage");
        Sand_Rb = GetComponent<Rigidbody>();
        isInBucket = false;
        Scales_Script = Scales.GetComponent<ScalesBehaviour>();
        sand_layer = gameObject.layer;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("bucket_left_zone") &&
            isInBucket == false)
        {
            Set_Sands_When_In_Bucket();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("bucket_left_zone") &&
            isInBucket == true)
        {
            Set_Sands_When_Out_Bucket();
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.gameObject.CompareTag("stage"))
        {
            if (isInBucket == true)
            {
                isInBucket = false;
            }

            if (transform.parent != Stage.transform)
            {
                transform.parent = Stage.transform;
            }

            // layer: もとに戻る
            gameObject.layer = sand_layer;
        }
        else if (other.collider.gameObject.CompareTag("sands") &&
            other.collider.gameObject.GetComponent<SandInScales>().isInBucket == true &&
            isInBucket == false)
        {
            Set_Sands_When_In_Bucket();
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.collider.gameObject.CompareTag("sands") &&
            other.collider.gameObject.GetComponent<SandInScales>().isInBucket == true &&
            isInBucket == true)
        {
            Set_Sands_When_Out_Bucket();
        }
    }

    void OnCollisionStay(Collision other)
    {
        if (other.collider.gameObject.CompareTag("stage"))
        {
            if (isInBucket == true)
            {
                isInBucket = false;
            }

            if (transform.parent != Stage.transform)
            {
                transform.parent = Stage.transform;
            }

            // layer: もとに戻る
            gameObject.layer = sand_layer;
        }
        else if (other.collider.gameObject.CompareTag("sands") &&
            other.collider.gameObject.GetComponent<SandInScales>().isInBucket == true &&
            isInBucket == false &&
            transform.parent != Stage.transform)
        {
            Set_Sands_When_In_Bucket();
        }
    }

    void Set_Sands_When_In_Bucket()
    {
        isInBucket = true;
        transform.parent = Bucket.transform;

        // layer: wall_through_player
        gameObject.layer = 14;
        Scales_Script.weights[0] += Sand_Rb.mass;
    }

    void Set_Sands_When_Out_Bucket()
    {
        isInBucket = false;
        transform.parent = null;

        // layer: もとに戻る
        gameObject.layer = sand_layer;
        Scales_Script.weights[0] -= Sand_Rb.mass;
    }
}
