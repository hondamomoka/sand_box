﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchLinkSwitch : MonoBehaviour
{
    public GameObject Player;
    public GameObject[] Other_Gimmick;
    public GameObject Obj_With_Gimmick;
    public Material[] Mats;
    public int obj_layer;
    public int frame;

    //音をつけるために追加
    private GameObject audioManager;
    private Audio_Manager script;
    [SerializeField] private AudioClip audioClip;

    Renderer Switch_Renderer;
    int cnt;

    public enum GIMMICK
    {
        GIMMICK_NONE,
        GIMMICK_ACTIVE_OTHER_SWITCH,
        GIMMICK_ACTIVE_LIFT_MOVE_UP,
        GIMMICK_ACTIVE_LIFT_MOVE_DOWN,
    };

    public GIMMICK Gimmick;

    // Start is called before the first frame update
    void Start()
    {
        Switch_Renderer = GetComponent<Renderer>();

        cnt = 0;

        //音をつけるために追加
        audioManager = GameObject.Find("GameManager");
        script = audioManager.GetComponent<Audio_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        cnt++;

        if (cnt % frame == 0)
        {
            Switch_Renderer.material = Mats[cnt / frame % Mats.Length];
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            gameObject.SetActive(false);
            script.PlaySE(audioClip);
            switch (Gimmick)
            {
                case GIMMICK.GIMMICK_ACTIVE_OTHER_SWITCH:
                    Gimmick_Active_Other_Switch();
                    break;
                case GIMMICK.GIMMICK_ACTIVE_LIFT_MOVE_UP:
                    Gimmick_Active_Lift_UP();
                    break;
                case GIMMICK.GIMMICK_ACTIVE_LIFT_MOVE_DOWN:
                    Gimmick_Active_Lift_Down();
                    break;
                default:
                    break;
            }
        }
    }

    void Gimmick_Active_Other_Switch()
    {
        if (Other_Gimmick != null)
        {
            for (int i = 0; i < Other_Gimmick.Length; i++)
            {
                Other_Gimmick[i].SetActive(true);
            }
        }

        Obj_With_Gimmick.GetComponent<Renderer>().material = Mats[Mats.Length - 1];
        Obj_With_Gimmick.layer = obj_layer;
    }

    void Gimmick_Active_Lift_UP()
    {
        Obj_With_Gimmick.GetComponent<LiftMovement>().Lift_State = LiftMovement.LIFT_STATE.STATE_MOVE_UP;

        Player.transform.parent = Obj_With_Gimmick.transform;
    }

    void Gimmick_Active_Lift_Down()
    {
        Obj_With_Gimmick.GetComponent<LiftMovement>().Lift_State = LiftMovement.LIFT_STATE.STATE_MOVE_DOWN;
    }
}