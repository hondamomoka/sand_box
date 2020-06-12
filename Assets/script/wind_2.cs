using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wind_2 : MonoBehaviour
{
    public bool on=false;
    public GameObject coll;
    public ParticleSystem ps1;
    public ParticleSystem ps2;

    //音をつけるために追加
    private GameObject audioManager;
    private Audio_Manager script;
    [SerializeField] private AudioClip audioClip;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        ps1.Stop();
        ps2.Stop();

        //音をつけるために追加
        audioManager = GameObject.Find("GameManager");
        script = audioManager.GetComponent<Audio_Manager>();
        time = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(on)
        {
            transform.Rotate(0, 2.0f, 0);
            time += Time.deltaTime;
            if (time > 5.0f)
            {
                script.PlaySE(audioClip);
                time = 0;
            }
        }
        
    }

    public void start()
    {
        on = true;
        coll.gameObject.tag = "wind";
        ps1.Play();
        ps2.Play();
    }

    public void Stop_WindSE()
    {
        script.source[1].Stop();
    }
}
