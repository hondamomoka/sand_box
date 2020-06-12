using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandSE : MonoBehaviour
{
    public GameObject[] SandCreater;
    public int Sands_Max;       // 発生するオブジェクトの総数
    public int Sands_Num;
    public GameObject[][] obj_sands;
    public float SE_Idx;
    public float Move_Idx;

    CreateSandsKyo[] Sand_Script;
    [SerializeField] private rotation script;
    [SerializeField] private rotation_panguin pScript;

    private Rigidbody[][] rb_sands;
    private int MoveSands_Cnt;                     //動いている砂の数を数える
    private int VeryMoveSands_Cnt;                 //特に動いている砂の数を数える
    private float Sands_Speed;                     //動いている砂の速度
    private float Sands_Speed_Avarage;             //動いている砂の速度の平均
    private Vector2[][] Sands_velocity;            //動いている砂の速度を一時格納する
    private Vector2[][] Sands_velocity_plus;       //動いている砂の速度を一時格納していじるための変数

    private bool menuFlag;                         //menuが開かれた瞬間だけonになる

    //音を鳴らすために追加
    private GameObject audioManager;
    private Audio_Manager am;
    [SerializeField] private AudioClip audioClip;

    // Start is called before the first frame update
    void Start()
    {
        Sand_Script = new CreateSandsKyo[SandCreater.Length];
        obj_sands = new GameObject[SandCreater.Length][];
        rb_sands = new Rigidbody[SandCreater.Length][];
        Sands_velocity = new Vector2[SandCreater.Length][];
        Sands_velocity_plus = new Vector2[SandCreater.Length][];

        for (int i = 0; i < SandCreater.Length; i++)
        {
            Sand_Script[i] = SandCreater[i].GetComponent<CreateSandsKyo>();
            obj_sands[i] = Sand_Script[i].obj_sands;
            rb_sands[i] = Sand_Script[i].rb_sands;
            Sands_velocity[i] = new Vector2[obj_sands[i].Length];
            Sands_Max += obj_sands[i].Length;
            Sands_velocity_plus[i] = new Vector2[obj_sands[i].Length];
        }

        MoveSands_Cnt = 0;
        //音を鳴らすために追加
        audioManager = GameObject.Find("GameManager");
        am = audioManager.GetComponent<Audio_Manager>();

        //砂の音生成
        if (am.seVol > 0.0f)
            am.PlaySandSE(audioClip);

        menuFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (script != null)
        {
            //メニューが開いた最初だけ砂の動きを停止させる
            if (!script.rotateFlag && !menuFlag)
            {
                for (int i = 0; i < obj_sands.Length; i++)
                {
                    for (int j = 0; j < obj_sands[i].Length; j++)
                    {
                        if (obj_sands[i][j] != null && obj_sands[i][j].activeSelf == true)
                            rb_sands[i][j].isKinematic = true;
                    }
                }
                //音は小さめにしておく
                am.source[2].volume = 0.1f;

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
                for (int i = 0; i < obj_sands.Length; i++)
                {
                    for (int j = 0; j < obj_sands[i].Length; j++)
                    {
                        if (obj_sands[i][j] != null && obj_sands[i][j].activeSelf == true)
                        {
                            rb_sands[i][j].isKinematic = false;
                            rb_sands[i][j].velocity = Sands_velocity[i][j];
                        }
                    }
                }
                menuFlag = false;
            }
        }
        else if (pScript != null)
        {
            //メニューが開いた最初だけ砂の動きを停止させる
            if (!pScript.rotateFlag && !menuFlag)
            {
                for (int i = 0; i < obj_sands.Length; i++)
                {
                    for (int j = 0; j < obj_sands[i].Length; j++)
                    {
                        if (obj_sands[i][j] != null && obj_sands[i][j].activeSelf == true)
                            rb_sands[i][j].isKinematic = true;
                    }
                }
                //音は小さめにしておく
                am.source[2].volume = 0.1f;

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
                for (int i = 0; i < obj_sands.Length; i++)
                {
                    for (int j = 0; j < obj_sands[i].Length; j++)
                    {
                        if (obj_sands[i][j] != null && obj_sands[i][j].activeSelf == true)
                        {
                            rb_sands[i][j].isKinematic = false;
                            rb_sands[i][j].velocity = Sands_velocity[i][j];
                        }
                    }
                }
                menuFlag = false;
            }
        }

        //現在の砂の数を取得
        Sands_Num = 0;

        //砂はおそらく自由落下で13ほど
        MoveSands_Cnt = 0;
        VeryMoveSands_Cnt = 0;
        Sands_Speed = 0;
        Sands_Speed_Avarage = 0;

        //砂の音の設定初期化
        am.source[2].volume = am.seVol;

        for (int i = 0; i < obj_sands.Length; i++)
        {
            for (int j = 0; j < obj_sands[i].Length; j++)
            {
                if (obj_sands[i][j] != null && obj_sands[i][j].activeSelf == true)
                {
                    Sands_Num++;
                    //生きてる砂の速度をそれ用の変数に格納する
                    //Sands_velocity_plus[i][j].x = Sands_velocity[i][j].x = rb_sands[i][j].velocity.x;
                    //Sands_velocity_plus[i][j].y = Sands_velocity[i][j].y = rb_sands[i][j].velocity.y;
                    Sands_velocity_plus[i][j].x = rb_sands[i][j].velocity.x;
                    Sands_velocity_plus[i][j].y = rb_sands[i][j].velocity.y;

                    Sands_velocity[i][j].x = rb_sands[i][j].velocity.x;
                    Sands_velocity[i][j].y = rb_sands[i][j].velocity.y;

                    //使いやすくするために+-を調整する
                    if (Sands_velocity_plus[i][j].x < 0)
                        Sands_velocity_plus[i][j].x *= -1.0f;
                    if (Sands_velocity_plus[i][j].y < 0)
                        Sands_velocity_plus[i][j].y *= -1.0f;

                    //砂の速度が一定以上であったら動いてると判定する
                    if (rb_sands[i][j].velocity.x < -0.5f || rb_sands[i][j].velocity.y < -0.5f)
                        MoveSands_Cnt++;

                    //砂の速度を変数に格納
                    Sands_Speed = (float)System.Math.Sqrt(System.Math.Pow(Sands_velocity_plus[i][j].x, 2) + System.Math.Pow(Sands_velocity_plus[i][j].y, 2));

                    Sands_Speed_Avarage += Sands_Speed;

                    //砂の速さは2.3以上で早いと判断
                    if (Sands_Speed > SE_Idx)
                    {
                        VeryMoveSands_Cnt++;
                    }
                }
            }
        }

        //SEの音量が0じゃなければ音量調節して再生
        //移動速度が大きい砂の数が多ければそれだけ音量が大きくなる
        if (am.seVol > 0.0f)
            am.source[2].volume += ((float)VeryMoveSands_Cnt / (float)Sands_Max - 0.5f) * Move_Idx;

        //砂の速度の平均を計算してピッチを変更
        //0.7~1.3の変動までの変動は許容する
        //am.source[2].pitch += ((Sands_Speed_Avarage / Sands_Max) - 3.0f) * 0.1f;
    }
}
