using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyfishZoomCheck : MonoBehaviour
{
    public bool readyA;
    public bool readyB;
    public bool readyC;
    public bool readyD;

    private GameObject doorL;
    private GameObject doorR;

    private bool doorFlag;

    //音を再生するために追加
    private GameObject audioManager;
    private Audio_Manager script;
    [SerializeField] private AudioClip audioClip;

    // Start is called before the first frame update
    void Start()
    {
        readyA = readyB = readyC = readyD = false;
        doorL = GameObject.Find("DoorL");
        doorR = GameObject.Find("DoorR");
        doorL.SendMessage("SetSpeed", 0.05f);
        doorR.SendMessage("SetSpeed", 0.05f);
        doorFlag = false;

        //音を再生するために追加
        audioManager = GameObject.Find("GameManager");
        script = audioManager.GetComponent<Audio_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(readyA && readyB && readyC && readyD)
        {
            doorL.SendMessage("OpenX", -1);
            doorR.SendMessage("OpenX", 1);
            if (doorFlag == false)
            {
                doorFlag = true;
                script.PlaySE(audioClip);
            }
        }
        else
        {
            doorL.SendMessage("CloseX", 1);
            doorR.SendMessage("CloseX", -1);
            if (doorFlag == true)
            {
                doorFlag = false;
                script.PlaySE(audioClip);
            }
        }
    }

    void Set_ZoomA_State(bool ready)
    {
        readyA = ready;
    }

    void Set_ZoomB_State(bool ready)
    {
        readyB = ready;
    }
    void Set_ZoomC_State(bool ready)
    {
        readyC = ready;
    }
    void Set_ZoomD_State(bool ready)
    {
        readyD = ready;
    }
}
