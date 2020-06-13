using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wind_2 : MonoBehaviour
{
    public bool on=false;
    public GameObject coll;
    public ParticleSystem ps1;
    public ParticleSystem ps2;

    [SerializeField] private AudioClip audioClip;

    // Start is called before the first frame update
    void Start()
    {
        ps1.Stop();
        ps2.Stop();

        Game_Manager.Instance.am.clear = false;
        if (Game_Manager.Instance.am.source[1].isPlaying)
            Game_Manager.Instance.am.source[1].Stop();
    }

    // Update is called once per frame
    void Update()
    {
        if (on)
        {
            transform.Rotate(0, 2.0f, 0);
            if (Game_Manager.Instance.am.clear)
                Game_Manager.Instance.am.source[1].Stop();
        }
    }

    public void start()
    {
        on = true;
        coll.gameObject.tag = "wind";
        ps1.Play();
        ps2.Play();

        Game_Manager.Instance.am.source[1].clip = audioClip;
        Game_Manager.Instance.am.source[1].loop = true;
        Game_Manager.Instance.am.source[1].Play();
    }

    public void Stop_WindSE()
    {
        Game_Manager.Instance.am.source[1].Stop();
    }
}
