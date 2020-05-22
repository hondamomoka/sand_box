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
    Color color;                 //RGBを操作するための変数

    GameObject gameManager;
    Scene_Manager script;

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
        script = gameManager.GetComponent<Scene_Manager>();

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
        FadeOut();
        FadeIn();
    }

    //フェードの関数
    void FadeOut()
    {
        if (script.fadeOut != Scene_Manager.Stage.SCENE_MAX)
        {
            panel.color = color;
            color.a += speed * Time.deltaTime;

            if (color.a >= 1.0f)
            {
                script.fadeIn = true;
                SceneManager.LoadScene((int)script.fadeOut);
                script.fadeOut = Scene_Manager.Stage.SCENE_MAX;
            }
        }
    }

    void FadeIn()
    {
        if (script.fadeIn == true)
        {
            if(script.fadeOut != Scene_Manager.Stage.SCENE_MAX)
                script.fadeIn = false;
            panel.color = color;
            color.a -= speed * Time.deltaTime;
            if (color.a <= 0.0f)
                script.fadeIn = false;
        }
    }
}
