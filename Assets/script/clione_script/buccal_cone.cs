﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buccal_cone : MonoBehaviour
{
    public int count;
    int count_max;
    public Material[] material;
    public GameObject gole;
    bool on;
    public delete_sand ds;
    public GameObject[] Sand_Creater;
    public ParticleSystem ps1;
    public ParticleSystem ps2;

    CreateSandsKyo[] Sands_Scripts;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        count_max = 0;
        on = true;
        ps1.Stop();
        ps2.Stop();

        Sands_Scripts = new CreateSandsKyo[Sand_Creater.Length];

        for (int i = 0; i < Sand_Creater.Length; i++)
        {
            Sands_Scripts[i] = Sand_Creater[i].GetComponent<CreateSandsKyo>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(on==true)
        {
            if (count > 340)
            {
                gole.GetComponent<Renderer>().material = material[2];
                gole.layer = 14;
                gole.tag = "Untagged";
                ds.on = true;
                on = false;
                ps1.Play();
                ps2.Play();

                for (int i = 0; i < Sand_Creater.Length; i++)
                {
                    Sands_Scripts[i].isSandsDelete = true;
                }
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("sand_normal"))
        {
            count++;
            other.GetComponent<Renderer>().material = material[1];
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("sand_normal"))
        {
            count--;
            other.GetComponent<Renderer>().material = material[0];
        }
    }
}
