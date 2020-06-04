using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seesaw_rabbits : MonoBehaviour
{
    public gear_rabbits gear1;
    public gear_rabbits gear2;
    public ParticleSystem ps1;

    float rot_max;
    float rot;

    bool on;
    bool stop;

    // Start is called before the first frame update
    void Start()
    {
        ps1.Stop();
        on = false;
        stop = false;
        rot_max = 88.0f;
        rot = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(!stop)
        {
            if (!on)
            {
                if (gear1.moving && gear2.moving)
                {
                    on = true;
                    ps1.Play();

                }
            }
            else
            {
                if(rot<rot_max)
                {
                    transform.Rotate(0, 0, -0.2f);
                }
                else
                {
                    stop = true;
                    gear1.stop = true;
                    gear2.stop = true;
                }
                rot+=0.2f;
            }
        }
    }
}
