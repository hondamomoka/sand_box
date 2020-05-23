using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selects_Manager : MonoBehaviour
{
    private GameObject manager;
    private Audio_Manager am;
    private Scene_Manager sm;

    [SerializeField] private AudioClip audioClip1;      //決定
    [SerializeField] private AudioClip audioClip2;      //キャンセル
    [SerializeField] private AudioClip audioClip3;      //選択

    private bool fadeFlag;

    private float lsv;      //Lスティック縦に動かしたときの値を格納する
    private float lsh;      //Lスティック横に動かしたときの値を格納する
    private bool stickFlag;

    private int selectScene;

    void Awake()
    {
        manager = GameObject.Find("GameManager");
        am = manager.GetComponent<Audio_Manager>();
        sm = manager.GetComponent<Scene_Manager>();

        fadeFlag = false;

        selectScene = 0;
    }

    void Update()
    {
        if (!sm.fadeIn && !fadeFlag)
        {
            lsv = Input.GetAxis("L_Stick_V");
            lsv = Input.GetAxis("L_Stick_H");

            if (lsv <= 0.1 && lsv >= -0.1 && lsh <= 0.1 && lsh >= -0.1)
                stickFlag = true;

            if (Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.Z))
            {
                am.PlaySE(audioClip1);
                sm.SceneChange((Scene_Manager.Stage)selectScene + 5);
                fadeFlag = true;
            }
            else if (Input.GetKeyDown(KeyCode.Joystick1Button1) || Input.GetKeyDown(KeyCode.X))
            {
                am.PlaySE(audioClip2);
                sm.SceneChange(Scene_Manager.Stage.TITLE);
                fadeFlag = true;
            }

            if (stickFlag == true)
            {
                if (Input.GetKeyDown(KeyCode.RightArrow) || lsh >= 0.9)
                {
                    if (selectScene != 19)
                    {
                        selectScene++;
                        am.PlaySE(audioClip3);
                        stickFlag = false;
                    }
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow) || lsh <= -0.9)
                {
                    if (selectScene != 0)
                    {
                        selectScene--;
                        am.PlaySE(audioClip3);
                        stickFlag = false;
                    }
                }
                else if (Input.GetKeyDown(KeyCode.UpArrow) || lsv >= 0.9)
                {
                    if (selectScene <= 2)
                    {
                        am.PlaySE(audioClip3);
                        stickFlag = false;
                    }
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow) || lsv <= -0.9)
                {
                    if (selectScene >= 18)
                    {
                        am.PlaySE(audioClip3);
                        stickFlag = false;
                    }
                }
            }
        }
    }
}
