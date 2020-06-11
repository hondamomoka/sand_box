using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorJoinWithScales : MonoBehaviour
{
    public GameObject Handle;
    public GameObject Door;
    public Material Mat;

    public swichEFonly_cobra effect;
    bool e_on;

    bool isRot;

    // Start is called before the first frame update
    void Start()
    {
        e_on = false;
        isRot = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Handle.transform.localEulerAngles.z >= 319.0f && isRot == false)
        {
            if(!e_on)
            {
                effect.playPS();
                e_on = true;
            }
            float z = (360 - Handle.transform.localEulerAngles.z) * 2.25f;
            transform.localEulerAngles = new Vector3(0, 0, z);

            if (z > 90.0f)
            {
                isRot = true;
                Door.GetComponent<Renderer>().material = Mat;

                // layer: wall_through_sands
                Door.layer = 15;
            }

        }
    }
}
