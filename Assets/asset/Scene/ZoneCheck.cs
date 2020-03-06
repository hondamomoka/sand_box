using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneCheck : MonoBehaviour
{
    public int        sand_cnt;
    public GameObject door;

    float      door_size_y;
    float      door_speed;
    // Start is called before the first frame update
    void Start()
    {
        sand_cnt = 0;

        door_size_y = door.GetComponent<Transform>().localScale.y;
        door_speed = 0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        if(sand_cnt >= 50)
        {
            //door.SendMessage("Open");
            if (door.GetComponent<Transform>().localScale.y > 0.0f)
            {
                door.GetComponent<Transform>().transform.Translate(new Vector3(0, door_speed, 0), Space.Self);
                Vector3 work = door.GetComponent<Transform>().localScale;
                work.y -= door_speed * 2;
                if (work.y < 0.0f)
                {
                    work.y = 0.0f;
                }
                door.GetComponent<Transform>().localScale = new Vector3(work.x, work.y, work.z);
            }
        }
        else
        {
            //door.SendMessage("Close");
            if (door.GetComponent<Transform>().localScale.y < door_size_y)
            {
                door.GetComponent<Transform>().transform.Translate(new Vector3(0, -door_speed, 0), Space.Self);
                Vector3 work = door.GetComponent<Transform>().localScale;
                work.y += door_speed * 2;
                if (work.y > door_size_y)
                {
                    work.y = door_size_y;
                }
                door.GetComponent<Transform>().localScale = new Vector3(work.x, work.y, work.z);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("sands"))
        {
            sand_cnt++;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("sands"))
        {
            sand_cnt--;
        }
    }
}
