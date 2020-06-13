using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchLinkSwitch : MonoBehaviour
{
    public GameObject Player;
    public GameObject[] Other_Gimmick;
    public GameObject Obj_With_Gimmick;
    public Material[] Mats;
    public TurnToThroughSands[] Wall_Through_Sands;
    public ParticleSystem ps1;
    public int obj_layer;
    public int frame;
    static bool gole = false;
    public bool isRot;

    //音をつけるために追加
    private GameObject audioManager;
    private Audio_Manager script;
    [SerializeField] private AudioClip audioClip;

    Renderer Switch_Renderer;
    int cnt;

    public swichEFonly_cobra effect;

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

        if(!gole)
        {
            ps1.Stop();
        }
        

        //音をつけるために追加
        audioManager = GameObject.Find("GameManager");
        script = audioManager.GetComponent<Audio_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        //cnt++;

        if (isRot == true)
        {
            transform.Rotate(10f * Time.deltaTime, 0, 20f * Time.deltaTime);
        }
        
        //if (cnt % frame == 0)
        //{
        //    Switch_Renderer.material = Mats[cnt / frame % Mats.Length];
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            gameObject.SetActive(false);

            for (int i = 0; i < Wall_Through_Sands.Length; i++)
            {
                Wall_Through_Sands[i].Set_Alpha();
            }
            
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
                    ps1.Play();
                    gole = true;
                    break;
                default:
                    break;
            }
            effect.playPS();
            script.PlaySE(audioClip);
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

        if (Other_Gimmick != null)
        {
            for (int i = 0; i < Other_Gimmick.Length; i++)
            {
                Other_Gimmick[i].GetComponent<TurnToThroughPlayer>().Set_Alpha();
            }
        }
        Player.transform.parent = Obj_With_Gimmick.transform;
        Player.GetComponent<Rigidbody>().isKinematic = true;
    }

    void Gimmick_Active_Lift_Down()
    {
        Obj_With_Gimmick.GetComponent<LiftMovement>().Lift_State = LiftMovement.LIFT_STATE.STATE_MOVE_DOWN;
    }
}