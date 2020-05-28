using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    GameObject cursor;
    private float cursor_x;
    private float cursor_z;
    private float angle_x;
    public float CameraPos_y;
    Vector3 commonpos;
    Vector3 commonangle;

    // Start is called before the first frame update
    void Start()
    {
        commonpos = this.transform.position;
        commonangle = this.transform.eulerAngles;
        angle_x = 90.0f;
    }

    // Update is called once per frame
    void Update()
    {
        cursor= GameObject.Find("SelectCursor");
        cursor_x = cursor.transform.position.x;
        cursor_z = cursor.transform.position.z;

        if (Input.GetKey(KeyCode.Space))
        {
            this.transform.position = new Vector3(cursor_x, CameraPos_y, cursor_z);
            this.transform.eulerAngles = new Vector3(angle_x, 0.0f, 0.0f);
        }
        else
        {
            this.transform.position = commonpos;
            this.transform.eulerAngles = commonangle;
        }
    }
}
