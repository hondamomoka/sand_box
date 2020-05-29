using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class save : MonoBehaviour
{
    public bool load;
    public bool save_;
    int []coin;
    int maxStage = 20;
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<maxStage;i++)
        {
            if (PlayerPrefs.HasKey("コイン" + i))
            {
                PlayerPrefs.DeleteKey("コイン" + i);

                Debug.Log("コイン" + i + "消すよ");
        }
        }
       

        if (PlayerPrefs.HasKey("コイン" + 0))
        {
            for (int i = 0; i < maxStage; i++)
            {
                coin[i] = PlayerPrefs.GetInt("コイン" + i);
            }

            Debug.Log("セーブデータあるよ！");
        }
        else
        {
            load = false;
            save_ = false;

            coin = new int[maxStage];

            for (int i = 0; i < maxStage; i++)
            {
                coin[i] = 0;
            }

            Debug.Log("セーブデータないよ！");
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(load)
        {
            Debug.Log("ロードするよ");

            for (int i = 0; i < maxStage; i++)
            {
                coin[i] = PlayerPrefs.GetInt("コイン" + i);
                Debug.Log("コイン"+i+"の状態"+coin[i]);
            }

            load = false;
        }

        if(save_)
        {
            save_coin(1);

            Debug.Log("セーブするよ");
        }
    }

    public void save_coin(int num)
    {
        coin[num] = 1;
        for (int i = 0; i < maxStage; i++)
        {
            PlayerPrefs.SetInt("コイン"+i, coin[i]);
        }
        save_ = false;
    }
}
