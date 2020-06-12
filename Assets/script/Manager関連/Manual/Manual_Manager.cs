using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manual_Manager : MonoBehaviour
{
    [SerializeField] private AudioClip audioClip;

    private bool fadeFlag;

    void Awake()
    {
        fadeFlag = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Joystick1Button1) || Input.GetKeyDown(KeyCode.X))
        {
            if (!Game_Manager.Instance.sm.fadeIn && !fadeFlag)
            {
                Game_Manager.Instance.am.PlaySE(audioClip);
                Game_Manager.Instance.sm.SceneChange(Scene_Manager.Stage.TITLE);
                fadeFlag = true;
            }
        }
    }
}
