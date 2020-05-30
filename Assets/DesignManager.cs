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

    private bool flag1;
    private bool flag2;
    private bool flag3;
    private bool flag4;
    private bool flag5;
    private bool flag6;
    private bool flag7;
    private bool flag8;
    private bool flag9;
    private bool flag10;
    private bool flag11;
    private bool flag12;
    private bool flag13;
    private bool flag14;
    private bool flag15;
    private bool flag16;
    private bool flag17;
    private bool flag18;
    private bool flag19;
    private bool flag20;

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

        flag1 = false;
        flag2 = false;
        flag3 = false;
        flag4 = false;
        flag5 = false;
        flag6 = false;
        flag7 = false;
        flag8 = false;
        flag9 = false;
        flag10 = false;
        flag11 = false;
        flag12 = false;
        flag13 = false;
        flag14 = false;
        flag15 = false;
        flag16 = false;
        flag17 = false;
        flag18 = false;
        flag19 = false;
        flag20 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (openbook.GetComponent<CoinUp>().EndCoinUp() == true)
        {
            if (flag1 == true)
            {
                Stage_1.SetActive(true);
            }
            if (flag2 == true)
            {
                Stage_2.SetActive(true);
            }
            if (flag3 == true)
            {
                Stage_3.SetActive(true);
            }
            if (flag4 == true)
            {
                Stage_4.SetActive(true);
            }
            if (flag5 == true)
            {
                Stage_5.SetActive(true);
            }
            if (flag6 == true)
            {
                Stage_6.SetActive(true);
            }
            if (flag7 == true)
            {
                Stage_7.SetActive(true);
            }
            if (flag8 == true)
            {
                Stage_8.SetActive(true);
            }
            if (flag9 == true)
            {
                Stage_9.SetActive(true);
            }
            if (flag10 == true)
            {
                Stage_10.SetActive(true);
            }
            if (flag11 == true)
            {
                Stage_11.SetActive(true);
            }
            if (flag12 == true)
            {
                Stage_12.SetActive(true);
            }
            if (flag13 == true)
            {
                Stage_13.SetActive(true);
            }
            if (flag14 == true)
            {
                Stage_14.SetActive(true);
            }
            if (flag15 == true)
            {
                Stage_15.SetActive(true);
            }
            if (flag16 == true)
            {
                Stage_16.SetActive(true);
            }
            if (flag17 == true)
            {
                Stage_17.SetActive(true);
            }
            if (flag18 == true)
            {
                Stage_18.SetActive(true);
            }
            if (flag19 == true)
            {
                Stage_19.SetActive(true);
            }
            if (flag20 == true)
            {
                Stage_20.SetActive(true);
            }
        }
        else
        {
            if (flag1 == false)
            {
                Stage_1.SetActive(false);
            }
            if (flag2 == false)
            {
                Stage_2.SetActive(false);
            }
            if (flag3 == false)
            {
                Stage_3.SetActive(false);
            }
            if (flag4 == false)
            {
                Stage_4.SetActive(false);
            }
            if (flag5 == false)
            {
                Stage_5.SetActive(false);
            }
            if (flag6 == false)
            {
                Stage_6.SetActive(false);
            }
            if (flag7 == false)
            {
                Stage_7.SetActive(false);
            }
            if (flag8 == false)
            {
                Stage_8.SetActive(false);
            }
            if (flag9 == false)
            {
                Stage_9.SetActive(false);
            }
            if (flag10 == false)
            {
                Stage_10.SetActive(false);
            }
            if (flag11 == false)
            {
                Stage_11.SetActive(false);
            }
            if (flag12 == false)
            {
                Stage_12.SetActive(false);
            }
            if (flag13 == false)
            {
                Stage_13.SetActive(false);
            }
            if (flag14 == false)
            {
                Stage_14.SetActive(false);
            }
            if (flag15 == false)
            {
                Stage_15.SetActive(false);
            }
            if (flag16 == false)
            {
                Stage_16.SetActive(false);
            }
            if (flag17 == false)
            {
                Stage_17.SetActive(false);
            }
            if (flag18 == false)
            {
                Stage_18.SetActive(false);
            }
            if (flag19 == false)
            {
                Stage_19.SetActive(false);
            }
            if (flag20 == false)
            {
                Stage_20.SetActive(false);
            }
        }

        flag20 = true;
    }
}
