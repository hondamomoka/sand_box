using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZoneCheck : MonoBehaviour
{
    public int        sand_cnt;
    public int        trigger_cnt;

    private GameObject door;
    private GameObject zoom_manager;

    // Start is called before the first frame update
    void Start()
    {
        sand_cnt = 0;
        door = GameObject.Find("Door");
        zoom_manager = GameObject.Find("ZoomManager");
    }

    // Update is called once per frame
    void Update()
    {
        Check_Scene();
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

    void Check_Scene()
    {
        if (SceneManager.GetActiveScene().name == "Switch-ver")
        {
            if (sand_cnt >= trigger_cnt)
            {
                door.SendMessage("SetSpeed", 0.1f);
                door.SendMessage("OpenY", 1);
            }
            else
            {
                door.SendMessage("SetSpeed", 0.1f);
                door.SendMessage("CloseY", -1);
            }
        }
        else if (SceneManager.GetActiveScene().name == "Jellyfish")
        {
            if (sand_cnt >= trigger_cnt)
            {
                if (name == "ZoomA")
                {
                    zoom_manager.SendMessage("Set_ZoomA_State", true);
                }
                else if (name == "ZoomB")
                {
                    zoom_manager.SendMessage("Set_ZoomB_State", true);
                }
                else if (name == "ZoomC")
                {
                    zoom_manager.SendMessage("Set_ZoomC_State", true);
                }
                else if (name == "ZoomD")
                {
                    zoom_manager.SendMessage("Set_ZoomD_State", true);
                }
            }
            else
            {
                if (name == "ZoomA")
                {
                    zoom_manager.SendMessage("Set_ZoomA_State", false);
                }
                else if (name == "ZoomB")
                {
                    zoom_manager.SendMessage("Set_ZoomB_State", false);
                }
                else if (name == "ZoomC")
                {
                    zoom_manager.SendMessage("Set_ZoomC_State", false);
                }
                else if (name == "ZoomD")
                {
                    zoom_manager.SendMessage("Set_ZoomD_State", false);
                }
            }
        }
    }
}
