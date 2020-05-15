using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;     //UIを使用可能にする

public class Fade_Manager : MonoBehaviour
{
    public float speed = 0.01f;  //透明化の速さ
    float alfa;                  //A値を操作するための変数
    float red, green, blue;      //RGBを操作するための変数

    void Awake()
    {
        //Panelの色を取得
        red = GetComponent<Image>().color.r;
        green = GetComponent<Image>().color.g;
        blue = GetComponent<Image>().color.b;
        Debug.Log("見えてる？");
    }

    void Update()
    {
        GetComponent<Image>().color = new Color(red, green, blue, alfa);
        alfa += speed;
        Debug.Log(alfa);
    }
}
