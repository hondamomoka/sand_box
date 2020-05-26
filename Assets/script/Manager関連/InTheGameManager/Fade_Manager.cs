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

    private GameObject gameManager;
    private Scene_Manager sm;
    private Audio_Manager am;

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
        gameManager = GameObject.Find("GameManager");
        sm = gameManager.GetComponent<Scene_Manager>();
        am = gameManager.GetComponent<Audio_Manager>();

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
        if (sm.nextScene != Scene_Manager.Stage.SCENE_MAX)
        {
            if (sm.fadeIn == true)
                sm.nextScene = Scene_Manager.Stage.SCENE_MAX;

            panel.color = color;
            color.a += speed * Time.deltaTime;

            if ((int)sm.nextScene > (int)Scene_Manager.Stage.MANUAL)
            {
                am.source.volume -= speed * Time.deltaTime;
            }

            if (color.a >= 1.0f)
            {
                sm.fadeIn = true;
                SceneManager.LoadScene((int)sm.nextScene);
                sm.nextScene = Scene_Manager.Stage.SCENE_MAX;
                if(am.source.volume < am.bgVol)
                am.source.Stop();
            }
        }
    }

    void FadeIn()
    {
        if (sm.fadeIn == true)
        {
            panel.color = color;
            color.a -= speed * Time.deltaTime;
            if (color.a <= 0.0f)
            {
                sm.fadeIn = false;
            }
        }
    }
}

