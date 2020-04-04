using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneCheck : MonoBehaviour
{
    public int        sand_cnt;
    public GameObject door;

    // Start is called before the first frame update
    void Start()
    {
        sand_cnt = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(sand_cnt >= 50)
        {
            door.SendMessage("Open");
        }
        else
        {
            door.SendMessage("Close");
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
