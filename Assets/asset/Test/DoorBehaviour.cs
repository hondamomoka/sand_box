using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehaviour : MonoBehaviour
{
    private float door_size_x;
    private float door_size_y;
    private float door_speed;

    // Start is called before the first frame update
    void Start()
    {
        door_size_x = GetComponent<Transform>().localScale.x;
        door_size_y = GetComponent<Transform>().localScale.y;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetSpeed(float speed)
    {
        door_speed = speed;
    }

    void OpenX(int direction)
    {
        if (GetComponent<Transform>().localScale.x > 0.0f)
        {
            GetComponent<Transform>().transform.Translate(new Vector3(door_speed * direction, 0, 0), Space.Self);
            Vector3 work = GetComponent<Transform>().localScale;
            work.x -= door_speed * 2;
            if (work.x < 0.0f)
            {
                work.x = 0.0f;
            }
            GetComponent<Transform>().localScale = new Vector3(work.x, work.y, work.z);
        }
    }

    void OpenY(int direction)
    {
        if (GetComponent<Transform>().localScale.y > 0.0f)
        {
            GetComponent<Transform>().transform.Translate(new Vector3(0, door_speed * direction, 0), Space.Self);
            Vector3 work = GetComponent<Transform>().localScale;
            work.y -= door_speed * 2;
            if (work.y < 0.0f)
            {
                work.y = 0.0f;
            }
            GetComponent<Transform>().localScale = new Vector3(work.x, work.y, work.z);
        }
    }

    void CloseX(int direction)
    {
        if (GetComponent<Transform>().localScale.x < door_size_x)
        {
            GetComponent<Transform>().transform.Translate(new Vector3(door_speed * direction, 0, 0), Space.Self);
            Vector3 work = GetComponent<Transform>().localScale;
            work.x += door_speed * 2;
            if (work.x > door_size_x)
            {
                work.x = door_size_x;
            }
            GetComponent<Transform>().localScale = new Vector3(work.x, work.y, work.z);
        }
    }

    void CloseY(int direction)
    {
        if (GetComponent<Transform>().localScale.y < door_size_y)
        {
            GetComponent<Transform>().transform.Translate(new Vector3(0, door_speed * direction, 0), Space.Self);
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
