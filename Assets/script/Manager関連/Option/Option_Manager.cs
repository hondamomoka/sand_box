using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Option_Manager : MonoBehaviour
{
    private GameObject bgmObousan;
    private GameObject bgmButton;
    private GameObject seObousan;
    private GameObject seButton;
    private GameObject sentaku;

    [SerializeField] private AudioClip audioClip1;
    [SerializeField] private AudioClip audioClip2;
    [SerializeField] private AudioClip audioClip3;

    private const float bgMaxVol = 0.8f;
    private const float seMaxVol = 0.8f;

    private float lsv;      //Lスティック縦に動かしたときの値を格納する
    private float lsh;      //Lスティック横に動かしたときの値を格納する
    private bool stickFlag;

    private bool fadeFlag;

    private bool erabu;

    void Awake()
    {
        bgmObousan = GameObject.Find("bgfix");
        bgmButton  = GameObject.Find("buttonbgm");
        seObousan  = GameObject.Find("sefix");
        seButton   = GameObject.Find("buttonse");
        sentaku    = GameObject.Find("sentaku");

        fadeFlag = false;
        erabu = false;
    }

    void Start()
    {
        bgmObousan.transform.localScale = new Vector3((Game_Manager.Instance.am.bgVol / 0.8f),1,1);
        seObousan.transform.localScale  = new Vector3((Game_Manager.Instance.am.seVol / 0.8f),1,1);

        bgmButton.transform.position = new Vector3(-0.44f + ((Game_Manager.Instance.am.bgVol / 0.08f) * 0.51f), 2.18f,-1.0f);
        seButton.transform.position  = new Vector3(-0.44f + ((Game_Manager.Instance.am.seVol / 0.08f) * 0.51f),-0.44f,-1.0f);

        sentaku.transform.position = bgmButton.transform.position + new Vector3(0, 0.02f, 0.01f);
    }

    void Update()
    {
        if (!Game_Manager.Instance.sm.fadeIn && !fadeFlag)
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
                Game_Manager.Instance.am.PlaySE(audioClip1);
                Game_Manager.Instance.sm.SceneChange(Scene_Manager.Stage.TITLE);
                fadeFlag = true;
            }

            if (stickFlag == true)
            {
                //項目選択
                if (Input.GetKeyDown(KeyCode.UpArrow) || lsv >= 0.9)
                {
                    if (erabu == true)
                    {
                        sentaku.transform.position = bgmButton.transform.position + new Vector3(0, 0.02f, 0.01f);
                        erabu = false;
                        Game_Manager.Instance.am.PlaySE(audioClip3);
                    }

                    stickFlag = false;
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow) || lsv <= -0.9)
                {
                    if (erabu == false)
                    {
                        sentaku.transform.position = seButton.transform.position + new Vector3(0, 0.02f, 0.01f);
                        erabu = true;
                        Game_Manager.Instance.am.PlaySE(audioClip3);
                    }

                    stickFlag = false;
                }

                //音量変更
                if (Input.GetKeyDown(KeyCode.RightArrow) || lsh >= 0.9)
                {
                    if (erabu == false && Game_Manager.Instance.am.bgVol < 0.79f)
                    {
                        Game_Manager.Instance.am.bgVol += 0.08f;
                        Game_Manager.Instance.am.source[0].volume = Game_Manager.Instance.am.bgVol;

                        bgmButton.transform.position += new Vector3(0.51f, 0, 0);
                        sentaku.transform.position = bgmButton.transform.position + new Vector3(0, 0.02f, 0.01f);

                        bgmObousan.transform.localScale += new Vector3(0.1f, 0, 0);
                    }
                    else if (erabu == true && Game_Manager.Instance.am.seVol < 0.79f)
                    {
                        Game_Manager.Instance.am.seVol += 0.08f;
                        Game_Manager.Instance.am.PlaySE(audioClip2);

                        seButton.transform.position += new Vector3(0.51f, 0, 0);
                        sentaku.transform.position = seButton.transform.position + new Vector3(0, 0.02f, 0.01f);

                        seObousan.transform.localScale += new Vector3(0.1f, 0, 0);
                    }

                    stickFlag = false;
                }
                else if (Input.GetKeyDown(KeyCode.LeftArrow) || lsh <= -0.9)
                {
                    if (erabu == false && Game_Manager.Instance.am.bgVol > 0.01f)
                    {
                        Game_Manager.Instance.am.bgVol -= 0.08f;
                        Game_Manager.Instance.am.source[0].volume = Game_Manager.Instance.am.bgVol;

                        bgmButton.transform.position -= new Vector3(0.51f, 0, 0);
                        sentaku.transform.position = bgmButton.transform.position + new Vector3(0, 0.02f, 0.01f);

                        bgmObousan.transform.localScale -= new Vector3(0.1f, 0, 0);
                    }
                    else if (erabu == true && Game_Manager.Instance.am.seVol > 0.01f)
                    {
                        Game_Manager.Instance.am.seVol -= 0.08f;
                        Game_Manager.Instance.am.PlaySE(audioClip2);

                        seButton.transform.position -= new Vector3(0.51f, 0, 0);
                        sentaku.transform.position = seButton.transform.position + new Vector3(0, 0.02f, 0.01f);

                        seObousan.transform.localScale -= new Vector3(0.1f, 0, 0);
                    }

                    stickFlag = false;
                }
            }
        }
    }
}
