using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gear_rabbits : MonoBehaviour
{
    public  float count;
    float count_max;
    public bool moving;
    public bool stop;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        count_max = 15;
        moving = false;
        stop = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(count>count_max)
        {
            moving = true;
        }

        if(!stop)
        {
            if (moving)
            {
                transform.Rotate(0, 1.0f, 0);
            }
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!moving)
        {
            if (other.gameObject.CompareTag("sand_normal"))
            {

                count += 1.0f;
            }
        }
       
    }

    private void OnTriggerExit(Collider other)
    {
        if(!moving)
        {
            if (other.gameObject.CompareTag("sand_normal"))
            {

                count -= 1.0f;
            }
        }
       
    }
}
