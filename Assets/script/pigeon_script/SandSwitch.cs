using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandSwitch : MonoBehaviour
{
    public PlayerInScales Player;
    public ScalesHelper Other_Switch;
    public Material[] Mats;
    public int cnt;
    public int cnt_max;
    public bool isActive;

    public swichEFonly_cobra effect;
    public swichEFonly_cobra effect2;

    Renderer Switch_Renderer;

    //音をつけるために追加
    private GameObject audioManager;
    private Audio_Manager script;
    [SerializeField] private AudioClip audioClip;

    // Start is called before the first frame update
    void Start()
    {
        //isActive = false;
        Switch_Renderer = GetComponent<Renderer>();
        cnt = 0;

        //音をつけるために追加
        audioManager = GameObject.Find("GameManager");
        script = audioManager.GetComponent<Audio_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(10f * Time.deltaTime, 0, 20f * Time.deltaTime);

        if (Player.isOutBucket == true && isActive == false)
        {
            effect.playPS();
            isActive = true;
            Switch_Renderer.material = Mats[0];

            // layer: wall_through_player
            gameObject.layer = 14;
        }

        if (cnt >= cnt_max)
        {
            effect2.playPS();
            Other_Switch.Set_Active(Mats[1]);
            script.PlaySE(audioClip);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("sand_normal") && isActive == true)
        {
            cnt++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("sand_normal") && isActive == true)
        {
            cnt--;
        }
    }
}
