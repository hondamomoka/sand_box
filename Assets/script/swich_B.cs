using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swich_B : MonoBehaviour
{
    public GameObject wall;
    bool on = false;
    public Material[] material;

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

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(10f * Time.deltaTime, 0, 20f * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (on == false)
        {
            if (other.gameObject.CompareTag("player"))
            {
                on = true;
                wall.GetComponent<Renderer>().material = material[1];
                wall.layer = 14;
                this.GetComponent<Renderer>().material = material[0];
                script.PlaySE(audioClip);
            }
        }
    }
}
