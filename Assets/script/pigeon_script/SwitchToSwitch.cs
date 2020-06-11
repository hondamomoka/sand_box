﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchToSwitch : MonoBehaviour
{
    public GameObject other_switch;
    public Material Mat;

    //音をつけるために追加
    private GameObject audioManager;
    private Audio_Manager script;
    [SerializeField] private AudioClip audioClip;

    // Start is called before the first frame update
    void Start()
    {
        //音をつけるために追加
        audioManager = GameObject.Find("GameManager");
        script = audioManager.GetComponent<Audio_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("player"))
        {
            other_switch.GetComponent<Collider>().isTrigger = true;
            other_switch.GetComponent<Renderer>().material = Mat;
            script.PlaySE(audioClip);
        }
    }
}
