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

    private float pos;

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

        pos = 1.19f;
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
                Stage_8.transform.position = new Vector3(Stage_8.transform.position.x, pos, Stage_8.transform.position.z);
            }
            else
            {
                Stage_8.transform.position = new Vector3(Stage_8.transform.position.x, 0.0f, Stage_8.transform.position.z);
            }


            if (selectsave.GetClear(1) > 0)//うし
            {
                Stage_12.transform.position = new Vector3(Stage_12.transform.position.x, pos, Stage_12.transform.position.z);
            }
            else
            {
                Stage_12.transform.position = new Vector3(Stage_12.transform.position.x, 0.0f, Stage_12.transform.position.z);
            }


            if (selectsave.GetClear(2) > 0)//せる
            {
                Stage_1.transform.position = new Vector3(Stage_1.transform.position.x, pos, Stage_1.transform.position.z);
            }
            else
            {
                Stage_1.transform.position = new Vector3(Stage_1.transform.position.x, 0.0f, Stage_1.transform.position.z);
            }


            if (selectsave.GetClear(3) > 0)//クリオネ
            {
                Stage_15.transform.position = new Vector3(Stage_15.transform.position.x, pos, Stage_15.transform.position.z);
            }
            else
            {
                Stage_15.transform.position = new Vector3(Stage_15.transform.position.x, 0.0f, Stage_15.transform.position.z);
            }


            if (selectsave.GetClear(4) > 0)//コブラ
            {
                Stage_10.transform.position = new Vector3(Stage_10.transform.position.x, pos, Stage_10.transform.position.z);
            }
            else
            {
                Stage_10.transform.position = new Vector3(Stage_10.transform.position.x, 0.0f, Stage_10.transform.position.z);
            }


            if (selectsave.GetClear(5) > 0)//かに
            {
                Stage_16.transform.position = new Vector3(Stage_16.transform.position.x, pos, Stage_16.transform.position.z);
            }
            else
            {
                Stage_16.transform.position = new Vector3(Stage_16.transform.position.x, 0.0f, Stage_16.transform.position.z);
            }


            if (selectsave.GetClear(6) > 0)//わに
            {
                Stage_4.transform.position = new Vector3(Stage_4.transform.position.x, pos, Stage_4.transform.position.z);
            }
            else
            {
                Stage_4.transform.position = new Vector3(Stage_4.transform.position.x, 0.0f, Stage_4.transform.position.z);
            }


            if (selectsave.GetClear(7) > 0)//イルカ
            {
                Stage_9.transform.position = new Vector3(Stage_9.transform.position.x, pos, Stage_9.transform.position.z);
            }
            else
            {
                Stage_9.transform.position = new Vector3(Stage_9.transform.position.x, 0.0f, Stage_9.transform.position.z);
            }


            if (selectsave.GetClear(8) > 0)//ゴリラ
            {
                Stage_14.transform.position = new Vector3(Stage_14.transform.position.x, pos, Stage_14.transform.position.z);
            }
            else
            {
                Stage_14.transform.position = new Vector3(Stage_14.transform.position.x, 0.0f, Stage_14.transform.position.z);
            }


            if (selectsave.GetClear(9) > 0)//クラゲ
            {
                Stage_11.transform.position = new Vector3(Stage_11.transform.position.x, pos, Stage_11.transform.position.z);
            }
            else
            {
                Stage_11.transform.position = new Vector3(Stage_11.transform.position.x, 0.0f, Stage_11.transform.position.z);
            }


            if (selectsave.GetClear(10) > 0)//ぺんぎん
            {
                Stage_13.transform.position = new Vector3(Stage_13.transform.position.x, pos, Stage_13.transform.position.z);
            }
            else
            {
                Stage_13.transform.position = new Vector3(Stage_13.transform.position.x, 0.0f, Stage_13.transform.position.z);
            }


            if (selectsave.GetClear(11) > 0)//ぶた
            {
                Stage_5.transform.position = new Vector3(Stage_5.transform.position.x, pos, Stage_5.transform.position.z);
            }
            else
            {
                Stage_5.transform.position = new Vector3(Stage_5.transform.position.x, 0.0f, Stage_5.transform.position.z);
            }


            if (selectsave.GetClear(12) > 0)//はと
            {
                Stage_19.transform.position = new Vector3(Stage_19.transform.position.x, pos, Stage_19.transform.position.z);
            }
            else
            {
                Stage_19.transform.position = new Vector3(Stage_19.transform.position.x, 0.0f, Stage_19.transform.position.z);
            }


            if (selectsave.GetClear(13) > 0)//うさぎ
            {
                Stage_6.transform.position = new Vector3(Stage_6.transform.position.x, pos, Stage_6.transform.position.z);
            }
            else
            {
                Stage_6.transform.position = new Vector3(Stage_6.transform.position.x, 0.0f, Stage_6.transform.position.z);
            }


            if (selectsave.GetClear(14) > 0)//かい
            {
                Stage_17.transform.position = new Vector3(Stage_17.transform.position.x, pos, Stage_17.transform.position.z);
            }
            else
            {
                Stage_17.transform.position = new Vector3(Stage_17.transform.position.x, 0.0f, Stage_17.transform.position.z);
            }


            if (selectsave.GetClear(15) > 0)//かたつむり
            {
                Stage_18.transform.position = new Vector3(Stage_18.transform.position.x, pos, Stage_18.transform.position.z);
            }
            else
            {
                Stage_18.transform.position = new Vector3(Stage_18.transform.position.x, 0.0f, Stage_18.transform.position.z);
            }


            if (selectsave.GetClear(16) > 0)//かめ
            {
                Stage_20.transform.position = new Vector3(Stage_20.transform.position.x, pos, Stage_20.transform.position.z);
            }
            else
            {
                Stage_20.transform.position = new Vector3(Stage_20.transform.position.x, 0.0f, Stage_20.transform.position.z);
            }


            if (selectsave.GetClear(17) > 0)//うに
            {
                Stage_3.transform.position = new Vector3(Stage_3.transform.position.x, pos, Stage_3.transform.position.z);
            }
            else
            {
                Stage_3.transform.position = new Vector3(Stage_3.transform.position.x, 0.0f, Stage_3.transform.position.z);
            }


            if (selectsave.GetClear(18) > 0)//ぼるぼ
            {
                Stage_2.transform.position = new Vector3(Stage_2.transform.position.x, pos, Stage_2.transform.position.z);
            }
            else
            {
                Stage_2.transform.position = new Vector3(Stage_2.transform.position.x, 0.0f, Stage_2.transform.position.z);
            }


            if (selectsave.GetClear(19) > 0)//くじら
            {
                Stage_7.transform.position = new Vector3(Stage_7.transform.position.x, pos, Stage_7.transform.position.z);
            }
            else
            {
                Stage_7.transform.position = new Vector3(Stage_7.transform.position.x, 0.0f, Stage_7.transform.position.z);
            }
        }
    }
}