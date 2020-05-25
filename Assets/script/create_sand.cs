﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class create_sand : MonoBehaviour {

    public GameObject sand;
    GameObject[] obj_sand;
    float x;
    float y;
    public bool on;
    // Use this for initialization
    void Start()
    {
        on = false;
        obj_sand = new GameObject[400];
       // float count = -2.8f;
       // float y = 0.0f;

        Transform mytra = this.transform;

        Vector3 size = mytra.localScale;
        Vector3 pos = mytra.position;

        x= pos.x - (size.x / 2.0f);
        y= pos.y - (size.y / 2.0f);

        for (int j = 0; j < (int)(size.y * 10.0f); j++)
        {
            for (int i = 0; i < (int)(size.x * 10.0f); i++)
            {
                obj_sand[i] = Instantiate(sand, new Vector3(x + ((float)i / 10.0f), y + ((float)j / 10.0f), -0.1f), Quaternion.identity);

                obj_sand[i].transform.parent = GameObject.Find("stage").transform;

                //count += 0.1f;

                //if (count > 2.8)
                //{
                //    count = -2.8f;
                //    y += 0.1f;
                //}
            }
        }
    }
	
	// Update is called once per frame
	void Update () {

      
    }

    
}
