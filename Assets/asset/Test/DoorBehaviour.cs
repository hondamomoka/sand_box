using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    float door_size_y;
    float door_speed;

    // Start is called before the first frame update
    void Start()
    {
        door_size_y = GetComponent<Transform>().localScale.y;
        door_speed = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Open()
    {
        if (GetComponent<Transform>().localScale.y > 0.0f)
        {
            GetComponent<Transform>().transform.Translate(new Vector3(0, door_speed, 0), Space.Self);
            Vector3 work = GetComponent<Transform>().localScale;
            work.y -= door_speed * 2;
            if (work.y < 0.0f)
            {
                work.y = 0.0f;
            }
            GetComponent<Transform>().localScale = new Vector3(work.x, work.y, work.z);
        }
    }

    void Close()
    {
        if (GetComponent<Transform>().localScale.y < door_size_y)
        {
            GetComponent<Transform>().transform.Translate(new Vector3(0, -door_speed, 0), Space.Self);
            Vector3 work = GetComponent<Transform>().localScale;
            work.y += door_speed * 2;
            if (work.y > door_size_y)
            {
                work.y = door_size_y;
            }
            GetComponent<Transform>().localScale = new Vector3(work.x, work.y, work.z);
        }
    }
}
