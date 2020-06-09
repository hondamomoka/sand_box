using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switch_g0 : MonoBehaviour
{
    public Material[] material;
    //public GameObject g_cube;
    //public GameObject g_cube2;
    public swichEFonly_cobra effect;
    public swichEFonly_cobra effect2;

    public int count;
    int max_count;
    public int switch_type;//０：黄（プレイヤーが押せる)  １：赤（砂が押せる））

    //音をつけるために追加
    private GameObject audioManager;
    private Audio_Manager script;
    [SerializeField] private AudioClip audioClip;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        switch_type = 2;

        Transform mytra = this.transform;
        Vector3 size = mytra.localScale;
        max_count = (int)(size.x * size.y * 100);

        //音をつけるために追加
        audioManager = GameObject.Find("GameManager");
        script = audioManager.GetComponent<Audio_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(10f * Time.deltaTime, 0, 20f * Time.deltaTime);

        if (switch_type == 0)
        {

        }
        else if (switch_type == 1)
        {
            if (count > max_count)
            {
                //スイッチの色を変換：赤から無
                switch_type = 2;
                this.GetComponent<Renderer>().material = material[2];
                

                //指定キューブの色を変換：赤から黄
                //g_cube2.layer = 14;
                //g_cube2.GetComponent<Renderer>().material = material[3];

                count = 0;
                effect.playPS();
                script.PlaySE(audioClip);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (switch_type == 0)
        {
            if (other.gameObject.CompareTag("player"))
            {
                //スイッチの色を黄から赤に
                switch_type = 1;
                this.GetComponent<Renderer>().material = material[1];

                //キューブの色を赤から黄に
                //g_cube.layer = 14;
                //g_cube.GetComponent<Renderer>().material = material[3];

                effect2.playPS();
            }
        }
        else if (switch_type == 1)
        {
            if (other.gameObject.CompareTag("sand_normal"))
            {
                count++;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(switch_type==1)
        {
            if (other.gameObject.CompareTag("sand_normal"))
            {
                count--;
            }
        }

       
    }
}
