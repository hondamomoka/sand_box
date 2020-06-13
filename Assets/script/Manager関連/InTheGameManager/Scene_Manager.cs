using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour
{
    public enum Stage : int
    {
        TITLE,
        SELECTS,
        OPTION,
        MANUAL,

        STAGE_CELL,
        STAGE_VOLBOX,
        STAGE_JELLYFISH,
        STAGE_CATTLE,
        STAGE_PENGUIN,
        STAGE_UNI,
        STAGE_CROCODILE,
        STAGE_PIG,
        STAGE_GORIRA,
        STAGE_CLIONE,
        STAGE_RABBITS,
        STAGE_WHALE,
        STAGE_CRAB,
        STAGE_SHELL,
        STAGE_SNAILS,
        STAGE_RISU,
        STAGE_DOLPHIN,
        STAGE_COBRA,
        STAGE_PIGEON,
        STAGE_TURTLE,

        SCENE_MAX
    }

    public bool fadeIn;
    public Stage nowScene;
    public Stage nextScene;

    //各シーンでの選択肢の位置を固定したり変更したりするのに用いる
    public int titleSelect;
    public int selectSelect;

    //メニュー表示用の変数
    public bool menuFlag;

    void Awake()
    {
        fadeIn = true;

        nowScene = Stage.TITLE;
        nextScene = Stage.SCENE_MAX;

        titleSelect = 0;
        selectSelect = 1;

        //セーブデータが残ってたらその位置からスタート
        for (int i = 0; i < 20; i++)
        {
            int num = PlayerPrefs.GetInt("コイン" + i, 0);
            //Debug.Log(num);
            if (num != 0)
            {
                titleSelect = 1;
                break;
            }
        }
        menuFlag = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick1Button3) || Input.GetKeyDown(KeyCode.Joystick1Button7))
        {
            if (nowScene > Stage.MANUAL && !menuFlag)
            {
                //GameObjectの型を作ってプレハブを取得
                GameObject obj = (GameObject)Resources.Load("menu");
                //型をもとにプレハブを生成、
                Instantiate(obj, Camera.main.transform.position + Camera.main.transform.forward * 8.0f, Quaternion.identity);
                menuFlag = true;
            }
        }
    }

    public void SceneChange(Stage change)
    {
        nextScene = change;
    }
}
