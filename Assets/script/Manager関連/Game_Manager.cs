﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Game_Manager : MonoBehaviour
{
    //シーン遷移をしてもこのオブジェクトが破棄されない
    public static Game_Manager Instance
    {
        get; private set;
    }
    //開始時処理
    void Awake()
    {
    if (Instance != null)
        {
            Destroy (gameObject);
            return;
        }
    Instance = this;
    DontDestroyOnLoad (gameObject);
    }
}