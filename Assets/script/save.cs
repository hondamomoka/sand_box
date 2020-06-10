using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class save : MonoBehaviour
{
    public bool init;
    public bool load;
    public bool save_;
    public bool delete_save;
    static int []coin;
    int maxStage = 20;
    static bool start;
    static bool old;
    
    // Start is called before the first frame update
    void Start()
    {
        coin = new int[maxStage];

        old = Selects_Manager.GetOldScene();
        if (old == true)
        {
            start = Title_Manager.GetContinue();
        }
        if (!start)
        {
            start = true;
            init_coin();

            //for (int i = 0; i < maxStage; i++)
            //{
            //    if (PlayerPrefs.HasKey("コイン" + i))
            //    {
            //        PlayerPrefs.DeleteKey("コイン" + i);

            //        Debug.Log("コイン" + i + "消すよ");
            //    }


            //    coin[i] = 0;

            //    Debug.Log("初期化中！" + "コイン" + i);
            //}

        }
        else
        {
            Debug.Log("する～");
            load_coin();
        }
        init = false;
        load = false;
        save_ = false;
        delete_save = false;
    }

      

    // Update is called once per frame
    void Update()
    {
        //if(load)
        //{
        //    load_coin();
        //}

        //if(save_)
        //{
        //    save_coin(1);

            
        //}

        //if(delete_save)
        //{
        //    delete_coin();
        //}

        //if(init)
        //{
        //    init_coin();
        //}
    }

    public void init_coin()
    {
        for (int i = 0; i < maxStage; i++)
        {
            coin[i] = 0;
            PlayerPrefs.GetInt("コイン" + i, 1);
            PlayerPrefs.SetInt("コイン" + i, coin[i]);
            PlayerPrefs.Save();
            //PlayerPrefs.SetInt("コイン" + i, coin[i]);
        }
        //PlayerPrefs.Save();
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

    public void save_coin(int num,int lank)
    {
        //coin[num] = 1;
        //for (int i = 0; i < maxStage; i++)
        //{
        //    PlayerPrefs.SetInt("コイン"+i, coin[i]);
        //}

        PlayerPrefs.SetInt("コイン" + num, lank);
        PlayerPrefs.Save();
        Debug.Log("セーブするよ"+lank);
        save_ = false;
    }

    public void load_coin()
    {
        Debug.Log("ロードするよ");

        for (int i = 0; i < maxStage; i++)
        {


            coin[i] = PlayerPrefs.GetInt("コイン" + i, 0);
            Debug.Log("コイン" + i + "の状態" + coin[i]);
        }

        load = false;
    }

    public int GetClear(int i)
    {
        return coin[i];
    }
}
