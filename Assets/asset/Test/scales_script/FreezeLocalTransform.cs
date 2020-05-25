using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeLocalTransform : MonoBehaviour
{
    public bool LocalPos, LocalPosX, LocalPosY, LocalPosZ;
    public bool LocalRot, LocalRotX, LocalRotY, LocalRotZ;
    public bool LocalScl, LocalSclX, LocalSclY, LocalSclZ;

    Vector3 local_pos;
    Vector3 local_rot;
    Vector3 local_scl;

    // Start is called before the first frame update
    void Start()
    {
        local_pos = transform.localPosition;
        local_rot = transform.localEulerAngles;
        local_scl = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (LocalPos == true)
        {
            LocalPosX = true;
            LocalPosY = true;
            LocalPosZ = true;
        }

        if (LocalRot == true)
        {
            LocalRotX = true;
            LocalRotY = true;
            LocalRotZ = true;
        }

        if (LocalScl == true)
        {
            LocalSclX = true;
            LocalSclY = true;
            LocalSclZ = true;
        }

        if (LocalPosX == true)
        {
            transform.localPosition = new Vector3(local_pos.x, transform.localPosition.y, transform.localPosition.z);
        }

        if (LocalPosY == true)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, local_pos.y, transform.localPosition.z);
        }

        if (LocalPosZ == true)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, local_pos.z);
        }

        if(LocalRotX == true)
        {
            transform.localEulerAngles = new Vector3(local_rot.x, transform.localEulerAngles.y, transform.localEulerAngles.z);
        }

        if (LocalRotY == true)
        {
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, local_rot.y, transform.localEulerAngles.z);
        }

        if (LocalRotZ == true)
        {
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, local_rot.z);
        }

        if (LocalSclX == true)
        {
            transform.localScale = new Vector3(local_scl.x, transform.localScale.y, transform.localScale.z);
        }

        if (LocalSclY == true)
        {
            transform.localScale = new Vector3(transform.localScale.x, local_scl.y, transform.localScale.z);
        }

        if (LocalSclZ == true)
        {
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, local_scl.z);
        }
    }
}
