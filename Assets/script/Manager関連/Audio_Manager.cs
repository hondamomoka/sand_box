using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Manager : MonoBehaviour
{
    private AudioSource source;

    [SerializeField] private AudioClip audioClip1;

    
    [SerializeField] private AudioClip titleBGM;


    void Awake()
    {
        source = GetComponent<AudioSource>();
        source.clip = titleBGM;
    }

    void Start()
    {
        source.Play();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            source.PlayOneShot(audioClip1);
        }
    }

    //ギミック作動の際にギミック側で使ってもらう関数
    //これを使うとSEが1度だけ流れる
    //使い方
    //1.以下の変数を宣言
    // GameObject audioManager;
    // Audio_Manager script;
    // [SerializeField] private AudioClip audioClip;
    //2.Start(Awake)で以下を宣言
    //audioManager = GameObject.Find("GameManager");
    //script = fadeManager.GetComponent<Audio_Manager>();
    //3.Unity側のScriptにaudioClipがアタッチできるようになってるので使いたい音をアタッチ
    //4.使いたい場面で以下を宣言
    //script.PlaySE(audioClip);
    //以上
    public void PlaySE(AudioClip audioClip)
    {
        source.PlayOneShot(audioClip);
    }
}