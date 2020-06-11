using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NeedleRot : MonoBehaviour
{
    public GameObject[] SandCreater;
    public GameObject Pocket_Watch_Pad;
    public GameObject Needle_Join;
    public GameObject Needle;
    public float Needle_Rot;
    public float Needle_Rot_Low;
    public float Needle_Rot_High;
    public int safe_num;
    public float safe_rate;
    public bool isGameClear;

    CreateSandsKyo[] Sands_Script;
    RawImage Watch_Image;
    RawImage Needle_Image;

    public int sands_max;
    public int sands_num;

    public float origin_alpha;
    public float pause_alpha;

    bool isEnd;

    float[] Needle_State;

    // Start is called before the first frame update
    void Start()
    {
        isGameClear = false;

        sands_max = 0;
        sands_num = 0;

        Sands_Script = new CreateSandsKyo[SandCreater.Length];

        for (int i = 0; i < SandCreater.Length; i++)
        {
            Sands_Script[i] = SandCreater[i].GetComponent<CreateSandsKyo>();
            sands_max += Sands_Script[i].Sands_Max;
        }

        sands_num = sands_max;

        Watch_Image = Pocket_Watch_Pad.GetComponent<RawImage>();
        Needle_Image = Needle.GetComponent<RawImage>();

        origin_alpha = origin_alpha / 255.0f;
        pause_alpha = pause_alpha / 255.0f;
        //GetComponent<RectTransform>().localEulerAngles;

        isEnd = false;

        Needle_State = new float[11];

        for (int i = 0; i < 11; i++)
        {
            Needle_State[i] = i * 30 / 330.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameClear == false)
        {
            sands_num = 0;
            for (int i = 0; i < SandCreater.Length; i++)
            {
                sands_num += Sands_Script[i].Sands_Num;
            }

            //Needle_Rot = Get_EulerAngles(sands_num);
            Needle_Rot = Get_EulerAngles(sands_num - safe_num);

            Needle_Rotation(Needle_Rot_Low, Needle_Rot_High);

            safe_rate = (float)(sands_num - safe_num) / (sands_max - safe_num);

            Change_Color(safe_rate);

            if (Game_Manager.Instance.sm.menuFlag == true)
            {
                Watch_Image.color = new Color(Watch_Image.color.r, Watch_Image.color.g, Watch_Image.color.b, pause_alpha);
                Needle_Image.color = new Color(Needle_Image.color.r, Needle_Image.color.g, Needle_Image.color.b, pause_alpha);
            }
            else
            {
                Watch_Image.color = new Color(Watch_Image.color.r, Watch_Image.color.g, Watch_Image.color.b, origin_alpha);
                Needle_Image.color = new Color(Needle_Image.color.r, Needle_Image.color.g, Needle_Image.color.b, origin_alpha);
            }
        }
    }

    float Get_EulerAngles(int sn)
    {
        float rot;

        rot = 330 - sn * 330.0f / (sands_max - safe_num);
        //rot = 330 - sn * 330.0f / (sands_max - safe_num);

        return rot;
    }

    void Needle_Rotation(float rs_low, float rs_high)
    {
        if(isEnd == false)
        {
            // 回転量
            float r_idx = Needle_Rot - Needle_Join.transform.localEulerAngles.z;

            if (r_idx > 0)
            {
                Vector3 r = Needle_Join.transform.localEulerAngles;

                // 回転速度
                if (r_idx > rs_high)
                {
                    r.z += rs_high;
                }
                else
                {
                    r.z += rs_low;
                }

                // 過ぎた回転量の修正
                if (r.z > Needle_Rot)
                {
                    r.z = Needle_Rot;
                }

                if (r.z >= 330.0f)
                {
                    r.z = 330.0f;
                    isEnd = true;
                }

                Needle_Join.transform.localEulerAngles = r;
            }
        } 
    }

    void Change_Color(float n)
    {
        if (n >= Needle_State[10])
        {
            Needle_Image.color = new Color(0, 250, 0, 200) / 255.5f;
        }
        else if (n >= Needle_State[9])
        {
            Needle_Image.color = new Color(50, 250, 0, 200) / 255.5f;
        }
        else if (n >= Needle_State[8])
        {
            Needle_Image.color = new Color(100, 250, 0, 200) / 255.5f;
        }
        else if (n >= Needle_State[7])
        {
            Needle_Image.color = new Color(150, 250, 0, 200) / 255.5f;
        }
        else if (n >= Needle_State[6])
        {
            Needle_Image.color = new Color(200, 250, 0, 200) / 255.5f;
        }
        else if (n >= Needle_State[5])
        {
            Needle_Image.color = new Color(250, 250, 0, 200) / 255.5f;
        }
        else if (n >= Needle_State[4])
        {
            Needle_Image.color = new Color(250, 200, 0, 200) / 255.5f;
        }
        else if (n >= Needle_State[3])
        {
            Needle_Image.color = new Color(250, 180, 0, 200) / 255.5f;
        }
        else if (n >= Needle_State[2])
        {
            Needle_Image.color = new Color(250, 160, 0, 255) / 255.5f;
        }
        else if (n >= Needle_State[1])
        {
            Needle_Image.color = new Color(250, 140, 0, 255) / 255.5f;
        }
        else if (n >= Needle_State[0])
        {
            Needle_Image.color = new Color(250, 120, 0, 255) / 255.5f;
        }
        else
        {
            Needle_Image.color = new Color(255, 10, 0, 255) / 255.5f;
        }
    }

    public void Set_Stop()
    {
        isGameClear = true;
    }
}
