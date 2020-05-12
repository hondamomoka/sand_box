﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switch_move : MonoBehaviour
{
    public move_cube cube;
    public move_cube cube2;
    int max_count;
    int count;
    bool c_mane;
    public Material[] material;

    // Start is called before the first frame update
    void Start()
    {
        cube.move = false;
        cube2.move = false;
        c_mane = true;

        Transform mytra = this.transform;
        Vector3 size = mytra.localScale;
        max_count = (int)(size.x * size.y * 100);
    }

    // Update is called once per frame
    void Update()
    {
        if(count>max_count)
        {
            if (cube.move == false&&cube2.move==false)
            {
                cube.move = true;
                cube2.move = true;
                c_mane = false;
                count = 0;
                this.GetComponent<Renderer>().material = material[1];
            }
        }

        if (cube.move == false && cube2.move == false)
        {
            this.GetComponent<Renderer>().material = material[0];
            c_mane = true;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(c_mane==true)
        {
            if (other.gameObject.CompareTag("sand_normal"))
            {
                count++;
            }
        }
      
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("sand_normal"))
        {
            count--;
            if(count<0)
            {
                count = 0;
            }
        }
    }

    public void switch_off()
    {
        this.GetComponent<Renderer>().material = material[0];
    }
}