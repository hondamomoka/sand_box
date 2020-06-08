using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorWithScales : MonoBehaviour
{
    public GameObject Scales;
    public GameObject Player;
    public GameObject Goal;
    public GameObject Door_Switch;
    public GameObject Bucket;
    public GameObject[] SandCreater;
    public Material[] Door_Mats;

    public swichEFonly_cobra effect0;
    public swichEFonly_cobra effect1;
    public swichEFonly_cobra effect2;
    public ParticleSystem ps1;
    public bool isDestroySand;
    static int ps;

    GameObject[] obj_sands;

    Renderer Door_Renderer;
    Renderer[] Bucket_Renderer;
    ScalesBehaviour Scales_Script;
    SandInScales[] Sand_Script;

    //音をつけるために追加
    private GameObject audioManager;
    private Audio_Manager script;
    [SerializeField] private AudioClip audioClip;

    public enum DOOR_GIMMICK
    {
        NONE,
        IF_HANDLE_STAY_IN_LEFT,
        IF_HANDLE_STAY_IN_RIGHT,
        IF_EVENT_WITH_SWITCH,
    };

    public DOOR_GIMMICK Door_Gimmick;

    // Start is called before the first frame update
    void Start()
    {
        ps = 0;
        ps1.Stop();

        // 砂の取得
        obj_sands = SandCreater[0].GetComponent<CreateSandsKyo>().obj_sands;

        Door_Renderer = GetComponent<Renderer>();
        Bucket_Renderer = Bucket.GetComponentsInChildren<Renderer>();
        Scales_Script = Scales.GetComponent<ScalesBehaviour>();
        Sand_Script = new SandInScales[obj_sands.Length];

        for(int i = 0; i < obj_sands.Length; i++)
        {
            Sand_Script[i] = obj_sands[i].GetComponent<SandInScales>();
        }

        //音をつけるために追加
        audioManager = GameObject.Find("GameManager");
        script = audioManager.GetComponent<Audio_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        switch(Door_Gimmick)
        {
            case DOOR_GIMMICK.IF_HANDLE_STAY_IN_LEFT:
                If_Handle_Stay_In_Left();
                break;
            case DOOR_GIMMICK.IF_HANDLE_STAY_IN_RIGHT:
                If_Handle_Stay_In_Right();
                break;
            case DOOR_GIMMICK.IF_EVENT_WITH_SWITCH:
                If_Event_With_Switch();
                break;
            default:
                break;
        }
    }

    void If_Handle_Stay_In_Left()
    {
        if (Scales_Script.Handle_State == ScalesBehaviour.HANDLE_STATE.STATE_STAY_IN_LEFT &&
            Scales_Script.isPlayerInBucket == false &&
            Scales_Script.isWithPlayer == true)
        {
            if(ps==0)
            {
                effect1.playPS();
                ps = 1;
            }
           

            Door_Renderer.material = Door_Mats[1];

            // layer: wall_through_player
            gameObject.layer = 14;

            //if(isDestroySand == true)
            //{
            //    //for(int i = 0; i < obj_sands.Length; i++)
            //    //{
            //    //    Destroy(obj_sands[i]);

            //    //}
            //    Scales_Script.weights[0] = 50;
            //}

            if (Goal != null)
            {
                Goal.GetComponent<Renderer>().material = Door_Mats[1];
                // layer: wall_through_player
                Goal.layer = 14;

                if (ps == 1)
                {
                    effect2.playPS();
                    ps1.Play();
                    ps = 2;
                }
            }
        }
    }

    void If_Handle_Stay_In_Right()
    {
        if (Scales_Script.Handle_State == ScalesBehaviour.HANDLE_STATE.STATE_STAY_IN_RIGHT &&
            Scales_Script.isPlayerInBucket == false &&
            Scales_Script.isWithPlayer == true)
        {
            Door_Renderer.material = Door_Mats[1];

            // layer: wall_through_player
            gameObject.layer = 14;
            script.PlaySE(audioClip);
        }
    }

    void If_Event_With_Switch()
    {
        if(Door_Switch == null)
        {
            Door_Gimmick = DOOR_GIMMICK.IF_HANDLE_STAY_IN_LEFT;
            Door_Renderer.material = Door_Mats[1];

            // layer: wall_through_sands_green
            gameObject.layer = 25;
            
            for (int i = 0; i < obj_sands.Length; i++)
            {

                Destroy(obj_sands[i]);
            }

            //Scales_Script.weights[0] = 50;
            Scales_Script.Reset_Sands(SandCreater[1]);

            for (int i = 0; i < Bucket_Renderer.Length - 1; i++)
            {
                Bucket_Renderer[i].material = Door_Mats[1];
            }

            Door_Mats[1] = Door_Mats[3];
            effect0.playPS();
            script.PlaySE(audioClip);
        }
    }
}
