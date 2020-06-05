using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switch_g2 : MonoBehaviour
{
    public Material[] material;
    public GameObject g_cube;
   // public GameObject g_cube2;
    public GameObject g_cube3;
    public Mesh[] switch_mesh;

    int count;
    int max_count;
    int switch_type;//０：黄（プレイヤーが押せる)  １：赤（砂が押せる））

    //音をつけるために追加
    private GameObject audioManager;
    private Audio_Manager script;
    [SerializeField] private AudioClip audioClip;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        switch_type = 1;

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
        if (switch_type == 0)
        {

        }
        else
        {
            if (count > max_count)
            {
                //スイッチの色を変換：赤から黄
                switch_type = 0;
                this.GetComponent<Renderer>().material = material[0];
                this.GetComponent<MeshFilter>().sharedMesh = switch_mesh[1];
                script.PlaySE(audioClip);

                //指定キューブの色を変換：黄から赤
                //g_cube2.layer = 13;
                //g_cube2.GetComponent<Renderer>().material = material[1];

                g_cube3.layer = 13;
                g_cube3.GetComponent<Renderer>().material = material[3];
                script.PlaySE(audioClip);

                count = 0;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (switch_type == 0)
        {
            if (other.gameObject.CompareTag("player"))
            {
                //スイッチの色を黄から赤に
                switch_type = 1;
                this.GetComponent<Renderer>().material = material[1];
                this.GetComponent<MeshFilter>().sharedMesh = switch_mesh[0];

                //キューブの色を赤から黄（半透明）に
                g_cube.layer = 14;
                g_cube.GetComponent<Renderer>().material = material[2];
            }
        }
        else
        {
            if (other.gameObject.CompareTag("sand_normal"))
            {
                count++;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("sand_normal"))
        {
            count--;
        }
    }
}
