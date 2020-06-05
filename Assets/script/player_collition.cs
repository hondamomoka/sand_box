using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_collition : MonoBehaviour
{
    //音をつけるために追加
    private GameObject audioManager;
    private Audio_Manager script;
    [SerializeField] private AudioClip audioClip;


    // Start is called before the first frame update
    void Start()
    {
        //音をつけるために追加
        audioManager = GameObject.Find("GameManager");
        script = audioManager.GetComponent<Audio_Manager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("stage"))
        {
            script.PlaySE(audioClip);
            Debug.Log("聞こえてる？");
        }
    }
}
