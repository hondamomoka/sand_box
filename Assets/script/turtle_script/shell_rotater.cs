using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shell_rotater : MonoBehaviour
{
    // Start is called before the first frame update

    public bool rot_right;
    public bool rot_left;
    float rot;

    void Start()
    {
        rot_right = false;
        rot_left = false;
        rot = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(rot_right&&rot_left)
        {
            rot = 0;
        }
        else if(rot_right==true)
        {
            rot = -0.3f;
        }
       else  if (rot_left==true)
        {
            rot = 0.3f;
        }
        else
        {
            rot = 0;
        }

        if(rot!=0)
        {
            transform.Rotate(0.0f, 0.0f, rot);
        }
    }
}
