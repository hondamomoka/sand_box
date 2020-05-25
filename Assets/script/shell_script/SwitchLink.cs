using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchLink : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject switch_manager;
    public int sand_cnt;
    public int trigger_cnt;
    public int next_switch;

    // Start is called before the first frame update
    void Start()
    {
        sand_cnt = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(sand_cnt >= trigger_cnt)
        {
            sand_cnt = 0;
            gameObject.SetActive(false);
            switch_manager.SendMessage("Switch_On", next_switch);
            switch_manager.SendMessage("Timer_Start");
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