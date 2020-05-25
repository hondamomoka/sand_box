using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinEvent : StateMachineBehaviour
{

    public bool openend;

    void Start()
    {
        openend = false;
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.IsName("Open"))
        {
            var num = 128;
            Debug.Log(num);
            Debug.Log("コイン浮き上がるよ");
            openend = true;
        }
    }

    public bool GetOpenEnd()
    {
        return openend;
    }
}