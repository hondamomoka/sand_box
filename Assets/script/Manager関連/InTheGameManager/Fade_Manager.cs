using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;     //UIを使用可能にする
using UnityEngine.SceneManagement;


public class Fade_Manager : MonoBehaviour
{
    //canvasは残しておいて…
    [SerializeField]
    private float speed;         //透明化の速さ
    private Color color;         //RGBを操作するための変数

    //private GameObject gameManager;
    //private Scene_Manager sm;
    //private Audio_Manager am;

    [SerializeField]
    private Image panel;

    public static Fade_Manager Instance
    {
        get; private set;
    }

    void Awake()
    {
        //Panelの色を取得
        color = panel.color;

        //GameManagerを取得してFadeとシーン遷移を関連づける
        //gameManager = GameObject.Find("GameManager");
        //sm = gameManager.GetComponent<Scene_Manager>();
        //am = gameManager.GetComponent<Audio_Manager>();

        //シングルトン的運用
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Update()
    {
        FadeIn();
        FadeOut();
    }

    //フェードの関数
    void FadeOut()
    {
        if (Game_Manager.Instance.sm.nextScene != Scene_Manager.Stage.SCENE_MAX)
        {
            if (Game_Manager.Instance.sm.fadeIn == true)
                Game_Manager.Instance.sm.nextScene = Scene_Manager.Stage.SCENE_MAX;

            panel.color = color;
            color.a += speed * Time.deltaTime;

            //ステージセレクトから各シーンに飛ぶときに音をフェードアウト
            if ((int)Game_Manager.Instance.sm.nextScene > (int)Scene_Manager.Stage.MANUAL)
                Game_Manager.Instance.am.source[0].volume -= speed * Time.deltaTime;
            //各シーンからステージセレクトに飛ぶときに音をフェードアウト
            if((int)Game_Manager.Instance.sm.nowScene  > (int)Scene_Manager.Stage.MANUAL && (int)Game_Manager.Instance.sm.nextScene == (int)Scene_Manager.Stage.SELECTS)
                Game_Manager.Instance.am.source[0].volume -= speed * Time.deltaTime;

            if (color.a >= 1.0f)
            {
                Game_Manager.Instance.sm.fadeIn = true;
                SceneManager.LoadScene((int)Game_Manager.Instance.sm.nextScene);
                Game_Manager.Instance.sm.nowScene = Game_Manager.Instance.sm.nextScene;
                Game_Manager.Instance.sm.nextScene = Scene_Manager.Stage.SCENE_MAX;
                Game_Manager.Instance.sm.menuFlag = true;
                if (Game_Manager.Instance.am.source[0].volume < Game_Manager.Instance.am.bgVol)
                    Game_Manager.Instance.am.source[0].Stop();
            }
        }
    }

    void FadeIn()
    {
        if (Game_Manager.Instance.sm.fadeIn == true)
        {
            panel.color = color;
            color.a -= speed * Time.deltaTime;
            if (color.a <= 0.0f)
            {
                Game_Manager.Instance.sm.fadeIn = false;
                Game_Manager.Instance.sm.menuFlag = false;
            }
        }
    }

    public void MenuIn()
    {
        color.a = 0.5f;
        panel.color = color;
    }

    public void MenuOut()
    {
        color.a = 0.0f;
        panel.color = color;
    }
}

