using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;     //UIを使用可能にする

public class Menu_Manager : MonoBehaviour
{
    [SerializeField] private GameObject select;         //メニューを選択するアイコン
    private bool selectFlag;                            //falseなら上trueなら下
    private int selectCount;

    private GameObject rotateManager;
    private rotation rotateScript;

    private GameObject gameManager;
    private Audio_Manager am;
    private Scene_Manager sm;

    [SerializeField] private AudioClip audioClip;

    private float lsv;                                  //Lスティック縦に動かしたときの値を格納する
    private bool stickFlag;

    [SerializeField]
    private Image panel;
    private Color color;                                //RGBを操作するための変数


    void Awake()
    {
        gameManager = GameObject.Find("GameManager");
        am = gameManager.GetComponent<Audio_Manager>();
        sm = gameManager.GetComponent<Scene_Manager>();
    }

    void Start()
    {
        selectFlag = false;

        //ステージの値を無理やり取得(変更予定)
        rotateManager = GameObject.Find("stage");
        if(rotateManager == null)
            rotateManager = GameObject.Find("Stage");

        rotateScript = rotateManager.GetComponent<rotation>();
        rotateScript.rotateFlag = false;

        selectCount = 0;

        Fade_Manager.Instance.MenuIn();
    }

    void Update()
    {
        //スティックの値取得
        lsv = Input.GetAxis("L_Stick_V");
        if (lsv <= 0.1 && lsv >= -0.1)
            stickFlag = true;

        //YorB押したときに反映、ゲームに戻る
        if (Input.GetKeyDown(KeyCode.Joystick1Button1) || Input.GetKeyDown(KeyCode.Joystick1Button3) || Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.X))
        {
            rotateScript.rotateFlag = true;
            Fade_Manager.Instance.MenuOut();
            Destroy(this.gameObject);
        }

        //決定Aボタン(内容を反映)
        if (Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.Z))
        {
            switch (selectFlag)
            {
                case false:
                    //リスタート
                    sm.SceneChange(sm.nowScene);
                    break;
                case true:
                    //ステージセレクトに戻る
                    sm.SceneChange(Scene_Manager.Stage.SELECTS);
                    break;
            }
            Destroy(this.gameObject);
        }
        //上下選択
        if (stickFlag == true)
        {
            //上選択
            if (Input.GetKeyDown(KeyCode.UpArrow) || lsv >= 0.9)
            {
                if (selectFlag)
                {
                    selectCount += 21;
                    selectFlag = false;
                }
            }
            //下選択
            else if (Input.GetKeyDown(KeyCode.DownArrow) || lsv <= -0.9)
            {
                if (!selectFlag)
                {
                    selectCount += -21;
                    selectFlag = true;
                }
            }
        }
        //ぬるっとうごくよ
        if (selectCount > 0)
        {
            select.transform.position += new Vector3(0, 0.1f, 0);
            selectCount--;
        }
        if (selectCount < 0)
        {
            select.transform.position -= new Vector3(0, 0.1f, 0);
            selectCount++;
        }

    }
}
