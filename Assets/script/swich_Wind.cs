using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swich_Wind : MonoBehaviour
{
    public wind_2 wind;
    bool on = false;
    public swichEFonly_cobra effect;

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

                wind.start();
                effect.playPS();
                script.PlaySE(audioClip);

                Destroy(this.gameObject);
            }
        }
    }
}
