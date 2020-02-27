using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water_manager : MonoBehaviour
{
    public GameObject rain;

    int rain1 = 10;
    int rain2 = 20;
    int rain3 = 30;
    int rain4 = 40;

    Vector3 pos;

    // Use this for initialization
    void Start()
    {



    }

    // Update is called once per frame
    void Update()
    {

        Transform tra = this.transform;

        pos = tra.position;

        rain1 -= 1;
        rain2 -= 1;
        rain3 -= 1;
        rain4 -= 1;

        if (rain1 < 0)
        {
            Vector3 setpos = pos;
            setpos.x -= 0.4f;
            Instantiate(rain, new Vector3(setpos.x, setpos.y, setpos.z), Quaternion.identity);
            rain1 = Random.Range(10, 50);
        }

        if (rain2 < 0)
        {
            Vector3 setpos = pos;
            setpos.x -= 0.2f;
            Instantiate(rain, setpos, Quaternion.identity);
            rain2 = Random.Range(10, 50);
        }

        if (rain3 < 0)
        {
            Vector3 setpos = pos;
            setpos.x += 0.2f;
            Instantiate(rain, setpos, Quaternion.identity);
            rain3 = Random.Range(10, 50);
        }

        if (rain4 < 0)
        {
            Vector3 setpos = pos;
            setpos.x += 0.4f;
            Instantiate(rain, setpos, Quaternion.identity);
            rain4 = Random.Range(10, 50);
        }
    }
}
