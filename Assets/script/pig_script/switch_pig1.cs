﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switch_pig1 : MonoBehaviour
{
    public GameObject wall;
    //public switch_pig sw;
    int count = 0;
    public bool on;
    int max_count;
    public Material[] material;
    public SE_mng_cobra effect;

    //音をつけるために追加
    private GameObject audioManager;
    private Audio_Manager script;
    [SerializeField] private AudioClip audioClip;

    // Start is called before the first frame update
    void Start()
    {
        Transform mytra = this.transform;

        Vector3 size = mytra.localScale;

        max_count = (int)(size.x * size.y * 100);

        on = false;

        //音をつけるために追加
        audioManager = GameObject.Find("GameManager");
        script = audioManager.GetComponent<Audio_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(10f * Time.deltaTime, 0, 20f * Time.deltaTime);

        if (count > max_count)
        {
            on = true;
            count = 0;
            this.GetComponent<Renderer>().material = material[2];

            wall.layer = 0;
            wall.GetComponent<Renderer>().material = material[3];
            effect.playPS();
            script.PlaySE(audioClip);
        
            // sw.on += 1;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (on == false)
        {
            if (other.gameObject.CompareTag("sand_normal") || other.gameObject.CompareTag("sand_float"))
            {
                count++;
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (on == false)
        {
            if (other.gameObject.CompareTag("sand_normal") || other.gameObject.CompareTag("sand_float"))
            {
                count--;

                if(count<0)
                {
                    count = 0;
                }
            }
        }
    }

    public void reset_p()
    {
        on = false;
        this.GetComponent<Renderer>().material = material[1];

        wall.layer = 13;
        wall.GetComponent<Renderer>().material = material[0];
    }

    public void crea()
    {
        wall.GetComponent<Renderer>().material = material[0];
        wall.layer = 13;
        this.GetComponent<Renderer>().material = material[2];
    }
}
