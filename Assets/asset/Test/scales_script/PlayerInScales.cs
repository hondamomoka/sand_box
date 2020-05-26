using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInScales : MonoBehaviour
{
    public GameObject Scales;
    public GameObject Bucket;
    public bool player_trigger;
    public string trigger_enter;
    public string trigger_exit;

    Rigidbody Player_Rb;
    Collider[] Player_Collider;
    Transform[] Player_Trs;
    ScalesBehaviour Scales_Script;

    // Start is called before the first frame update
    void Start()
    {
        Player_Rb = GetComponent<Rigidbody>();
        Player_Collider = GetComponentsInChildren<Collider>();
        Player_Trs = GetComponentsInChildren<Transform>();

        Scales_Script = Scales.GetComponent<ScalesBehaviour>();

    }

    // Update is called once per frame
    void Update()
    {
        // PlayerのisTriggerをオンにする
        if (Scales_Script.Handle_State == ScalesBehaviour.HANDLE_STATE.STATE_STAY_IN_LEFT &&
            Scales_Script.isPlayerInBucket == true &&
            Scales_Script.weights[0] > Scales_Script.weights[1] &&
            transform.parent == Bucket.transform)
        {
            transform.parent = null;
            for (int i = 0; i < Player_Collider.Length; i++)
            {
                Player_Collider[i].isTrigger = true;

                // layer: player
                Player_Trs[i].gameObject.layer = 12;
            }
            Scales_Script.weights[1] -= Player_Rb.mass;
            Scales_Script.isPlayerInBucket = false;
            Player_Rb.mass = 10;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(trigger_enter) &&
            transform.parent != Bucket.transform)
        {
            Scales_Script.isWithPlayer = true;
            transform.parent = Bucket.transform;

            for (int i = 0; i < Player_Trs.Length; i++)
            {
                // layer: wall_through_sands
                Player_Trs[i].gameObject.layer = 15;
            }

            Player_Rb.mass = 450;
            Scales_Script.weights[1] += Player_Rb.mass;
            Scales_Script.isPlayerInBucket = true;
            //Debug.Log("weights[1]: " + Scales_Script.weights[1].ToString());
        }

        if (other.gameObject.CompareTag("player_switch"))
        {
            Destroy(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(trigger_exit) &&
            transform.parent == null)
        {
            transform.parent = GameObject.Find("Stage").transform;

            for (int i = 0; i < Player_Collider.Length; i++)
            {
                Player_Collider[i].isTrigger = false;
            }
        }
    }
}
