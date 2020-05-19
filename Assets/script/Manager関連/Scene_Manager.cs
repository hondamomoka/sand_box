using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour
{
    GameObject fadeManager;
    Fade_Manager script;
    public bool fadeIn;
    public string fadeOut;

    void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
      UnityEngine.Application.Quit();
#endif
    }

    void Awake()
    {
        fadeManager = GameObject.Find("Panel");
        script = fadeManager.GetComponent<Fade_Manager>();

        if(fadeIn != true)
        fadeIn = false;
        fadeOut = null;
    }

    void Update()
    {
        switch(SceneManager.GetActiveScene().name)
        {
            //タイトル
            case "Title":
                if (Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Alpha1))
                    fadeOut = "Selects";
                if (Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Alpha2))
                    fadeOut = "Option";
                if (Input.GetKeyDown(KeyCode.Keypad3) || Input.GetKeyDown(KeyCode.Alpha3))
                    fadeOut = "Manual";
                if (Input.GetKeyDown(KeyCode.Keypad4) || Input.GetKeyDown(KeyCode.Alpha4))
                    Quit();
                break;
                //ステージ選択画面
            case "Selects":
                if (Input.GetKeyDown(KeyCode.A))
                    fadeOut = "stage_volbox";
                if (Input.GetKeyDown(KeyCode.B))
                    fadeOut = "stage_uni";
                if (Input.GetKeyDown(KeyCode.C))
                    fadeOut = "stage_dolphin";
                if (Input.GetKeyDown(KeyCode.D))
                    fadeOut = "stage_rabbits";
                if (Input.GetKeyDown(KeyCode.E))
                    fadeOut = "stage_jellyfish";
                if (Input.GetKeyDown(KeyCode.F))
                    fadeOut = "stage_cobra";
                if (Input.GetKeyDown(KeyCode.G))
                    fadeOut = "stage_turtle";
                if (Input.GetKeyDown(KeyCode.H))
                    fadeOut = "stage_pig";
                if (Input.GetKeyDown(KeyCode.I))
                    fadeOut = "stage_gorira";
                if (Input.GetKeyDown(KeyCode.J))
                    fadeOut = "stage_risu";
                if (Input.GetKeyDown(KeyCode.K))
                    fadeOut = "stage_shell";
                if (Input.GetKeyDown(KeyCode.L))
                    fadeOut = "stage_clione";
                if (Input.GetKeyDown(KeyCode.M))
                    fadeOut = "stage_cattle";
                if (Input.GetKeyDown(KeyCode.N))
                    fadeOut = "stage_whale";
                if (Input.GetKeyDown(KeyCode.O))
                    fadeOut = "stage_crocodile";
                if (Input.GetKeyDown(KeyCode.P))
                    fadeOut = "stage_penguin";
                if (Input.GetKeyDown(KeyCode.Q))
                    fadeOut = "stage_snails";
                if (Input.GetKeyDown(KeyCode.R))
                    fadeOut = "stage_pigeon";
                if (Input.GetKeyDown(KeyCode.S))
                    fadeOut = "stage_crab";
                if (Input.GetKeyDown(KeyCode.T))
                    fadeOut = "stage_turtle";

                //タイトルへ戻る
                if (Input.GetKeyDown(KeyCode.Keypad0) || Input.GetKeyDown(KeyCode.Alpha0))
                    fadeOut = "Title";
                break;
                //操作説明画面
            case "Manual":
                if (Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Alpha1))
                    fadeOut = "Title";
                break;
                //オプション画面
            case "Option":
                if (Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Alpha1))
                    fadeOut = "Title";
                break;
                //ゲーム中のポーズ画面
            case "Menu":
                if (Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Alpha1))
                    fadeOut = "SampleScene";
                if (Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Alpha2))
                    fadeOut = "Selects";
                break;

            //ゲーム画面
            default:
                if (Input.GetKeyDown(KeyCode.Y))
                    fadeOut = "Selects";

                break;
        }
    }
}
