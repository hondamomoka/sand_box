﻿using System.Collections;
//using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalesHelper : MonoBehaviour
{
    public GameObject Scales;
    public GameObject Bucket_Board;
    public GameObject SandCreater;
    public GameObject[] obj_sands;
    public GameObject Stage;


    public swichEFonly_cobra effect;

    ScalesBehaviour Scales_Script;
    Collider Bucket_Board_Collider;
    SandInScales[] Sands_Script;

    bool isHelper;

    //音をつけるために追加
    private GameObject audioManager;
    private Audio_Manager script;
    [SerializeField] private AudioClip audioClip;

    // Start is called before the first frame update
    void Start()
    {
        Scales_Script = Scales.GetComponent<ScalesBehaviour>();

        Bucket_Board_Collider = Bucket_Board.GetComponent<Collider>();

        // 砂の取得
        obj_sands = SandCreater.GetComponent<CreateSandsKyo>().obj_sands;

        Sands_Script = new SandInScales[obj_sands.Length];
        for (int i = 0; i < obj_sands.Length; i++)
        {
            Sands_Script[i] = obj_sands[i].GetComponent<SandInScales>();
        }

        //音をつけるために追加
        audioManager = GameObject.Find("GameManager");
        script = audioManager.GetComponent<Audio_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isHelper == true && Scales_Script.Handle_State != ScalesBehaviour.HANDLE_STATE.STATE_RETURN_BALANCE_FROM_HELPER)
        {
            Bucket_Board_Collider.isTrigger = false;
            isHelper = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("player") && Scales_Script.weights[0] > 50)
        {
            Scales_Script.Handle_State = ScalesBehaviour.HANDLE_STATE.STATE_RETURN_BALANCE_FROM_HELPER;
            Bucket_Board_Collider.isTrigger = true;
            Scales_Script.Handle.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            isHelper = true;

            for (int i = 0; i < obj_sands.Length; i++)
            {
                if (Sands_Script[i].Sand_State != SandInScales.SAND_STATE.SAND_STATE_STAGE ||
                    Sands_Script[i].Sand_State != SandInScales.SAND_STATE.SAND_STATE_FALLING_OUT_BUCKET)
                {
                    Sands_Script[i].Sand_State = SandInScales.SAND_STATE.SAND_STATE_THROUGH_SCALES;

                    transform.parent = Stage.transform;

                    // layer: sand_normal
                    gameObject.layer = 8;
                }
            }

            effect.playPS();
            script.PlaySE(audioClip);
        }
    }

    public void Set_Active(Material m)
    {
        // layer: default
        gameObject.layer = 0;
        GetComponent<Renderer>().material = m;
    }
}
