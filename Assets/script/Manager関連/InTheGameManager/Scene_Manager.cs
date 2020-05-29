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

    public Stage stage;     //クリア処理出来次第削除予定

    public bool fadeIn;
    public Stage nextScene;

    public int titleSelect;
    public int selectSelect;

    void Awake()
    {
        fadeIn = true;
        nextScene = Stage.SCENE_MAX;

        stage = Stage.TITLE;

        titleSelect = 0;
        selectSelect = 1;
    }

    void Update()
    {
            if (Input.GetKeyDown(KeyCode.R))
                SceneChange(Stage.SELECTS);
    }

    public void SceneChange(Stage change)
    {
        nextScene = change;
    }
}
