using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandInScales : MonoBehaviour
{
    public GameObject Scales;
    public GameObject Bucket;
    public GameObject Bucket_Board;
    public bool isInBucket;

    GameObject Stage;
    Rigidbody Sand_Rb;
    ScalesBehaviour Scales_Script;
    Collider Bucket_Board_Collider;
    int sand_layer;
    int weight_index;

    // Start is called before the first frame update
    void Start()
    {
        Scales = GameObject.Find("Scales");
        Bucket = GameObject.Find("BucketLeft");
        Bucket_Board = GameObject.Find("BucketLeft00");
        Stage = GameObject.Find("Stage");
        Sand_Rb = GetComponent<Rigidbody>();
        isInBucket = false;
        Scales_Script = Scales.GetComponent<ScalesBehaviour>();
        Bucket_Board_Collider = Bucket_Board.GetComponent<Collider>();
        sand_layer = gameObject.layer;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (Scales_Script.Handle_State != ScalesBehaviour.HANDLE_STATE.STATE_RETURN_BALANCE_FROM_HELPER)
        {
            if (other.gameObject.CompareTag("bucket_left_zone") &&
            isInBucket == false)
            {
                Set_Sands_When_In_Bucket();
            }
        }
        else
        {
            Set_Sands_With_Helper_Tigger();
        }

        if(other.gameObject.CompareTag("stage_border"))
        {
            transform.position = GameObject.FindGameObjectWithTag("sands").transform.position;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (Scales_Script.Handle_State != ScalesBehaviour.HANDLE_STATE.STATE_RETURN_BALANCE_FROM_HELPER)
        {
            if (other.gameObject.CompareTag("bucket_left_board") &&
            isInBucket == true)
            {
                Set_Sands_When_Out_Bucket();
            }
        }
        else
        {
            Set_Sands_With_Helper_Tigger();
        }

        if (other.gameObject.CompareTag("stage_border"))
        {
            transform.position = GameObject.FindGameObjectWithTag("sands").transform.position;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (Scales_Script.Handle_State != ScalesBehaviour.HANDLE_STATE.STATE_RETURN_BALANCE_FROM_HELPER)
        {
            if (other.collider.gameObject.CompareTag("stage"))
            {
                if (isInBucket == true)
                {
                    isInBucket = false;
                    if (Scales_Script.weights[0] > 50)
                    {
                        Scales_Script.weights[0] -= Sand_Rb.mass;
                    }
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
        else
        {
            if (other.collider.gameObject.CompareTag("sands") &&
                other.collider.gameObject.transform.parent == Stage.transform)
            {
                Set_Sands_With_Helper_Collision();
            }
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (Scales_Script.Handle_State != ScalesBehaviour.HANDLE_STATE.STATE_RETURN_BALANCE_FROM_HELPER)
        {
            if (other.collider.gameObject.CompareTag("sands") &&
            other.collider.gameObject.GetComponent<SandInScales>().isInBucket == true &&
            isInBucket == true)
            {
                Set_Sands_When_Out_Bucket();
            }
        }   
    }

    void OnCollisionStay(Collision other)
    {
        if (Scales_Script.Handle_State != ScalesBehaviour.HANDLE_STATE.STATE_RETURN_BALANCE_FROM_HELPER)
        {
            if (other.collider.gameObject.CompareTag("stage"))
            {
                if (isInBucket == true)
                {
                    isInBucket = false;
                    if (Scales_Script.weights[0] > 50)
                    {
                        Scales_Script.weights[0] -= Sand_Rb.mass;
                    }
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
        else
        {
            if (other.collider.gameObject.CompareTag("sands") &&
                other.collider.gameObject.transform.parent == Stage.transform)
            {
                Set_Sands_With_Helper_Collision();
            }
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
        //transform.parent = Stage.transform;

        // layer: もとに戻る
        gameObject.layer = sand_layer;
        Scales_Script.weights[0] -= Sand_Rb.mass;
    }

    void Set_Sands_With_Helper_Tigger()
    {
        if(transform.parent == Bucket.transform)
        {
            isInBucket = false;

            //transform.parent = Stage.transform;
            transform.parent = null;

            // layer: もとに戻る
            gameObject.layer = sand_layer;
        }
    }
    void Set_Sands_With_Helper_Collision()
    {
        if (transform.parent != Stage.transform)
        {
            transform.parent = Stage.transform;
        }
    }

    public void Set_Weight_Index(int weight_idx)
    {
        weight_index = weight_idx;
    }
}
