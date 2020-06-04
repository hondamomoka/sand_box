using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switch_move : MonoBehaviour
{
    public move_cube cube;
    public move_cube cube2;
    public SE_mng_cobra se;
    public int max_count;
    public int count;
    bool c_mane;
    public Material[] material;

    //音をつけるために追加
    private GameObject audioManager;
    private Audio_Manager script;
    [SerializeField] private AudioClip audioClip;

    // Start is called before the first frame update
    void Start()
    {
        cube.move = false;
        cube2.move = false;
        c_mane = true;

        Transform mytra = this.transform;
        Vector3 size = mytra.localScale;
        max_count = (int)(size.x * size.y * 100);

        //音をつけるために追加
        audioManager = GameObject.Find("GameManager");
        script = audioManager.GetComponent<Audio_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(10f * Time.deltaTime, 0, 20f * Time.deltaTime);

        if (count>max_count)
        {
            if (cube.move == false&&cube2.move==false)
            {
                cube.move = true;
                cube2.move = true;
                c_mane = false;
                count = 0;
                this.GetComponent<Renderer>().material = material[1];
                script.PlaySE(audioClip);
                se.playPS();
            }
        }

        if (cube.move == false && cube2.move == false)
        {
            this.GetComponent<Renderer>().material = material[0];
            c_mane = true;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(c_mane==true)
        {
            if (other.gameObject.CompareTag("sand_normal") || other.gameObject.CompareTag("sands"))
            {
                count++;
            }
        }
      
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("sand_normal") || other.gameObject.CompareTag("sands"))
        {
            count--;
            if(count<0)
            {
                count = 0;
            }
        }
    }

    public void switch_off()
    {
        this.GetComponent<Renderer>().material = material[0];
    }
}
