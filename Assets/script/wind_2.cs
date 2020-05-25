using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wind_2 : MonoBehaviour
{
    public bool on=false;
    public GameObject coll;
    public ParticleSystem ps1;
    public ParticleSystem ps2;

    // Start is called before the first frame update
    void Start()
    {
        ps1.Stop();
        ps2.Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if(on)
        {
            transform.Rotate(0, 2.0f, 0);
        }
        
    }

    public void start()
    {
        on = true;
        coll.gameObject.tag = "wind";
        ps1.Play();
        ps2.Play();
    }
}
