using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class save : MonoBehaviour
{
    public bool init;
    public bool load;
    public bool save_;
    public bool delete_save;
    int []coin;
    int maxStage = 20;
    // Start is called before the first frame update
    void Start()
    {
        init = false;
        load = false;
        save_ = false;
        delete_save = false;
        for (int i = 0; i < maxStage; i++)
        {
            if (PlayerPrefs.HasKey("コイン" + i))
            {
                PlayerPrefs.DeleteKey("コイン" + i);

                Debug.Log("コイン" + i + "消すよ");
            }
        }


        for (int i = 0; i < maxStage; i++)
        {


            coin = new int[maxStage];


            coin[i] = 0;

            Debug.Log("初期化中！" + "コイン" + i);

        }
    }

      

    // Update is called once per frame
    void Update()
    {
        if(load)
        {
            load_coin();
        }

        if(save_)
        {
            save_coin(1);

            
        }

        if(delete_save)
        {
            delete_coin();
        }

        if(init)
        {
            init_coin();
        }
    }

    public void init_coin()
    {
        for (int i = 0; i < maxStage; i++)
        {
            coin[i] = 0;
            PlayerPrefs.SetInt("コイン" + i, coin[i]);
        }

        Debug.Log("初期化したよ");

        init = false;
    }

    public void delete_coin()
    {
        for (int i = 0; i < maxStage; i++)
        {
            if (PlayerPrefs.HasKey("コイン" + i))
            {
                PlayerPrefs.DeleteKey("コイン" + i);

                Debug.Log("コイン" + i + "消すよ");
            }
        }

        delete_save = false;
    }

    public void save_coin(int num)
    {
        coin[num] = 1;
        for (int i = 0; i < maxStage; i++)
        {
            PlayerPrefs.SetInt("コイン"+i, coin[i]);
        }
        Debug.Log("セーブするよ");
        save_ = false;
    }

    public void load_coin()
    {
        Debug.Log("ロードするよ");

        for (int i = 0; i < maxStage; i++)
        {
            if (coin[i] < 0&&coin[i]>4)
            {
                coin[i] = 0;
            }
            else
            {
                coin[i] = PlayerPrefs.GetInt("コイン" + i);
            }
            
            Debug.Log("コイン" + i + "の状態" + coin[i]);
        }

        load = false;
    }
}
