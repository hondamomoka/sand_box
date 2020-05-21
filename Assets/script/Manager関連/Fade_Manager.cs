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
    public void FadeOut()
    {
        if(script.fadeOut != null)
        {
            Debug.Log(script.fadeOut);
            panel.color = color;
            color.a += speed * Time.deltaTime;

            if (color.a >= 1.0f)
            {
                script.fadeIn = true;
               SceneManager.LoadScene(script.fadeOut);
                script.fadeOut = null;
            }
        }
    }

    void FadeIn()
    {
        if (script.fadeIn == true)
        {
            panel.color = color;
            color.a -= speed * Time.deltaTime;
            if (color.a <= 0.0f)
                script.fadeIn = false;
        }
    }
}
