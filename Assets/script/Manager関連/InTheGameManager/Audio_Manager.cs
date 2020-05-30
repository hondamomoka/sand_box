using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Manager : MonoBehaviour
{
    public AudioSource[] source;

    public float bgVol;
    public float seVol;

    void Awake()
    {
        source = GetComponents<AudioSource>();
        bgVol = 0.4f;
        seVol = 0.4f;
        source[0].volume = bgVol;
        source[1].volume = seVol;
    }

    public void PlayBGM(AudioClip audioClip)
    {
        source[0].volume = bgVol;
        source[0].clip = audioClip;
        source[0].Play();
    }

    //ギミック作動の際にギミック側で使ってもらう関数
    //これを使うとSEが1度だけ流れる
    //使い方
    //1.以下の変数を宣言
    // private GameObject audioManager;
    // private Audio_Manager script;
    // [SerializeField] private AudioClip audioClip;
    //2.Start(Awake)で以下を宣言
    //audioManager = GameObject.Find("GameManager");
    //script = audioManager.GetComponent<Audio_Manager>();
    //3.Unity側のScriptにaudioClipがアタッチできるようになってるので使いたい音をアタッチ
    //4.使いたい場面で以下を宣言
    //script.PlaySE(audioClip);
    //以上
    public void PlaySE(AudioClip audioClip)
    {
        source[1].PlayOneShot(audioClip,seVol);
    }
}