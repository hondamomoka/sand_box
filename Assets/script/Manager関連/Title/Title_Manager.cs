using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title_Manager : MonoBehaviour
{
    private GameObject selectObject;
    private Material selectMaterial;
    private int selectCount;
    private const int selectCountMax = 30;
    private Color color;
    private float flashFlag;

    private float lsv;      //Lスティック縦に動かしたときの値を格納する
    private bool stickFlag;

    private bool fadeFlag;

    [SerializeField] private AudioClip titleBGM;
    [SerializeField] private AudioClip audioClip1;
    [SerializeField] private AudioClip audioClip2;

    public static bool newgame;
    public static bool changetitle;


    void Awake()
    {
        selectObject = GameObject.Find("select");
        selectMaterial = selectObject.GetComponent<Renderer>().sharedMaterial;

        selectCount = 0;
        color = selectMaterial.color;
        flashFlag = 0.0f;

        fadeFlag = false;
    }

    void Start()
    {
        changetitle = false;
        selectObject.transform.position = new Vector3(1, (-49.0f - 30.0f * Game_Manager.Instance.sm.titleSelect), 300);

        if (Game_Manager.Instance.am.source[0].clip != titleBGM)
            Game_Manager.Instance.am.PlayBGM(titleBGM);
    }

    void Update()
    {
        if (!Game_Manager.Instance.sm.fadeIn && !fadeFlag)
        {
            //スティックの値取得
            lsv = Input.GetAxis("L_Stick_V");
            if (lsv <= 0.1 && lsv >= -0.1)
                stickFlag = true;

            //カーソル点滅
            selectMaterial.color = color;
            if (flashFlag == 0.0f)
            {
                color.a += 1.5f * Time.deltaTime;
                if (color.a > 1)
                    flashFlag = 1.5f;
            }
            else if (flashFlag < 2.0f)
            {
                flashFlag += Time.deltaTime;
                if (flashFlag > 2.0f)
                {
                    flashFlag = 2;
                }
            }
            else if (flashFlag == 2)
            {
                color.a -= 1.5f * Time.deltaTime;
                if (color.a < 0)
                    flashFlag = 0;
            }

            //決定Aボタン
            if (Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.Z))
            {
                Game_Manager.Instance.am.PlaySE(audioClip1);
                switch (Game_Manager.Instance.sm.titleSelect)
                {
                    case 0:
                        Game_Manager.Instance.sm.SceneChange(Scene_Manager.Stage.SELECTS);
                        Game_Manager.Instance.sm.selectSelect = 1;
                        newgame = false;
                        break;
                    case 1:
                        Game_Manager.Instance.sm.SceneChange(Scene_Manager.Stage.SELECTS);
                        newgame = true;
                        break;
                    case 2:
                        Game_Manager.Instance.sm.SceneChange(Scene_Manager.Stage.OPTION);
                        break;
                    case 3:
                        Game_Manager.Instance.sm.SceneChange(Scene_Manager.Stage.MANUAL);
                        break;
                    case 4:
                        Quit();
                        break;
                }
                fadeFlag = true;
            }

            //カーソル移動上下
            if (stickFlag == true)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow) || lsv >= 0.9)
                {
                    if (Game_Manager.Instance.sm.titleSelect > 0)
                    {
                        selectCount += 30;
                        Game_Manager.Instance.sm.titleSelect -= 1;

                        Game_Manager.Instance.am.PlaySE(audioClip2);

                        stickFlag = false;

                        color.a = 1.0f;
                        flashFlag = 1.0f;
                    }
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow) || lsv <= -0.9)
                {
                    if (Game_Manager.Instance.sm.titleSelect < 4)
                    {
                        selectCount -= 30;
                        Game_Manager.Instance.sm.titleSelect += 1;

                        Game_Manager.Instance.am.PlaySE(audioClip2);

                        stickFlag = false;

                        color.a = 1.0f;
                        flashFlag = 1.0f;
                    }
                }
            }
        }
    }

    //固定フレーム更新
    void FixedUpdate()
    {
        //カーソルをぬるっと動かす
        if (selectCount < 0)
        {
            selectObject.transform.position += new Vector3(0, -5.0f, 0);
            selectCount += 5;
        }
        if (selectCount > 0)
        {
            selectObject.transform.position += new Vector3(0, 5.0f, 0);
            selectCount -= 5;
        }
    }

    public static bool GetContinue()
    {
        return newgame;
    }

    void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
      UnityEngine.Application.Quit();
#endif
    }
}
