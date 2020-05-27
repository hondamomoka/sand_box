﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class postp : MonoBehaviour
{
    PostProcessVolume posv;
    Bloom bloom;
    public bool on;
    //PostProcessVolume posV;

    // Start is called before the first frame update
    void Start()
    {
        on = false;
        bloom = ScriptableObject.CreateInstance<Bloom>();
        bloom.enabled.Override(true);
        bloom.intensity.Override(20f);

        
    }

    // Update is called once per frame
    void Update()
    {
        if(on)
        {
            posv = PostProcessManager.instance.QuickVolume(gameObject.layer, 0f, bloom);
        }
    }
}
