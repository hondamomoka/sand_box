using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehavior : MonoBehaviour
{
    GameObject door;
    float      door_speed;
    float      door_size_y;
    // Start is called before the first frame update
    void Start()
    {
        door = GetComponent<GameObject>();
        door_speed = 0.1f;
        door_size_y = door.transform.localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Open()
    {
        if (door.transform.localScale.y > 0.0f)
        {
            door.transform.Translate(new Vector3(0, door_speed, 0), Space.Self);
            Vector3 work = door.transform.localScale;
            work.y -= door_speed * 2;
            if (work.y < 0.0f)
            {
                work.y = 0.0f;
            }
            door.transform.localScale = new Vector3(work.x, work.y, work.z);
        }
    }

    void Close()
    {
        if (door.transform.localScale.y < door_size_y)
        {
            door.transform.Translate(new Vector3(0, -door_speed, 0), Space.Self);
            Vector3 work = door.transform.localScale;
            work.y += door_speed * 2;
            if (work.y > door_size_y)
            {
                work.y = door_size_y;
            }
            door.transform.localScale = new Vector3(work.x, work.y, work.z);
        }
    }
}
