using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_Rotation : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, 0, -1.0f, Space.World);

        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, 0, 1.0f, Space.World);
        }

    }
}
