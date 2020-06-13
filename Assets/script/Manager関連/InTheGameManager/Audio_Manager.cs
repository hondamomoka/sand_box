using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Manager : MonoBehaviour
{
    //0はBGM 1はSE 2は砂の音
    public AudioSource[] source;

    public float bgVol;
    public float seVol;
    public float sandVol;

    public bool clear;

    void Awake()
    {
        source  = GetComponents<AudioSource>();
        bgVol   = 0.4f;
        seVol   = 0.4f;
        sandVol = 0.4f;
        source[0].volume = bgVol;
        source[1].volume = seVol;
        source[2].volume = sandVol;
        source[2].loop = true;

        clear = false;
    }

    public void PlayBGM(AudioClip audioClip)
    {
        source[0].volume = bgVol;
        source[0].clip = audioClip;

        source[0].Play();
    }

    public void PlaySandSE(AudioClip audioClip)
    {
        source[2].volume = sandVol;
        source[2].clip = audioClip;

        source[2].Play();
    }

    //ギミック作動の際にギミック側で使ってもらう関数
    //これを使うとSEが1度だけ流れる
    //使い方
    //1.以下の変数を宣言
    //[SerializeField] private AudioClip audioClip;
    //2.Unity側のScriptにaudioClipがアタッチできるようになってるので使いたい音をアタッチ
    //3.使いたい場面で以下を宣言
    //Game_Manager.Instance.am.PlaySE(audioClip);
    //以上
    public void PlaySE(AudioClip audioClip)
    {
        source[1].PlayOneShot(audioClip,seVol);
    }
}