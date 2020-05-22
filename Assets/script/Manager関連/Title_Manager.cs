using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Title_Manager : MonoBehaviour
{
    private int select;     //選択肢、始めはContinue

    private GameObject selectObject;

    private float lsv;      //Lスティック縦に動かしたときの値を格納する
    private bool stickFlag;

    private GameObject audioManager;
    private Audio_Manager script;
    [SerializeField] private AudioClip audioClip1;
    [SerializeField] private AudioClip audioClip2;

    void Awake()
    {
        select = 1;

        selectObject = GameObject.Find("select");

        audioManager = GameObject.Find("GameManager");
        script = audioManager.GetComponent<Audio_Manager>();
    }

    void Update()
    {
        lsv = Input.GetAxis("R_Stick_V");
        if (lsv <= 0.1 && lsv >= -0.1)
            stickFlag = true;

        //決定Aボタン
        if (Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.Z))
        {
            script.PlaySE(audioClip1);
            switch (select)
            {
                case 0:
                    SceneManager.LoadScene("Selects");
                    break;
                case 1:
                    SceneManager.LoadScene("Selects");
                    break;
                case 2:
                    SceneManager.LoadScene("Option");
                    break;
                case 3:
                    SceneManager.LoadScene("Manual");
                    break;
                case 4:
                    Quit();
                    break;
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) || lsv >= 0.9)
        {
            if (selectObject.transform.position.y != -49.0f)
            {
                selectObject.transform.position += new Vector3(0, 30.0f, 0);
                select -= 1;
                script.PlaySE(audioClip2);
                stickFlag = false;
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || lsv <= -0.9)
        {
            if (selectObject.transform.position.y != -169.0f)
            {
                selectObject.transform.position += new Vector3(0, -30.0f, 0);
                select += 1;
                script.PlaySE(audioClip2);
                stickFlag = false;
            }
        }
    }

    void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
      UnityEngine.Application.Quit();
#endif
    }

}
