using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wind : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip;
    private bool StartWind;

    // Start is called before the first frame update
    void Start()
    {
        Game_Manager.Instance.am.clear = false;
        Game_Manager.Instance.am.source[1].clip = audioClip;
        Game_Manager.Instance.am.source[1].loop = true;

        StartWind = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!StartWind)
        {
            Game_Manager.Instance.am.source[1].Play();
            StartWind = true;
        }
        transform.Rotate(0, 2.0f, 0);
        if (Game_Manager.Instance.am.clear)
            Game_Manager.Instance.am.source[1].Stop();
    }

    public void Stop_WindSE()
    {
        Game_Manager.Instance.am.source[1].Stop();
    }
}
