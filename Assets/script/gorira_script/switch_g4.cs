using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switch_g4 : MonoBehaviour
{
    public GameObject wall;
    public Material[] material;
    int count = 0;
    bool on = false;

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
        if (count > 10)
        {
            on = true;
            count = 0;
            this.GetComponent<Renderer>().material = material[0];
            script.PlaySE(audioClip);

            //Wallの色をゴリラ色から黄（半透明）に
            wall.layer = 14;
            wall.GetComponent<Renderer>().material = material[1];
            script.PlaySE(audioClip);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (on == false)
        {
            if (other.gameObject.CompareTag("sand_normal") || other.gameObject.CompareTag("sand_float"))
            {
                count++;
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (on == false)
        {
            if (other.gameObject.CompareTag("sand_normal") || other.gameObject.CompareTag("sand_float"))
            {
                count--;
            }
        }
    }

}
