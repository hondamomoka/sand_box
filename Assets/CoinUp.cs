using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinUp : MonoBehaviour
{
    
    GameObject UpObject;
    public float startpos_x;
    public float startpos_y;
    public float startpos_z;
    public float endpos_y;
    public float upspeed;
    float add_y;

    bool start;
    bool start1;
    bool end;

    // Start is called before the first frame update
    void Start()
    {
        start = false;
        start1 = false;
        end = false;
        add_y = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (start1 == true)
        {
            if (start == false)
            {
                this.transform.position = new Vector3(startpos_x, startpos_y, startpos_z);
                start = true;
            }
            else
            {
                if (startpos_y + add_y <= endpos_y)
                {
                    add_y += upspeed;    // y座標へ0.01加算
                }
                else
                {
                    end = true;
                }

                this.transform.position = new Vector3(startpos_x, startpos_y + add_y, startpos_z);
            }
        }

    }

    public void StartCoinUp()
    {
        start1 = true;
    }

    public bool EndCoinUp()
    {
        return end;
    }
}
