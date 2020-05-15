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
                //ステージ選択画面
            case "Selects":
                if (Input.GetKeyDown(KeyCode.A))
                    SceneManager.LoadScene("stage_volbox");
                if (Input.GetKeyDown(KeyCode.B))
                    SceneManager.LoadScene("stage_uni");
                if (Input.GetKeyDown(KeyCode.C))
                    SceneManager.LoadScene("stage_dolphin");
                if (Input.GetKeyDown(KeyCode.D))
                    SceneManager.LoadScene("stage_rabbits");
                if (Input.GetKeyDown(KeyCode.E))
                    SceneManager.LoadScene("stage_jellyfish");
                if (Input.GetKeyDown(KeyCode.F))
                    SceneManager.LoadScene("stage_cobra");
                if (Input.GetKeyDown(KeyCode.G))
                    SceneManager.LoadScene("stage_turtle");
                if (Input.GetKeyDown(KeyCode.H))
                    SceneManager.LoadScene("stage_pig");
                if (Input.GetKeyDown(KeyCode.I))
                    SceneManager.LoadScene("stage_gorira");
                if (Input.GetKeyDown(KeyCode.J))
                    SceneManager.LoadScene("stage_risu");
                if (Input.GetKeyDown(KeyCode.K))
                    SceneManager.LoadScene("stage_shell");
                if (Input.GetKeyDown(KeyCode.L))
                    SceneManager.LoadScene("stage_clione");
                if (Input.GetKeyDown(KeyCode.M))
                    SceneManager.LoadScene("stage_cattle");
                if (Input.GetKeyDown(KeyCode.N))
                    SceneManager.LoadScene("stage_whale");
                if (Input.GetKeyDown(KeyCode.O))
                    SceneManager.LoadScene("stage_crocodile");
                if (Input.GetKeyDown(KeyCode.P))
                    SceneManager.LoadScene("stage_penguin");
                if (Input.GetKeyDown(KeyCode.Q))
                    SceneManager.LoadScene("stage_snails");
                if (Input.GetKeyDown(KeyCode.R))
                    SceneManager.LoadScene("stage_pigeon");
                if (Input.GetKeyDown(KeyCode.S))
                    SceneManager.LoadScene("stage_crab");
                if (Input.GetKeyDown(KeyCode.T))
                    SceneManager.LoadScene("stage_turtle");

                //タイトルへ戻る
                if (Input.GetKeyDown(KeyCode.Keypad0) || Input.GetKeyDown(KeyCode.Alpha0))
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

            //ゲーム画面
            default:
                if (Input.GetKeyDown(KeyCode.Y))
                    SceneManager.LoadScene("Selects");

                break;
        }
    }
}
