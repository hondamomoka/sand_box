using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchManager : MonoBehaviour
{
    public GameObject[] sw;
    public GameObject wall;
    public float timemax;
    public float timecnt;

    bool bTime;
    int next_switch;

    // Start is called before the first frame update
    void Start()
    {
        bTime = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (bTime == true)
        {
            timecnt += Time.deltaTime;

            if (timecnt >= timemax)
            {
                bTime = false;
                timecnt = 0;
                sw[next_switch].SetActive(true);
                wall.SendMessage("Be_Invisible");
            }
        }
    }

    void Timer_Start()
    {
        bTime = true;
        wall.SendMessage("Be_Visible");
    }

    void Switch_On(int next)
    {
        next_switch = next;
    }
}
