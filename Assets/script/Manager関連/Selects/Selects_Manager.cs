using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selects_Manager : MonoBehaviour
{
    private GameObject manager;
    private Audio_Manager am;
    private Scene_Manager sm;

    [SerializeField] private AudioClip titleBGM;        //title
    [SerializeField] private AudioClip audioClip1;      //決定
    [SerializeField] private AudioClip audioClip2;      //キャンセル
    [SerializeField] private AudioClip audioClip3;      //選択

    private bool fadeFlag;

    private float lsv;      //Lスティック縦に動かしたときの値を格納する
    private float lsh;      //Lスティック横に動かしたときの値を格納する
    private bool stickFlag;
    private bool startFlag;

    private GameObject selectObject;
    private Material selectMaterial;
    private Color color;
    private float flashFlag;
    private int selectCount;
    private int oldSelect;

    private GameObject endanimation;
    private CoinUp cu;

    private enum StageSelect
    {
        none,
        stage_1,
        stage_2,
        stage_3,
        stage_4,
        stage_5,
        stage_6,
        stage_7,
        stage_8,
        stage_9,
        stage_10,
        stage_11,
        stage_12,
        stage_13,
        stage_14,
        stage_15,
        stage_16,
        stage_17,
        stage_18,
        stage_19,
        stage_20,
        MAX
    }

    private StageSelect CursorPos;
    public static bool changeselect = true;

    void Awake()
    {
        manager = GameObject.Find("GameManager");
        am = manager.GetComponent<Audio_Manager>();
        sm = manager.GetComponent<Scene_Manager>();

        fadeFlag = false;
        startFlag = false;

        selectObject = GameObject.Find("SelectCursor");
        selectMaterial = selectObject.GetComponent<Renderer>().sharedMaterial;
        color = selectMaterial.color;
        flashFlag = 0.0f;
        selectCount = 0;
        oldSelect = sm.selectSelect;

        endanimation = GameObject.Find("Coin");
        cu = endanimation.GetComponent<CoinUp>();
    }

    void Start()
    {
        //ステージ帰りだったら場面に応じた曲を流す
        if (am.source[0].clip != titleBGM)
            am.PlayBGM(titleBGM);
    }

    void Update()
    {
        if (!sm.fadeIn && !fadeFlag)
        {
            //コントローラ左スティックの更新
            lsv = Input.GetAxis("L_Stick_V");
            lsh = Input.GetAxis("L_Stick_H");

            //ステージが一気に動かないようにする
            if (lsv <= 0.1 && lsv >= -0.1 && lsh <= 0.1 && lsh >= -0.1)
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

            if (cu.EndCoinUp() == true){
                if (!startFlag)
                {
                    selectObject.transform.position = CursorPositionLR(sm.selectSelect);
                    startFlag = true;
                }
                if (Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.Z))  //決定
                {
                    am.PlaySE(audioClip1);
                    sm.SceneChange((Scene_Manager.Stage)sm.selectSelect + 3);
                    fadeFlag = true;
                    changeselect = false;
                }
                else if (Input.GetKeyDown(KeyCode.Joystick1Button1) || Input.GetKeyDown(KeyCode.X)) //キャンセル
                {
                    am.PlaySE(audioClip2);
                    sm.SceneChange(Scene_Manager.Stage.TITLE);
                    sm.titleSelect = 1;
                    fadeFlag = true;
                    changeselect = true;
                }

                if (stickFlag == true)
                {
                    if (Input.GetKeyDown(KeyCode.RightArrow) || lsh >= 0.9)
                    {
                        if (sm.selectSelect != 5 && sm.selectSelect != 10 && sm.selectSelect != 15 && sm.selectSelect != 20)
                        {
                            oldSelect = sm.selectSelect;
                            sm.selectSelect++;
                            //selectObject.transform.position = CursorPositionLR(sm.selectSelect);
                            selectCount += 30;

                            am.PlaySE(audioClip3);

                            stickFlag = false;
                        }
                    }
                    else if (Input.GetKeyDown(KeyCode.LeftArrow) || lsh <= -0.9)
                    {
                        if (sm.selectSelect != 1 && sm.selectSelect != 6 && sm.selectSelect != 11 && sm.selectSelect != 16)
                        {
                            oldSelect = sm.selectSelect;
                            sm.selectSelect--;
                            //selectObject.transform.position = CursorPositionLR(sm.selectSelect);
                            selectCount += 30;

                            am.PlaySE(audioClip3);

                            stickFlag = false;
                        }
                    }

                    else if (Input.GetKeyDown(KeyCode.UpArrow) || lsv >= 0.9)
                    {
                        if (sm.selectSelect >= 6)
                        {
                            oldSelect = sm.selectSelect;
                            sm.selectSelect -= 5;
                            //selectObject.transform.position = CursorPositionLR(sm.selectSelect);
                            selectCount += 30;

                            am.PlaySE(audioClip3);

                            stickFlag = false;
                        }
                    }
                    else if (Input.GetKeyDown(KeyCode.DownArrow) || lsv <= -0.9)
                    {
                        if (sm.selectSelect <= 15)
                        {
                            oldSelect = sm.selectSelect;
                            sm.selectSelect += 5;
                            //selectObject.transform.position = CursorPositionLR(sm.selectSelect);
                            selectCount += 30;

                            am.PlaySE(audioClip3);

                            stickFlag = false;
                        }
                    }
                }
            }

            CursorMove(CursorPositionLR(sm.selectSelect),CursorPositionLR(oldSelect));
        }
    }

    public static bool GetOldScene()
    {
        return changeselect;
    }

    private Vector3 CursorPositionLR(int pos)
    {
        Vector3 select = new Vector3(0,0,0);

        switch (pos)
        {
            case 1:
                select = new Vector3(-2.323f, 1.14f, 1.29f);
                break;

            case 2:
                select = new Vector3(-1.18f, 1.14f, 1.29f);
                break;

            case 3:
                select =new Vector3(0.812f, 1.14f, 1.318f);
                break;

            case 4:
                select =new Vector3(1.798f, 1.14f, 1.318f);
                break;

            case 5:
                select =new Vector3(2.8f, 1.14f, 1.318f);
                break;

            case 6:
                select = new Vector3(-2.7f, 1.14f, 0.25f); 
                break;

            case 7:
                select =  new Vector3(-1.73f, 1.14f, 0.25f); 
                break;

            case 8:
                select = new Vector3(-0.65f, 1.14f, 0.25f); 
                break;

            case 9:
                select =new Vector3(1.272f, 1.14f, 0.278f);
                break;

            case 10:
                select = new Vector3(2.422f, 1.14f, 0.278f);
                break;


            case 11:
                select =new Vector3(-2.31f, 1.14f, -0.86f); 
                break;

            case 12:
                select =  new Vector3(-1.16f, 1.14f, -0.86f);
                break;

            case 13:
                select =new Vector3(0.762f, 1.14f, -0.831f);
                break;

            case 14:
                select =new Vector3(1.842f, 1.14f, -0.831f);
                break;

            case 15:
                select =new Vector3(2.812f, 1.14f, -0.831f);
                break;

            case 16:
                select = new Vector3(-2.688f, 1.14f, -1.9f); 
                break;

            case 17:
                select = new Vector3(-1.686f, 1.14f, -1.9f);
                break;

            case 18:
                select = new Vector3(-0.7f, 1.14f, -1.9f);
                break;

            case 19:
                select = new Vector3(1.292f, 1.14f, -1.871f);
                break;

            case 20:
                select = new Vector3(2.37f, 1.14f, -1.871f);
                break;

            default:
                Debug.Log("エラッたww");
                break;
        }

        return select;
    }

    private void CursorMove(Vector3 next,Vector3 now)
    {
         Vector3 calc;

         calc = new Vector3(next.x - now.x, 0, next.z - now.z);

         if (selectCount > 0)
         {
            selectObject.transform.position += new Vector3(calc.x / 30, 0, calc.z / 30);
            selectCount--;
            Debug.Log(calc.x);
         }
    }
}
