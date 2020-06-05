using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turtle_mng : MonoBehaviour
{
    public switch_turtle switch1;
    public switch_turtle switch2;
    public GameObject cube;
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
        if(switch1.on&&switch2.on)
        {
            cube.GetComponent<Renderer>().material = material[0];
            cube.layer = 14;

            if (!switch1.fin && !switch2.fin)
                script.PlaySE(audioClip);

            switch1.fin = true;
            switch2.fin = true;
        }
    }
}
