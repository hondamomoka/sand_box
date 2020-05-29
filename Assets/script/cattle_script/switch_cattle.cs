using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switch_cattle : MonoBehaviour
{
    public bool on;
    public Material[] material;
    public GameObject cube;

    //音をつけるために追加
    private GameObject audioManager;
    private Audio_Manager script;
    [SerializeField] private AudioClip audioClip;

    // Start is called before the first frame update
    void Start()
    {
        on = false;

        //音をつけるために追加
        audioManager = GameObject.Find("GameManager");
        script = audioManager.GetComponent<Audio_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!on)
        {
            if (other.gameObject.CompareTag("player"))
            {
                on = true;
                cube.GetComponent<Renderer>().material = material[1];
                cube.layer = 13;
                this.GetComponent<Renderer>().material = material[0];
                script.PlaySE(audioClip);
            }
        }
       
    }
}
