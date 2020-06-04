using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gear_rabbits : MonoBehaviour
{
    public  float count;
    float count_max;
    public bool moving;
    public bool stop;
    public ParticleSystem ps1;

    // Start is called before the first frame update
    void Start()
    {
        ps1.Stop();
        count = 0;
        count_max = 10;
        moving = false;
        stop = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!moving)
        {
            if (count > count_max)
            {
                moving = true;
                ps1.Play();
            }
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
