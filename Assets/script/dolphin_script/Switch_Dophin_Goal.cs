using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch_Dophin_Goal : MonoBehaviour
{
    public int count;
    //int max_count;
    public bool on;
    public Material[] material;
    public GameObject cube;
    public swichEFonly_cobra effect;
    public ParticleSystem ps1;

    //音をつけるために追加
    private GameObject audioManager;
    private Audio_Manager script;
    [SerializeField] private AudioClip audioClip;

    // Start is called before the first frame update
    void Start()
    {
        ps1.Stop();
        Transform mytra = this.transform;

        Vector3 size = mytra.localScale;

        //max_count = (int)(size.x * size.y * 100);
        on = false;

        //音をつけるために追加
        audioManager = GameObject.Find("GameManager");
        script = audioManager.GetComponent<Audio_Manager>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(10f * Time.deltaTime, 0, 20f * Time.deltaTime);

        if (!on)
        {
            if (count > 46)
            {
                on = true;
                cube.GetComponent<Renderer>().material = material[1];
                cube.layer = 14;
                cube.tag = "Untagged";
                this.GetComponent<Renderer>().material = material[0];
                effect.playPS();
                ps1.Play();
                script.PlaySE(audioClip);
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (!on)
        {
            if (other.gameObject.CompareTag("sand_normal"))
            {
                count++;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!on)
        {
            if (other.gameObject.CompareTag("sand_normal"))
            {
                count--;

                if (count < 0)
                {
                    count = 0;
                }
            }
        }
    }
}
