using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switch_g3 : MonoBehaviour
{
    public Material[] material;
    public GameObject g_cube;
    public switch_g0 switch0;

    int count;
    int max_count;
    int switch_type;//０：赤（プレイヤーが押せる)  １：青（砂が押せる））

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        switch_type = 0;

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
        else
        {
            if (count > max_count)
            {
                //スイッチの色を青から赤に
                switch_type = 3;
                this.GetComponent<Renderer>().material = material[0];

                //キューブの色を青から赤に
                g_cube.layer = 14;
                g_cube.GetComponent<Renderer>().material = material[0];

                //count = 0;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (switch_type == 0)
        {
            if (other.gameObject.CompareTag("player"))
            {
                //スイッチの色を変換：赤から青
                switch_type = 1;
                this.GetComponent<Renderer>().material = material[1];

                //指定キューブの色を変換：赤から青
                g_cube.layer = 13;
                g_cube.GetComponent<Renderer>().material = material[1];

                //救済キューブの出現
                switch0.GetComponent<Renderer>().material = material[1];
                switch0.switch_type = 1;
            }
        }
        else if(switch_type==1)
        {
            if (other.gameObject.CompareTag("sand_normal"))
            {
                count++;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(switch_type==1||switch_type==3)
        {
            if (other.gameObject.CompareTag("sand_normal"))
            {
                count--;

                if(count<0)
                {
                    count = 0;
                }

                if (switch_type == 3 && count <= 0)
                {
                    count = 0;
                    switch_type = 0;
                }
            }
        }
        else
        {
            count = 0;
        }
      
    }
}
