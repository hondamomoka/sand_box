﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class postp_ocean : MonoBehaviour
{
    PostProcessVolume posv;
    Bloom bloom;
    Bloom bloom2;
    public bool on;
    //PostProcessVolume posV;

    // Start is called before the first frame update
    void Start()
    {
        on = false;
        bloom = ScriptableObject.CreateInstance<Bloom>();
        bloom.enabled.Override(true);
        bloom.intensity.Override(10f);
        bloom2 = ScriptableObject.CreateInstance<Bloom>();
        bloom2.enabled.Override(false);
        bloom2.intensity.Override(10f);

        posv = PostProcessManager.instance.QuickVolume(gameObject.layer, 0f, bloom2);
    }

    // Update is called once per frame
    void Update()
    {
        if (on)
        {
            posv = PostProcessManager.instance.QuickVolume(gameObject.layer, 0f, bloom);
            on = false;
        }
    }
}
