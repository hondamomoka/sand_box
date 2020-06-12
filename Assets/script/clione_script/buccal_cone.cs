using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buccal_cone : MonoBehaviour
{
    public int count;
    int count_max;
    public Material[] material;
    public GameObject gole;
    bool on;
    public delete_sand ds;
    public GameObject[] Sand_Creater;
    public ParticleSystem ps1;
    public ParticleSystem ps2;
    public GameObject ps3;
    public NeedleRot needl;
    public float meter;

    CreateSandsKyo[] Sands_Scripts;

    //音を流すため追加
    private GameObject audioManager;
    private Audio_Manager script;
    [SerializeField] private AudioClip audioClip1;
    [SerializeField] private AudioClip audioClip2;
    [SerializeField] private AudioClip audioClip3;
    private int soundFlag;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        count_max = 0;
        on = true;
        ps1.Stop();
        ps2.Stop();

        Sands_Scripts = new CreateSandsKyo[Sand_Creater.Length];

        for (int i = 0; i < Sand_Creater.Length; i++)
        {
            Sands_Scripts[i] = Sand_Creater[i].GetComponent<CreateSandsKyo>();
        }

        //音を流すため追加
        audioManager = GameObject.Find("GameManager");
        script = audioManager.GetComponent<Audio_Manager>();
        soundFlag = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(on==true)
        {
            if (count > 340)
            {
                meter= needl.safe_rate;

                gole.GetComponent<Renderer>().material = material[2];
                gole.layer = 14;
                gole.tag = "Untagged";
                ds.on = true;
                on = false;
                ps1.Play();
                ps2.Play();

                for (int i = 0; i < Sand_Creater.Length; i++)
                {
                    Sands_Scripts[i].isSandsDelete = true;
                }

                if (soundFlag == 3)
                {
                    script.PlaySE(audioClip3);
                    soundFlag = 4;
                }
                ps3.SetActive(false);
            }
            else if (count > 110 && soundFlag == 0)
            {
                script.PlaySE(audioClip1);
                soundFlag = 1;
            }
            else if (count > 220 && soundFlag == 1)
            {
                script.PlaySE(audioClip2);
                soundFlag = 3;
            }

            if (count < 220)
                soundFlag = 1;
            if (count < 110)
                soundFlag = 0;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("sand_normal"))
        {
            count++;
            other.GetComponent<Renderer>().material = material[1];
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("sand_normal"))
        {
            count--;
            other.GetComponent<Renderer>().material = material[0];
        }
    }
}
