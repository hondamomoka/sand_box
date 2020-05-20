using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using System.Collections;

public class Audio_Manager : MonoBehaviour
{
    private AudioSource source;

    [SerializeField] private AudioClip audioClip1;
    [SerializeField] private AudioClip audioClip2;
    [SerializeField] private AudioClip audioClip3;
    [SerializeField] private AudioClip audioClip4;
    [SerializeField] private AudioClip audioClip5;
    [SerializeField] private AudioClip audioClip6;
    [SerializeField] private AudioClip audioClip7;
    [SerializeField] private AudioClip audioClip8;
    [SerializeField] private AudioClip audioClip9;


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
        if (Input.GetKeyDown(KeyCode.K))
        {
            source.PlayOneShot(audioClip1);
        }

    }
}
