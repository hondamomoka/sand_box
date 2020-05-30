using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageAudio_Manager : MonoBehaviour
{
    private GameObject audioManager;
    private Audio_Manager script;
    [SerializeField] private AudioClip stageBGM;

    void Awake()
    {
        audioManager = GameObject.Find("GameManager");
        script = audioManager.GetComponent<Audio_Manager>();
    }

    void Start()
    {
        script.PlayBGM(stageBGM);
    }
}
