using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switch_g0 : MonoBehaviour
{
    public Material[] material;
    //public GameObject g_cube;
   // public GameObject g_cube2;

   public int count;
    int max_count;
    public int switch_type;//０：赤（プレイヤーが押せる)  １：青（砂が押せる））

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        switch_type = 2;

        Transform mytra = this.transform;
        Vector3 size = mytra.localScale;
        max_count = (int)(size.x * size.y * 100);
    }

    // Update is called once per frame
    void Update()
    {
        if (switch_type == 0)
        {

        }
        else if (switch_type == 1)
        {
            if (count > max_count)
            {
                //スイッチの色を変換：青から無
                switch_type = 2;
                this.GetComponent<Renderer>().material = material[2];

                //指定キューブの色を変換：青から赤
                //g_cube2.layer = 14;
                //g_cube2.GetComponent<Renderer>().material = material[0];

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
                ////スイッチの色を赤から青に
                //switch_type = 1;
                //this.GetComponent<Renderer>().material = material[1];

                ////キューブの色を青から赤に
                //g_cube.layer = 14;
                //g_cube.GetComponent<Renderer>().material = material[0];
            }
        }
        else if (switch_type == 1)
        {
            if (other.gameObject.CompareTag("sand_normal"))
            {
                count++;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(switch_type==1)
        {
            if (other.gameObject.CompareTag("sand_normal"))
            {
                count--;
            }
        }

       
    }
}
