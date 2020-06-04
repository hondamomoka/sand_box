using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SWEF_three : MonoBehaviour
{
    public ParticleSystem ps1;
    public ParticleSystem ps2;
    public ParticleSystem ps3;
    public ParticleSystem ps4;

    // Start is called before the first frame update
    void Start()
    {
        ps1.Stop();
        ps2.Stop();
        ps3.Stop();
        ps4.Stop();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void playPS()
    {
        ps1.Play();
        ps2.Play();
        ps3.Play();
        ps4.Play();
    }
}
