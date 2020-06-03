using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NeedleRot : MonoBehaviour
{
    public GameObject[] SandCreater;
    public GameObject Needle_Join;
    public GameObject Needle;
    public float Needle_Rot;
    public float Needle_Rot_Low;
    public float Needle_Rot_High;
    public int safe_num;
    public float safe_rate;

    CreateSandsKyo[] Sands_Script;
    RawImage Needle_Image;

    public int sands_max;
    public int sands_num;

    // Start is called before the first frame update
    void Start()
    {
        sands_max = 0;
        sands_num = 0;

        Sands_Script = new CreateSandsKyo[SandCreater.Length];

        for (int i = 0; i < SandCreater.Length; i++)
        {
            Sands_Script[i] = SandCreater[i].GetComponent<CreateSandsKyo>();
            sands_max += Sands_Script[i].Sands_Max;
        }

        sands_num = sands_max;

        Needle_Image = Needle.GetComponent<RawImage>();
        //GetComponent<RectTransform>().localEulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        sands_num = 0;
        for (int i = 0; i < SandCreater.Length; i++)
        {
            sands_num += Sands_Script[i].Sands_Num;
        }

        Needle_Rot = Get_EulerAngles(sands_num);

        Needle_Rotation(Needle_Rot_Low, Needle_Rot_High);

        safe_rate = (float)(sands_num - safe_num) / (sands_max - safe_num);

        Change_Color(safe_rate);
    }

    float Get_EulerAngles(int sn)
    {
        float rot;

        rot = 330 - sn * 330.0f / sands_max;

        return rot;
    }

    void Needle_Rotation(float rs_low, float rs_high)
    {
        float r_idx = Needle_Rot - Needle_Join.transform.localEulerAngles.z;

        if (r_idx > 0)
        {
            Vector3 r = Needle_Join.transform.localEulerAngles;

            if( r_idx > rs_high)
            {
                r.z += rs_high;
            }
            else
            {
                r.z += rs_low;
            }

            if (r.z > Needle_Rot)
            {
                r.z = Needle_Rot;
            }
            Needle_Join.transform.localEulerAngles = r;
        }
    }

    void Change_Color(float n)
    {
        if (n >= 0.875f)
        {
            Needle_Image.color = new Color(0, 250, 0, 255) / 255.5f;
        }
        else if (n >= 0.75f)
        {
            Needle_Image.color = new Color(50, 250, 0, 255) / 255.5f;
        }
        else if (n >= 0.625f)
        {
            Needle_Image.color = new Color(100, 250, 0, 255) / 255.5f;
        }
        else if (n >= 0.5f)
        {
            Needle_Image.color = new Color(150, 250, 0, 255) / 255.5f;
        }
        else if (n >= 0.375f)
        {
            Needle_Image.color = new Color(200, 250, 0, 255) / 255.5f;
        }
        else if (n >= 0.25f)
        {
            Needle_Image.color = new Color(250, 250, 0, 255) / 255.5f;
        }
        else if (n >= 0.125f)
        {
            Needle_Image.color = new Color(250, 200, 0, 255) / 255.5f;
        }
        else if (n >= 0.0f)
        {
            Needle_Image.color = new Color(250, 150, 0, 255) / 255.5f;
        }
        else
        {
            Needle_Image.color = new Color(250, 0, 0, 255) / 255.5f;
        }
    }
}
