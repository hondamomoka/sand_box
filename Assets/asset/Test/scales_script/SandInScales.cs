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

    public enum SAND_STATE
    {
        SAND_STATE_NONE,
        SAND_STATE_STAGE,
        SAND_STATE_FALLING_IN_BUCKET,
        SAND_STATE_FALLING_OUT_BUCKET,
        SAND_STATE_PERHAPS_STAY_IN_BUCKET,
        SAND_STATE_STAY_IN_BUCKET,
        SAND_STATE_THROUGH_SCALES,
    };

    public SAND_STATE Sand_State;

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

        Sand_State = SAND_STATE.SAND_STATE_STAGE;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y <= -20.0f)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (Scales_Script.Handle_State != ScalesBehaviour.HANDLE_STATE.STATE_RETURN_BALANCE_FROM_HELPER)
        {
            if(other.gameObject.CompareTag("sands_trigger_change_parent"))
            {
                switch (Sand_State)
                {
                    case SAND_STATE.SAND_STATE_STAGE:
                        Sand_State = SAND_STATE.SAND_STATE_FALLING_IN_BUCKET;
                        break;
                    case SAND_STATE.SAND_STATE_FALLING_IN_BUCKET:
                        Sand_State = SAND_STATE.SAND_STATE_STAGE;
                        break;
                    case SAND_STATE.SAND_STATE_PERHAPS_STAY_IN_BUCKET:
                    case SAND_STATE.SAND_STATE_STAY_IN_BUCKET:
                        Sand_State = SAND_STATE.SAND_STATE_FALLING_OUT_BUCKET;

                        //transform.parent = null;
                        transform.parent = Stage.transform;

                        // layer: sand_normal
                        gameObject.layer = 8;
                        break;
                }
            }

            if (other.gameObject.CompareTag("bucket_left_zone"))
            {
                switch (Sand_State)
                {
                    case SAND_STATE.SAND_STATE_FALLING_IN_BUCKET:
                    case SAND_STATE.SAND_STATE_PERHAPS_STAY_IN_BUCKET:
                        Sand_State = SAND_STATE.SAND_STATE_STAY_IN_BUCKET;

                        transform.parent = Bucket.transform;

                        // layer: wall_through_player
                        gameObject.layer = 14;
                        break;
                }
            }
        }
        else
        {
            if (other.gameObject.CompareTag("sands_trigger_change_parent"))
            {
                switch (Sand_State)
                {
                    case SAND_STATE.SAND_STATE_FALLING_IN_BUCKET:
                    case SAND_STATE.SAND_STATE_PERHAPS_STAY_IN_BUCKET:
                    case SAND_STATE.SAND_STATE_STAY_IN_BUCKET:
                        Sand_State = SAND_STATE.SAND_STATE_FALLING_OUT_BUCKET;

                        //transform.parent = null;
                        transform.parent = Stage.transform;

                        // layer: sand_normal
                        gameObject.layer = 8;
                        break;
                }
            }
        }

        if (other.gameObject.CompareTag("stage_border_return") && gameObject.layer != 28)
        {
            transform.position = GameObject.FindGameObjectWithTag("sand_normal").transform.position;
            gameObject.tag = "sand_normal";
            Sand_State = SAND_STATE.SAND_STATE_STAGE;
            transform.parent = Stage.transform;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (Scales_Script.Handle_State != ScalesBehaviour.HANDLE_STATE.STATE_RETURN_BALANCE_FROM_HELPER)
        {
            if (other.gameObject.CompareTag("bucket_left_zone"))
            {
                Sand_State = SAND_STATE.SAND_STATE_STAY_IN_BUCKET;

                transform.parent = Bucket.transform;

                // layer: wall_through_player
                gameObject.layer = 14;
            }
        }

        if (other.gameObject.CompareTag("stage_border_return") && gameObject.layer != 28)
        {
            transform.position = GameObject.FindGameObjectWithTag("sand_normal").transform.position;
            gameObject.tag = "sand_normal";
            Sand_State = SAND_STATE.SAND_STATE_STAGE;
            transform.parent = Stage.transform;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("sands_trigger_change_parent"))
        {
            switch (Sand_State)
            {
                case SAND_STATE.SAND_STATE_FALLING_OUT_BUCKET:
                case SAND_STATE.SAND_STATE_PERHAPS_STAY_IN_BUCKET:
                case SAND_STATE.SAND_STATE_STAY_IN_BUCKET:
                case SAND_STATE.SAND_STATE_THROUGH_SCALES:
                    Sand_State = SAND_STATE.SAND_STATE_STAGE;

                    transform.parent = Stage.transform;

                    // layer: sand_normal
                    gameObject.layer = 8;
                    break;
            }
        }

        if (other.gameObject.CompareTag("stage_border_return") && gameObject.layer != 28)
        {
            transform.position = GameObject.FindGameObjectWithTag("sand_normal").transform.position;
            gameObject.tag = "sand_normal";
            Sand_State = SAND_STATE.SAND_STATE_STAGE;
            transform.parent = Stage.transform;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("sand_normal"))
        {
            SAND_STATE work = other.gameObject.GetComponent<SandInScales>().Sand_State;

            if (Scales_Script.Handle_State != ScalesBehaviour.HANDLE_STATE.STATE_RETURN_BALANCE_FROM_HELPER)
            {
                if (work == SAND_STATE.SAND_STATE_PERHAPS_STAY_IN_BUCKET || work == SAND_STATE.SAND_STATE_STAY_IN_BUCKET)
                {
                    switch (Sand_State)
                    {
                        //case SAND_STATE.SAND_STATE_STAGE:
                        case SAND_STATE.SAND_STATE_FALLING_IN_BUCKET:
                        case SAND_STATE.SAND_STATE_FALLING_OUT_BUCKET:
                            Sand_State = SAND_STATE.SAND_STATE_PERHAPS_STAY_IN_BUCKET;

                            transform.parent = Bucket.transform;

                            // layer: wall_through_player
                            gameObject.layer = 14;
                            break;
                    }
                }
            }
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("sand_normal"))
        {
            SAND_STATE work = other.gameObject.GetComponent<SandInScales>().Sand_State;

            if (Scales_Script.Handle_State != ScalesBehaviour.HANDLE_STATE.STATE_RETURN_BALANCE_FROM_HELPER)
            {
                if (work == SAND_STATE.SAND_STATE_PERHAPS_STAY_IN_BUCKET || work == SAND_STATE.SAND_STATE_STAY_IN_BUCKET)
                {
                    switch (Sand_State)
                    {
                        case SAND_STATE.SAND_STATE_PERHAPS_STAY_IN_BUCKET:
                            Sand_State = SAND_STATE.SAND_STATE_FALLING_OUT_BUCKET;

                            //transform.parent = null;

                            transform.parent = Stage.transform;

                            // layer: sand_normal
                            gameObject.layer = 8;
                            break;
                    }
                }
            }
        }  
    }

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("sand_normal"))
        {
            SAND_STATE work = other.gameObject.GetComponent<SandInScales>().Sand_State;

            if (Scales_Script.Handle_State != ScalesBehaviour.HANDLE_STATE.STATE_RETURN_BALANCE_FROM_HELPER)
            {
                if (work == SAND_STATE.SAND_STATE_PERHAPS_STAY_IN_BUCKET || work == SAND_STATE.SAND_STATE_STAY_IN_BUCKET)
                {
                    switch (Sand_State)
                    {
                        case SAND_STATE.SAND_STATE_PERHAPS_STAY_IN_BUCKET:
                            Sand_State = SAND_STATE.SAND_STATE_STAY_IN_BUCKET;

                            transform.parent = Bucket.transform;

                            // layer: wall_through_player
                            gameObject.layer = 14;
                            break;
                    }
                }
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
