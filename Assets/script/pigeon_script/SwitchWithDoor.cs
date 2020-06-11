using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchWithDoor : MonoBehaviour
{
    public GameObject Door;
    public Material[] Mats;

    public swichEFonly_cobra effect;

    //音をつけるために追加
    private GameObject audioManager;
    private Audio_Manager script;
    [SerializeField] private AudioClip audioClip;

    public enum SWITCH_FUNCTIN
    {
        NONE,
        DOOR_THROUGH_PLAYER,
        DESTROY_DOOR,
    }

    public SWITCH_FUNCTIN Switch_Function;

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
        if (other.gameObject.CompareTag("player"))
        {
            switch(Switch_Function)
            {
                case SWITCH_FUNCTIN.DOOR_THROUGH_PLAYER:
                    effect.playPS();
                    Door_Through_Player();
                    break;
                case SWITCH_FUNCTIN.DESTROY_DOOR:
                    effect.playPS();
                    Destroy_Door();
                    script.PlaySE(audioClip);
                    break;
                default:
                    break;
            }
        }
    }

    void Door_Through_Player()
    {
        Door.GetComponent<Renderer>().material = Mats[0];

        // layer: wall_through_player
        Door.layer = 14;
    }

    void Destroy_Door()
    {
        Destroy(Door);
    }
}
