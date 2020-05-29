using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switch_pig : MonoBehaviour
{
    public int count;
    bool on;
    public switch_pig1 switch1;
    public switch_pig1 switch2;
    public Material[] material;
    public GameObject sw;

    //音をつけるために追加
    private GameObject audioManager;
    private Audio_Manager script;
    [SerializeField] private AudioClip audioClip;

    // Start is called before the first frame update
    void Start()
    {
        on = false;
        count = 0;

        //音をつけるために追加
        audioManager = GameObject.Find("GameManager");
        script = audioManager.GetComponent<Audio_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        count = 0;

        if(!on)
        {
            if (switch1.on==true)
            {
                count += 1;
            }
            if (switch2.on==true)
            {
                count += 1;
            }

            if(count==1)
            {
                this.GetComponent<Renderer>().material = material[0];
            }
            else if(count==2)
            {
                this.GetComponent<Renderer>().material = material[2];
            }
        }
    }
       

    private void OnTriggerEnter(Collider other)
    {
        if (count ==1)
        {
            if (other.gameObject.CompareTag("player"))
            {
                switch1.reset_p();
                switch2.reset_p();
                this.GetComponent<Renderer>().material = material[1];
                script.PlaySE(audioClip);

                on = false;
            }
        }
        else if(count==2)
        {
            if (other.gameObject.CompareTag("player"))
            {
                on = true;
                switch1.crea();
                switch2.crea();
                this.GetComponent<Renderer>().material = material[1];
                script.PlaySE(audioClip);

                sw.layer = 13;
                sw.GetComponent<Renderer>().material = material[3];
            }
        }
    }

}
