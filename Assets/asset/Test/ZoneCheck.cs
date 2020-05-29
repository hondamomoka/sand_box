using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ZoneCheck : MonoBehaviour
{
    public int        sand_cnt;
    public int        trigger_cnt;
    public GameObject obj;
    public string     scene;
    public string     gimmick;

    // Start is called before the first frame update
    void Start()
    {
        sand_cnt = 0;
    }

    // Update is called once per frame
    void Update()
    {
        SendMessage(scene);
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

    void Switch_ver()
    {
        if (sand_cnt >= trigger_cnt)
        {
            obj.SendMessage("SetSpeed", 0.1f);
            obj.SendMessage("OpenY", 1);
        }
        else
        {
            obj.SendMessage("SetSpeed", 0.1f);
            obj.SendMessage("CloseY", -1);
        }
    }

    void stage_jellyfish()
    {
        if (sand_cnt >= trigger_cnt)
        {
            obj.SendMessage("Set_" + gimmick + "_State", true);
        }
        else
        {
            obj.SendMessage("Set_" + gimmick + "_State", false);
        }
    }

    void stage_whale()
    {

    }

    void Check_Scene()
    {
        //if (SceneManager.GetActiveScene().name == "Switch_ver")
        //{
        //    if (sand_cnt >= trigger_cnt)
        //    {
        //        door.SendMessage("SetSpeed", 0.1f);
        //        door.SendMessage("OpenY", 1);
        //    }
        //    else
        //    {
        //        door.SendMessage("SetSpeed", 0.1f);
        //        door.SendMessage("CloseY", -1);
        //    }
        //}
        //else if (SceneManager.GetActiveScene().name == "stage_jellyfish")
        //{
        //    if (sand_cnt >= trigger_cnt)
        //    {
        //        if (name == "ZoomA")
        //        {
        //            zoom_manager.SendMessage("Set_ZoomA_State", true);
        //        }
        //        else if (name == "ZoomB")
        //        {
        //            zoom_manager.SendMessage("Set_ZoomB_State", true);
        //        }
        //        else if (name == "ZoomC")
        //        {
        //            zoom_manager.SendMessage("Set_ZoomC_State", true);
        //        }
        //        else if (name == "ZoomD")
        //        {
        //            zoom_manager.SendMessage("Set_ZoomD_State", true);
        //        }
        //    }
        //    else
        //    {
        //        if (name == "ZoomA")
        //        {
        //            zoom_manager.SendMessage("Set_ZoomA_State", false);
        //        }
        //        else if (name == "ZoomB")
        //        {
        //            zoom_manager.SendMessage("Set_ZoomB_State", false);
        //        }
        //        else if (name == "ZoomC")
        //        {
        //            zoom_manager.SendMessage("Set_ZoomC_State", false);
        //        }
        //        else if (name == "ZoomD")
        //        {
        //            zoom_manager.SendMessage("Set_ZoomD_State", false);
        //        }
        //    }
        //}
    }
}
