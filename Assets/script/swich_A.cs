using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swich_A : MonoBehaviour
{
    public GameObject wall;
    public Material[] material;
    public swichEFonly_cobra effect;
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
        transform.Rotate(10f * Time.deltaTime, 0, 20f * Time.deltaTime);

        if (count>10)
        {
            on = true;
            count = 0;
            this.GetComponent<Renderer>().material = material[0];
            effect.playPS();
            script.PlaySE(audioClip);

            Destroy(wall.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (on == false)
        {
            if (other.gameObject.CompareTag("sand_normal")|| other.gameObject.CompareTag("sand_float"))
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
