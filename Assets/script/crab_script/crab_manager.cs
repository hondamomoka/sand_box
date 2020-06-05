using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crab_manager : MonoBehaviour
{
    public switch_crab sw0;
    public switch_crab sw1;
    public switch_crab sw2;
    public switch_crab sw3;
    public switch_crab sw4;
    public switch_crab sw5;
    public bool on;
    public GameObject scissor1;
    public GameObject scissor2;
    public GameObject scissor3;
    public GameObject scissor4;
    public swichEFonly_cobra effect;
    public Material[] material;
    public ParticleSystem ps1;
    public ParticleSystem ps2;

    // Start is called before the first frame update
    void Start()
    {
        ps1.Stop();
        ps2.Stop();
        on = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!on)
        {
            if (sw0.on && sw1.on)
            {
                on = true;
                scissor1.GetComponent<Renderer>().material = material[0];
                scissor2.GetComponent<Renderer>().material = material[0];
                scissor3.GetComponent<Renderer>().material = material[0];
                scissor4.GetComponent<Renderer>().material = material[0];
                scissor1.layer = 11;
                scissor1.tag = "Untagged";
                scissor2.layer = 11;
                scissor2.tag = "Untagged";
                scissor3.layer = 11;
                scissor3.tag = "Untagged";
                scissor4.layer = 11;
                scissor4.tag = "Untagged";

                effect.playPS();
                ps1.Play();
                ps2.Play();

                sw0.delete();
                sw1.delete();
                sw2.delete();
                sw3.delete();
                sw4.delete();
                sw5.delete();
            }
        }
      
    }
}
