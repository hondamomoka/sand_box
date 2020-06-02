using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title_Manager : MonoBehaviour
{
    private GameObject selectObject;

    private float lsv;      //Lスティック縦に動かしたときの値を格納する
    private bool stickFlag;

    private bool fadeFlag;

    private GameObject manager;
    private Audio_Manager am;
    private Scene_Manager sm;

    [SerializeField] private AudioClip titleBGM;
    [SerializeField] private AudioClip audioClip1;
    [SerializeField] private AudioClip audioClip2;

    public static bool newgame;
    public static bool changetitle;


    void Awake()
    {
        selectObject = GameObject.Find("select");

        manager = GameObject.Find("GameManager");
        am = manager.GetComponent<Audio_Manager>();
        sm = manager.GetComponent<Scene_Manager>();

        fadeFlag = false;
        changetitle = false;
    }

    void Start()
    {
        selectObject.transform.position = new Vector3(1, (-49.0f - 30.0f * sm.titleSelect), 300);

        if (am.source[0].clip != titleBGM)
            am.PlayBGM(titleBGM);
    }

    void Update()
    {
        if (!sm.fadeIn && !fadeFlag)
        {
            lsv = Input.GetAxis("L_Stick_V");
            if (lsv <= 0.1 && lsv >= -0.1)
                stickFlag = true;

            //決定Aボタン
            if (Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.Z))
            {
                am.PlaySE(audioClip1);
                switch (sm.titleSelect)
                {
                    case 0:
                        sm.SceneChange(Scene_Manager.Stage.SELECTS);
                        sm.selectSelect = 1;
                        newgame = false;
                        break;
                    case 1:
                        sm.SceneChange(Scene_Manager.Stage.SELECTS);
                        newgame = true;
                        break;
                    case 2:
                        sm.SceneChange(Scene_Manager.Stage.OPTION);
                        break;
                    case 3:
                        sm.SceneChange(Scene_Manager.Stage.MANUAL);
                        break;
                    case 4:
                        Quit();
                        break;
                }
                fadeFlag = true;
            }

            if (stickFlag == true)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow) || lsv >= 0.9)
                {
                    if (selectObject.transform.position.y != -49.0f)
                    {
                        selectObject.transform.position += new Vector3(0, 30.0f, 0);
                        sm.titleSelect -= 1;
                        am.PlaySE(audioClip2);
                        stickFlag = false;
                    }
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow) || lsv <= -0.9)
                {
                    if (selectObject.transform.position.y != -169.0f)
                    {
                        selectObject.transform.position += new Vector3(0, -30.0f, 0);
                        sm.titleSelect += 1;
                        am.PlaySE(audioClip2);
                        stickFlag = false;
                    }
                }
            }
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
