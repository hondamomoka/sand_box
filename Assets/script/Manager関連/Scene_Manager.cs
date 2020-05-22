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
        STAGE_UNI,
        STAGE_DOLPHIN,
        STAGE_RABBITS,
        STAGE_COBRA,
        STAGE_TURTLE,
        STAGE_PIG,
        STAGE_GORIRA,
        STAGE_RISU,
        STAGE_SHELL,
        STAGE_CLIONE,
        STAGE_CATTLE,
        STAGE_WHALE,
        STAGE_CROCODILE,
        STAGE_JELLYFISH,
        STAGE_PENGUIN,
        STAGE_SNAILS,
        STAGE_PIGEON,
        STAGE_CRAB,

        SCENE_MAX
    }

    public Stage stage;

    GameObject fadeManager;
    Fade_Manager script;
    public bool fadeIn;
    public Stage fadeOut;

    void Awake()
    {
        fadeManager = GameObject.Find("fade");
        script = fadeManager.GetComponent<Fade_Manager>();

        if(fadeIn != true)
        fadeIn = false;
        fadeOut = Stage.SCENE_MAX;

        stage = Stage.TITLE;
    }

    void Update()
    {
        //ステージ選択画面
        if (stage == Stage.SELECTS)
        {
            if (Input.GetKeyDown(KeyCode.A))
                SceneChange(Stage.STAGE_CELL);
            else if (Input.GetKeyDown(KeyCode.B))
                SceneChange(Stage.STAGE_VOLBOX);
            else if (Input.GetKeyDown(KeyCode.C))
                SceneChange(Stage.STAGE_UNI);
            else if (Input.GetKeyDown(KeyCode.D))
                SceneChange(Stage.STAGE_DOLPHIN);
            else if (Input.GetKeyDown(KeyCode.E))
                SceneChange(Stage.STAGE_RABBITS);
            else if (Input.GetKeyDown(KeyCode.F))
                SceneChange(Stage.STAGE_COBRA);
            else if (Input.GetKeyDown(KeyCode.G))
                SceneChange(Stage.STAGE_TURTLE);
            else if (Input.GetKeyDown(KeyCode.H))
                SceneChange(Stage.STAGE_PIG);
            else if (Input.GetKeyDown(KeyCode.I))
                SceneChange(Stage.STAGE_GORIRA);
            else if (Input.GetKeyDown(KeyCode.J))
                SceneChange(Stage.STAGE_RISU);
            else if (Input.GetKeyDown(KeyCode.K))
                SceneChange(Stage.STAGE_SHELL);
            else if (Input.GetKeyDown(KeyCode.L))
                SceneChange(Stage.STAGE_CLIONE);
            else if (Input.GetKeyDown(KeyCode.M))
                SceneChange(Stage.STAGE_CATTLE);
            else if (Input.GetKeyDown(KeyCode.N))
                SceneChange(Stage.STAGE_WHALE);
            else if (Input.GetKeyDown(KeyCode.O))
                SceneChange(Stage.STAGE_CROCODILE);
            else if (Input.GetKeyDown(KeyCode.P))
                SceneChange(Stage.STAGE_JELLYFISH);
            else if (Input.GetKeyDown(KeyCode.Q))
                SceneChange(Stage.STAGE_PENGUIN);
            else if (Input.GetKeyDown(KeyCode.R))
                SceneChange(Stage.STAGE_SNAILS);
            else if (Input.GetKeyDown(KeyCode.S))
                SceneChange(Stage.STAGE_PIGEON);
            else if (Input.GetKeyDown(KeyCode.T))
                SceneChange(Stage.STAGE_CRAB);
            else if (Input.GetKeyDown(KeyCode.U))
                SceneChange(Stage.TITLE);
        }
    }

    public void SceneChange(Stage change)
    {
        fadeOut = change;
    }
}
