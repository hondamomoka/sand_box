using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorJoinWithScales : MonoBehaviour
{
    public GameObject Scales;
    public GameObject Handle;
    public GameObject Door;
    public Material Mat;

    public swichEFonly_cobra effect;
    bool e_on;

    bool isRot;

    ScalesBehaviour Scales_Script;

    // Start is called before the first frame update
    void Start()
    {
        e_on = false;
        isRot = false;

        Scales_Script = Scales.GetComponent<ScalesBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Scales_Script.Handle_State == ScalesBehaviour.HANDLE_STATE.STATE_TURN_TO_RIGHT ||
            Scales_Script.Handle_State == ScalesBehaviour.HANDLE_STATE.STATE_RETURN_BALANCE_FROM_RIGHT) &&
            isRot == false)
        {
            if(!e_on)
            {
                effect.playPS();
                e_on = true;
            }
            float z = (360 - Handle.transform.localEulerAngles.z) * 2.25f;
            transform.localEulerAngles = new Vector3(0, 0, z);
        }
        else if (Scales_Script.Handle_State == ScalesBehaviour.HANDLE_STATE.STATE_STAY_IN_RIGHT && isRot == false)
        {
            isRot = true;
            Door.GetComponent<Renderer>().material = Mat;

            // layer: wall_through_sands
            Door.layer = 15;
            transform.localEulerAngles = new Vector3(0, 0, 90.0f);
        }
    }
}
