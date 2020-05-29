using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeedleRot : MonoBehaviour
{
    public GameObject SandCreater;
    public float Needle_Rot;

    CreateSandsKyo Sands_Script;

    int sands_max;
    int sands_num;

    // Start is called before the first frame update
    void Start()
    {
        Sands_Script = SandCreater.GetComponent<CreateSandsKyo>();
        sands_max = Sands_Script.Sands_Max;
        sands_num = Sands_Script.Sands_Num;

        //GetComponent<RectTransform>().localEulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        sands_num = Sands_Script.Sands_Num;

        Needle_Rot = Get_EulerAngles(sands_num);

        transform.localEulerAngles = new Vector3(0, 0, Needle_Rot);
    }

    float Get_EulerAngles(int sn)
    {
        float rot;

        rot = 330 - sn * 330.0f / sands_max;

        return rot;
    }
}
