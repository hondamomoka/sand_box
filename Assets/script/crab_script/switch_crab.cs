using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switch_crab : MonoBehaviour
{
    public int count;
    int max_count;
    public bool on;
    public Material[] material;
    public GameObject kani;
    public switch_crab sw1;
    public switch_crab sw2;
    bool end;

    //音をつけるために追加
    private GameObject audioManager;
    private Audio_Manager script;
    [SerializeField] private AudioClip audioClip;

    // Start is called before the first frame update
    void Start()
    {
        Transform mytra = this.transform;

        Vector3 size = mytra.localScale;

        max_count = (int)(size.x * size.y * 100);
        end = false;

        //音をつけるために追加
        audioManager = GameObject.Find("GameManager");
        script = audioManager.GetComponent<Audio_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!end)
        {
            if (!on)
            {
                if (count > max_count)
                {
                    kani.GetComponent<Renderer>().material = material[1];
                    this.GetComponent<Renderer>().material = material[0];
                    on = true;
                    count = 0;
                    sw1.sw_on();
                    sw2.sw_on();

                    script.PlaySE(audioClip);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("sand_normal"))
        {
            count++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("sand_normal"))
        {
            count--;
            if(count<0)
            {
                count = 0;
            }
        }
    }

    public void sw_on()
    {
        on = false;
        this.GetComponent<Renderer>().material = material[2];
    }

    public void delete()
    {
        end = true;
        this.GetComponent<Renderer>().material = material[3];
    }
}
