using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour
{
    void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
      UnityEngine.Application.Quit();
#endif
    }

    // Update is called once per frame
    void Update()
    {
        switch(SceneManager.GetActiveScene().name)
        {
            //タイトル
            case "Title":
                if (Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Alpha1))
                    SceneManager.LoadScene("Selects");
                if (Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Alpha2))
                    SceneManager.LoadScene("Option");
                if (Input.GetKeyDown(KeyCode.Keypad3) || Input.GetKeyDown(KeyCode.Alpha3))
                    SceneManager.LoadScene("Manual");
                if (Input.GetKeyDown(KeyCode.Keypad4) || Input.GetKeyDown(KeyCode.Alpha4))
                    Quit();
                break;
                //難易度選択画面
            case "Selects":
                if (Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Alpha1))
                    SceneManager.LoadScene("stage_uni");
                if (Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Alpha2))
                    SceneManager.LoadScene("stage_dolphin");
                if (Input.GetKeyDown(KeyCode.Keypad3) || Input.GetKeyDown(KeyCode.Alpha3))
                    SceneManager.LoadScene("stage_rabbits");
                if (Input.GetKeyDown(KeyCode.Keypad4) || Input.GetKeyDown(KeyCode.Alpha4))
                    SceneManager.LoadScene("stage_jellyfish");
                if (Input.GetKeyDown(KeyCode.Keypad5) || Input.GetKeyDown(KeyCode.Alpha5))
                    SceneManager.LoadScene("stage_cobra");
                if (Input.GetKeyDown(KeyCode.Keypad6) || Input.GetKeyDown(KeyCode.Alpha6))
                    SceneManager.LoadScene("stage_turtle");

                if (Input.GetKeyDown(KeyCode.Keypad7) || Input.GetKeyDown(KeyCode.Alpha7))
                    SceneManager.LoadScene("Title");
                break;
                //操作説明画面
            case "Manual":
                if (Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Alpha1))
                    SceneManager.LoadScene("Title");
                break;
                //オプション画面
            case "Option":
                if (Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Alpha1))
                    SceneManager.LoadScene("Title");
                break;
                //ゲーム中のポーズ画面
            case "Menu":
                if (Input.GetKeyDown(KeyCode.Keypad1) || Input.GetKeyDown(KeyCode.Alpha1))
                    SceneManager.LoadScene("SampleScene");
                if (Input.GetKeyDown(KeyCode.Keypad2) || Input.GetKeyDown(KeyCode.Alpha2))
                    SceneManager.LoadScene("Selects");
                break;
            //    //ゲーム画面
            //case "SampleScene":
            //    //Yでポーズ画面へ遷移できるが内容が初期化されてしまう
            //    if (Input.GetKeyDown(KeyCode.Y))
            //        SceneManager.LoadScene("Menu");
            //    break;

            //ゲーム画面
            default:
                if (Input.GetKeyDown(KeyCode.Y))
                    SceneManager.LoadScene("Selects");

                break;
        }
    }
}
