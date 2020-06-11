using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turtle_mng : MonoBehaviour
{
    public switch_turtle switch1;
    public switch_turtle switch2;
    public GameObject cube;
    public Material[] material;
    public ParticleSystem ps1;
    public ParticleSystem ps2;
    bool end;
    public TurnToWall[] Wall;

    //音をつけるために追加
    private GameObject audioManager;
    private Audio_Manager script;
    [SerializeField] private AudioClip audioClip;

    // Start is called before the first frame update
    void Start()
    {
        ps1.Stop();
        ps2.Stop();
        end = false;
        //音をつけるために追加
        audioManager = GameObject.Find("GameManager");
        script = audioManager.GetComponent<Audio_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!end)
        {
            if (switch1.on && switch2.on)
            {
                ps1.Play();
                ps2.Play();
                cube.GetComponent<Renderer>().material = material[0];
                cube.layer = 14;

                if (!switch1.fin && !switch2.fin)
                    script.PlaySE(audioClip);

                switch1.fin = true;
                switch2.fin = true;
                end = true;

                for (int i = 0; i < Wall.Length; i++)
                {
                    Wall[i].Set_Wall();
                }
            }
        }
        
    }
}
