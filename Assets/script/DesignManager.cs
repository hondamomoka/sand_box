using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesignManager : MonoBehaviour
{
    private GameObject openbook;

    private GameObject Stage_1;
    private GameObject Stage_2;
    private GameObject Stage_3;
    private GameObject Stage_4;
    private GameObject Stage_5;
    private GameObject Stage_6;
    private GameObject Stage_7;
    private GameObject Stage_8;
    private GameObject Stage_9;
    private GameObject Stage_10;
    private GameObject Stage_11;
    private GameObject Stage_12;
    private GameObject Stage_13;
    private GameObject Stage_14;
    private GameObject Stage_15;
    private GameObject Stage_16;
    private GameObject Stage_17;
    private GameObject Stage_18;
    private GameObject Stage_19;
    private GameObject Stage_20;

    public save selectsave;

    int save;

    // Start is called before the first frame update
    void Start()
    {
        openbook = GameObject.Find("Coin");

        Stage_1 = GameObject.Find("せる");
        Stage_2 = GameObject.Find("ぼるぼ");
        Stage_3 = GameObject.Find("うに");
        Stage_4 = GameObject.Find("わに");
        Stage_5 = GameObject.Find("ぶた");
        Stage_6 = GameObject.Find("うさぎ");
        Stage_7 = GameObject.Find("くじら");
        Stage_8 = GameObject.Find("りす");
        Stage_9 = GameObject.Find("イルカ");
        Stage_10 = GameObject.Find("コブラ");
        Stage_11 = GameObject.Find("クラゲ");
        Stage_12 = GameObject.Find("うし");
        Stage_13 = GameObject.Find("ぺんぎん");
        Stage_14 = GameObject.Find("ゴリラ");
        Stage_15 = GameObject.Find("クリオネ");
        Stage_16 = GameObject.Find("かに");
        Stage_17 = GameObject.Find("かい");
        Stage_18 = GameObject.Find("かたつむり");
        Stage_19 = GameObject.Find("はと");
        Stage_20 = GameObject.Find("かめ");

        Stage_1.SetActive(false);
        Stage_2.SetActive(false);
        Stage_3.SetActive(false);
        Stage_4.SetActive(false);
        Stage_5.SetActive(false);
        Stage_6.SetActive(false);
        Stage_7.SetActive(false);
        Stage_8.SetActive(false);
        Stage_9.SetActive(false);
        Stage_10.SetActive(false);
        Stage_11.SetActive(false);
        Stage_12.SetActive(false);
        Stage_13.SetActive(false);
        Stage_14.SetActive(false);
        Stage_15.SetActive(false);
        Stage_16.SetActive(false);
        Stage_17.SetActive(false);
        Stage_18.SetActive(false);
        Stage_19.SetActive(false);
        Stage_20.SetActive(false);

        selectsave.load_coin();
        //selectsave.init_coin();
    }

    // Update is called once per frame
    void Update()
    {
        if (openbook.GetComponent<CoinUp>().EndCoinUp() == true)
        {
            if (selectsave.GetClear(0) > 0)//りす
            {
                Stage_8.SetActive(true);
            }
            if (selectsave.GetClear(1) > 0)//うし
            {
                Stage_12.SetActive(true);
            }
            if (selectsave.GetClear(2) > 0)//せる
            {
                Stage_1.SetActive(true);
            }
            if (selectsave.GetClear(3) > 0)//クリオネ
            {
                Stage_15.SetActive(true);
            }
            if (selectsave.GetClear(4) > 0)//コブラ
            {
                Stage_10.SetActive(true);
            }
            if (selectsave.GetClear(5) > 0)//かに
            {
                Stage_16.SetActive(true);
            }
            if (selectsave.GetClear(6) > 0)//わに
            {
                Stage_4.SetActive(true);
            }
            if (selectsave.GetClear(7) > 0)//イルカ
            {
                Stage_9.SetActive(true);
            }
            if (selectsave.GetClear(8) > 0)//ゴリラ
            {
                Stage_14.SetActive(true);
            }
            if (selectsave.GetClear(9) > 0)//クラゲ
            {
                Stage_11.SetActive(true);
            }
            if (selectsave.GetClear(10) > 0)//ぺんぎん
            {
                Stage_13.SetActive(true);
            }
            if (selectsave.GetClear(11) > 0)//ぶた
            {
                Stage_5.SetActive(true);
            }
            if (selectsave.GetClear(12) > 0)//はと
            {
                Stage_19.SetActive(true);
            }
            if (selectsave.GetClear(13) > 0)//うさぎ
            {
                Stage_6.SetActive(true);
            }
            if (selectsave.GetClear(14) > 0)//かい
            {
                Stage_17.SetActive(true);
            }
            if (selectsave.GetClear(15) > 0)//かたつむり
            {
                Stage_18.SetActive(true);
            }
            if (selectsave.GetClear(16) > 0)//かめ
            {
                Stage_20.SetActive(true);
            }
            if (selectsave.GetClear(17) > 0)//うに
            {
                Stage_3.SetActive(true);
            }
            if (selectsave.GetClear(18) > 0)//ぼるぼ
            {
                Stage_2.SetActive(true);
            }
            if (selectsave.GetClear(19) > 0)//くじら
            {
                Stage_7.SetActive(true);
            }
        }
    }
}