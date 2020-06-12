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

            Canvas kore = this.GetComponent<Canvas>();
            if (kore.worldCamera != null)
                kore.worldCamera = null;

            //シーン遷移中はメニューが開けない
            Game_Manager.Instance.sm.menuFlag = true;

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
                //シーンの移動
                Game_Manager.Instance.sm.fadeIn = true;
                SceneManager.LoadScene((int)Game_Manager.Instance.sm.nextScene);

                //現在のシーンを更新して次のシーンを初期化しておく
                Game_Manager.Instance.sm.nowScene = Game_Manager.Instance.sm.nextScene;
                Game_Manager.Instance.sm.nextScene = Scene_Manager.Stage.SCENE_MAX;
                
                //bgmを完全に止めておく
                if (Game_Manager.Instance.am.source[0].volume < Game_Manager.Instance.am.bgVol)
                    Game_Manager.Instance.am.source[0].Stop();
            }
        }
    }

    void FadeIn()
    {
        if (Game_Manager.Instance.sm.fadeIn)
        {
            panel.color = color;
            color.a -= speed * Time.deltaTime;
            if (color.a <= 0.0f)
            {
                //現在シーンのカメラを取得
                Camera nowCamera = Camera.main;
                Canvas kore = this.GetComponent<Canvas>();
                kore.worldCamera = nowCamera;

                //フェードイン終了確認
                Game_Manager.Instance.sm.fadeIn = false;

                //メニューを使用可能にする
                Game_Manager.Instance.sm.menuFlag = false;
            }
        }
    }

    public void MenuIn()
    {
        //明かりを消す
        GameObject stagelight = GameObject.Find("Directional Light");
        Light nowLight = stagelight.GetComponent<Light>();
        nowLight.enabled = false;

        color.a = 0.5f;
        panel.color = color;
    }

    public void MenuOut()
    {
        //明かりをつける
        GameObject stagelight = GameObject.Find("Directional Light");
        Light nowLight = stagelight.GetComponent<Light>();
        nowLight.enabled = true;

        color.a = 0.0f;
        panel.color = color;
    }
}

