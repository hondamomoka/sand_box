using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manual_Manager : MonoBehaviour
{
    private GameObject manager;
    private Audio_Manager am;
    private Scene_Manager sm;

    [SerializeField] private AudioClip audioClip;

    private bool fadeFlag;

    void Awake()
    {
        manager = GameObject.Find("GameManager");
        am = manager.GetComponent<Audio_Manager>();
        sm = manager.GetComponent<Scene_Manager>();

        fadeFlag = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button1) || Input.GetKeyDown(KeyCode.X))
        {
            if (!sm.fadeIn && !fadeFlag)
            {
                am.PlaySE(audioClip);
                sm.SceneChange(Scene_Manager.Stage.TITLE);
                fadeFlag = true;
            }
        }
    }
}
