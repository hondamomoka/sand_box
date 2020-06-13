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
    private rotation_panguin rotateScript2;


    [SerializeField] private AudioClip audioClip1;      //決定
    [SerializeField] private AudioClip audioClip2;      //キャンセル
    [SerializeField] private AudioClip audioClip3;      //選択

    private float lsv;                                  //Lスティック縦に動かしたときの値を格納する
    private bool stickFlag;

    [SerializeField] private Image panel;
    private Color color;                                //RGBを操作するための変数

    bool hint;
    public Image t_hint;
    Color c_hint;

    void Start()
    {
        selectFlag = false;
        hint = false;

        //ステージの値を無理やり取得(変更予定)
        rotateManager = GameObject.Find("stage");
        if(rotateManager == null)
            rotateManager = GameObject.Find("Stage");

        if (Game_Manager.Instance.sm.nowScene != Scene_Manager.Stage.STAGE_PENGUIN)
        {
            rotateScript = rotateManager.GetComponent<rotation>();
            rotateScript.rotateFlag = false;
        }
        else
        {
            rotateScript2 = rotateManager.GetComponent<rotation_panguin>();
            rotateScript2.rotateFlag = false;
        }
        selectCount = 0;

        Fade_Manager.Instance.MenuIn();
        Game_Manager.Instance.am.PlaySE(audioClip3);

        if(t_hint)
        {
            c_hint = t_hint.color;

            FindObjectOfType<hint>().count_save();
            FindObjectOfType<hint>().Stop();

            if (FindObjectOfType<hint>().hint_flag())
            {
                hint = true;
                c_hint.a = 0.8f;
                t_hint.color = c_hint;
            }
            else
            {
                c_hint.a = 0f;
                t_hint.color = c_hint;
            }
        }
        else
        {
            

            FindObjectOfType<hint>().count_save();
            FindObjectOfType<hint>().Stop();

            if (FindObjectOfType<hint>().hint_flag())
            {
                hint = true;
                // t_hint.color = c_hint;
                FindObjectOfType<hint_tex>().tex_on();
            }
            else
            {
                FindObjectOfType<hint_tex>().tex_off();
            }
        }
    }

    void Update()
    {
            //スティックの値取得
            lsv = Input.GetAxis("L_Stick_V");
        if (lsv <= 0.1 && lsv >= -0.1)
            stickFlag = true;

        //YorB押したときに反映、ゲームに戻る
        if (Input.GetKeyDown(KeyCode.Joystick1Button1) || Input.GetKeyDown(KeyCode.Joystick1Button3) || Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.Joystick1Button7))
        {
            FindObjectOfType<hint>().start();

            if (Game_Manager.Instance.sm.nowScene != Scene_Manager.Stage.STAGE_PENGUIN)
                rotateScript.rotateFlag = true;
            else
                rotateScript2.rotateFlag = true;

            Fade_Manager.Instance.MenuOut();
            Game_Manager.Instance.sm.menuFlag = false;

            Game_Manager.Instance.am.PlaySE(audioClip2);
            Destroy(this.gameObject);
        }

        //決定Aボタン(内容を反映)
        if (Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.Z))
        {
            switch (selectFlag)
            {
                case false:
                    //リスタート
                    Game_Manager.Instance.sm.SceneChange(Game_Manager.Instance.sm.nowScene);
                    Game_Manager.Instance.am.PlaySE(audioClip1);
                    break;
                case true:
                    //ステージセレクトに戻る
                    Game_Manager.Instance.sm.SceneChange(Scene_Manager.Stage.SELECTS);
                    Game_Manager.Instance.am.PlaySE(audioClip1);
                    Game_Manager.Instance.am.source[1].Stop();
                    Game_Manager.Instance.am.source[2].Stop();

                    break;
            }
            Game_Manager.Instance.sm.menuFlag = false;
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
                    Game_Manager.Instance.am.PlaySE(audioClip3);
                }
            }
            //下選択
            else if (Input.GetKeyDown(KeyCode.DownArrow) || lsv <= -0.9)
            {
                if (!selectFlag)
                {
                    selectCount += -21;
                    selectFlag = true;
                    Game_Manager.Instance.am.PlaySE(audioClip3);
                }
            }
        }
    }

    void FixedUpdate()
    {
        //ぬるっとうごくよ
        if (selectCount > 0)
        {
            select.transform.position += new Vector3(0, 0.3f, 0);
            selectCount -= 3;
        }
        if (selectCount < 0)
        {
            select.transform.position -= new Vector3(0, 0.3f, 0);
            selectCount += 3;
        }
    }
}
