using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option_Manager : MonoBehaviour
{
    private GameObject manager;
    private Audio_Manager am;
    private Scene_Manager sm;

    private GameObject bgmObousan;
    private GameObject bgmButton;
    private GameObject seObousan;
    private GameObject seButton;
    private GameObject sentaku;

    [SerializeField] private AudioClip audioClip1;
    [SerializeField] private AudioClip audioClip2;
    [SerializeField] private AudioClip audioClip3;

    private float lsv;      //Lスティック縦に動かしたときの値を格納する
    private float lsh;      //Lスティック横に動かしたときの値を格納する
    private bool stickFlag;

    private bool fadeFlag;

    private bool erabu;

    void Awake()
    {
        manager = GameObject.Find("GameManager");
        am = manager.GetComponent<Audio_Manager>();
        sm = manager.GetComponent<Scene_Manager>();

        bgmObousan = GameObject.Find("barbgm");
        bgmButton  = GameObject.Find("buttonbgm");
        seObousan  = GameObject.Find("barse");
        seButton   = GameObject.Find("buttonse");
        sentaku    = GameObject.Find("sentaku");

        fadeFlag = false;
        erabu = false;
    }

    void Start()
    {
        sentaku.transform.position = new Vector3(2.1f,2.2f,-0.99f);

        bgmObousan.transform.localScale = new Vector3(((am.bgVol / 0.08f) * 0.07f),1,1);
        seObousan.transform.localScale  = new Vector3(((am.seVol / 0.08f) * 0.07f), 1,1);

        bgmObousan.transform.position = new Vector3(-0.55f + ((am.bgVol / 0.08f) * 0.285f), 2.3f,0);
        seObousan.transform.position  = new Vector3(-0.55f + ((am.seVol / 0.08f) * 0.285f), -0.6f,0);

        bgmButton.transform.position = new Vector3(-0.44f + ((am.bgVol / 0.08f) * 0.51f), 2.18f,-1.0f);
        seButton.transform.position  = new Vector3(-0.44f + ((am.seVol / 0.08f) * 0.51f),-0.44f,-1.0f);
    }

    void Update()
    {
        if (!sm.fadeIn && !fadeFlag)
        {
            //コントローラ左スティックの更新
            lsv = Input.GetAxis("L_Stick_V");
            lsh = Input.GetAxis("L_Stick_H");

            //項目が一気に動かないようにする
            if (lsv <= 0.1 && lsv >= -0.1 && lsh <= 0.1 && lsh >= -0.1)
                stickFlag = true;

            //戻るボタン
            if (Input.GetKeyDown(KeyCode.Joystick1Button1) || Input.GetKeyDown(KeyCode.X))
            {
                am.PlaySE(audioClip1);
                sm.SceneChange(Scene_Manager.Stage.TITLE);
                fadeFlag = true;
            }

            if (stickFlag == true)
            {
                //項目選択
                if (Input.GetKeyDown(KeyCode.UpArrow) || lsv >= 0.9)
                {
                    if (erabu == true)
                    {
                        sentaku.transform.position = new Vector3(2.1f, 2.2f, -0.99f);
                        erabu = false;
                        am.PlaySE(audioClip3);
                    }

                    stickFlag = false;
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow) || lsv <= -0.9)
                {
                    if (erabu == false)
                    {
                        sentaku.transform.position = new Vector3(2.1f, -0.44f, -0.99f);
                        erabu = true;
                        am.PlaySE(audioClip3);
                    }

                    stickFlag = false;
                }

                //音量変更
                if (Input.GetKeyDown(KeyCode.RightArrow) || lsh >= 0.9)
                {
                    if (erabu == false && am.bgVol < 0.79f)
                    {
                        am.bgVol += 0.08f;
                        am.source[0].volume = am.bgVol;
                        bgmButton.transform.position += new Vector3(0.51f, 0, 0);
                        bgmObousan.transform.localScale += new Vector3(0.07f, 0, 0);
                        bgmObousan.transform.position += new Vector3(0.285f, 0, 0);
                    }
                    else if (erabu == true && am.seVol < 0.79f)
                    {
                        am.seVol += 0.08f;
                        seButton.transform.position += new Vector3(0.51f, 0, 0);
                        seObousan.transform.localScale += new Vector3(0.07f, 0, 0);
                        seObousan.transform.position += new Vector3(0.285f, 0, 0);
                        am.PlaySE(audioClip2);
                    }

                    stickFlag = false;
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow) || lsh <= -0.9)
                {
                    if (erabu == false && am.bgVol > 0.01f)
                    {
                        am.bgVol -= 0.08f;
                        am.source[0].volume = am.bgVol;
                        bgmButton.transform.position -= new Vector3(0.51f, 0, 0);
                        bgmObousan.transform.localScale -= new Vector3(0.07f, 0, 0);
                        bgmObousan.transform.position -= new Vector3(0.285f, 0, 0);
                    }
                    else if (erabu == true && am.seVol > 0.01f)
                    {
                        am.seVol -= 0.08f;
                        seButton.transform.position -= new Vector3(0.51f, 0, 0);
                        seObousan.transform.localScale -= new Vector3(0.07f, 0, 0);
                        seObousan.transform.position -= new Vector3(0.285f, 0, 0);
                        am.PlaySE(audioClip2);
                    }

                    stickFlag = false;
                }
            }
        }
    }
}
