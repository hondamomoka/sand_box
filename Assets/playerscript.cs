using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerscript : MonoBehaviour
{
    private Rigidbody rb_Player;
    private Vector3 player_velocity;

    [SerializeField] private rotation script;
    [SerializeField] private rotation_panguin pScript;

    private bool menuFlag;


    void Awake()
    {
        rb_Player = GetComponent<Rigidbody>();
    }
    void Start()
    {
        player_velocity = new Vector3(0,0,0);
        menuFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (script != null)
        {
            //メニューが開いた最初だけ自機の動きを停止させる
            if (!script.rotateFlag && !menuFlag && Game_Manager.Instance.am.source[2].isPlaying)
            {
                rb_Player.isKinematic = true;
                menuFlag = true;
                return;
            }
            //2週目以降は飛ばすだけ
            else if (!script.rotateFlag)
            {
                return;
            }
            //メニューが解除された最初は全ての砂に値を入れていく
            else if (script.rotateFlag && menuFlag)
            {
                //保存しておいた値を代入する
                rb_Player.isKinematic = false;
                rb_Player.velocity = player_velocity;
                menuFlag = false;
            }
        }
        else if (pScript != null)
        {
            //メニューが開いた最初だけ自機の動きを停止させる
            if (!pScript.rotateFlag && !menuFlag && Game_Manager.Instance.am.source[2].isPlaying)
            {
                rb_Player.isKinematic = true;
                menuFlag = true;
                return;
            }
            //2週目以降は飛ばすだけ
            else if (!pScript.rotateFlag)
            {
                return;
            }
            //メニューが解除された最初は全ての砂に値を入れていく
            else if (pScript.rotateFlag && menuFlag)
            {
                //保存しておいた値を代入する
                rb_Player.isKinematic = false;
                rb_Player.velocity = player_velocity;
                menuFlag = false;
            }
        }
        
        //値を保存しておく
        player_velocity = rb_Player.velocity;
    }
}
