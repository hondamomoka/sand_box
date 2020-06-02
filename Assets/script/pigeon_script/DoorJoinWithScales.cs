using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorJoinWithScales : MonoBehaviour
{
    public GameObject Handle;
    public GameObject Door;
    public Material Mat;

    bool isRot;

    // Start is called before the first frame update
    void Start()
    {
        isRot = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Handle.transform.localEulerAngles.z >= 319.0f && isRot == false)
        {
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
