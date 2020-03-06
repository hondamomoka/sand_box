﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swich : MonoBehaviour
{
    public GameObject wall;
    public int count = 0;
    bool on = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(count>20)
        {
            on = true;
            count = 0;
            transform.position += new Vector3(0, 0, 0.2f);

            Destroy(wall);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (on == false)
        {
            if (other.gameObject.CompareTag("sand"))
            {
                count++;
            }
        }
    }
      
}