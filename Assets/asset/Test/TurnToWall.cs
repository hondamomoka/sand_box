﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnToWall : MonoBehaviour
{
    public Material mat;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Set_Wall()
    {
        GetComponent<Renderer>().material = mat;
        // layer: default
        gameObject.layer = 0;
    }
}
