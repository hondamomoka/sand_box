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

    // Start is called before the first frame update
    void Start()
    {
        Player_Rb = GetComponent<Rigidbody>();
        Player_Collider = GetComponentsInChildren<Collider>();
        Player_Trs = GetComponentsInChildren<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        // PlayerのisTriggerをオンにする
        if (Scales.GetComponent<ScalesBehaviour>().Handle_State == ScalesBehaviour.HANDLE_STATE.STATE_STAY_IN_LEFT &&
            Scales.GetComponent<ScalesBehaviour>().weights[0] > Scales.GetComponent<ScalesBehaviour>().weights[1] &&
            transform.parent == Bucket.transform)
        {
            transform.parent = null;
            for (int i = 0; i < Player_Collider.Length; i++)
            {
                Player_Collider[i].isTrigger = true;

                // layer: player
                Player_Trs[i].gameObject.layer = 12;
            }
            Scales.GetComponent<ScalesBehaviour>().weights[1] -= Player_Rb.mass;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(trigger_enter) &&
            transform.parent != Bucket.transform)
        {
            transform.parent = Bucket.transform;

            for (int i = 0; i < Player_Trs.Length; i++)
            {
                // layer: wall_through_sands
                Player_Trs[i].gameObject.layer = 15;
            }

            Scales.GetComponent<ScalesBehaviour>().weights[1] += Player_Rb.mass;
            Debug.Log("weights[1]: " + Scales.GetComponent<ScalesBehaviour>().weights[1].ToString());
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
