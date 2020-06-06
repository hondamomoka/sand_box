using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSandsKyo : MonoBehaviour
{
    public  GameObject sands;           // 発生するオブジェクト
    public  int        line;            // 発生するオブジェクトの行数
    public  int        col;             // 発生するオブジェクトの列数
    public  float      size;
    public  float      sands_mass;
    public  string     stage;
    public  Material   default_mat;
    public  Material[] other_mats;
    public  string     sands_tag;
    public  string     sands_layer;
    public  bool       isWithScales;
    public  bool       isWithBorderDestroy;
    public  bool       isWithWind;
    public  bool       isSandsDelete;
    public  ParticleSystem ps;
    public  float       Size_Change_Idx;
    public  int         Sands_Max;       // 発生するオブジェクトの総数
    public  int         Sands_Num;
    public  GameObject[] obj_sands;      // 生成されたオブジェクトを格納する行列

    Transform          sandscreater;    // 生成器のTransform情報

    private Rigidbody[] rb_sands;
    private int         MoveSands_Cnt;       //動いている砂の数を数える
    private int         VeryMoveSands_Cnt;   //特に動いている砂の数を数える
    private float       Sands_Speed;         //動いている砂の速度
    private float       Sands_Speed_Avarage; //動いている砂の速度の平均
    private Vector2[]   Sands_velocity;      //動いている砂の速度を一時格納していじるための変数

    //音を鳴らすために追加
    private GameObject audioManager;
    private Audio_Manager am;
    [SerializeField] private AudioClip audioClip;

    void Awake()
    {
        Sands_Max = line * col;
        Sands_Num = Sands_Max;

        obj_sands       = new GameObject[Sands_Max];
        rb_sands        = new Rigidbody[Sands_Max];
        Sands_velocity  = new Vector2[Sands_Max];

        sandscreater = GetComponent<Transform>();

        MoveSands_Cnt = 0;

        if (size == 0)
        {
            size = sands.transform.localScale.x;
        }

        for (int i = 0; i < Sands_Max; i++)
        {

            Vector3 pos = new Vector3(sandscreater.position.x - (col - 1) / 2 * size + (i % col) * size,
                                      sandscreater.position.y - size * i / col,
                                      sandscreater.position.z);
            obj_sands[i] = Instantiate(sands, pos, Quaternion.identity);
            obj_sands[i].transform.parent = GameObject.Find(stage).transform;
            obj_sands[i].transform.localScale = new Vector3(size, size, size);

            if (default_mat != null)
            {
                obj_sands[i].GetComponent<Renderer>().sharedMaterial = default_mat;
            }

            if (sands_tag != "sands")
            {
                obj_sands[i].tag = sands_tag;
            }

            if (sands_layer != "sands_normal")
            {
                obj_sands[i].layer = LayerMask.NameToLayer(sands_layer);
            }

            rb_sands[i] = obj_sands[i].GetComponent<Rigidbody>();

            if (rb_sands[i].constraints != RigidbodyConstraints.FreezePositionZ)
            {
                rb_sands[i].constraints = RigidbodyConstraints.FreezePositionZ;
            }

            if (sands_mass != 10.0f)
            {
                rb_sands[i].mass = sands_mass;
            }
        }

        if (isWithBorderDestroy == true)
        {
            for (int i = 0; i < obj_sands.Length; i++)
            {
                
                obj_sands[i].AddComponent<SandsWithBorderDestroy>();

                SandsWithBorderDestroy work = obj_sands[i].GetComponent<SandsWithBorderDestroy>();

                work.material = other_mats;

                work.ps = ps;

                work.Size_Change_Idx = Size_Change_Idx;
            }
        }

        if (isWithScales == true)
        {
            // 砂に天秤と相互作用するためのスクリプトを追加
            for (int i = 0; i < obj_sands.Length; i++)
            {
                obj_sands[i].AddComponent<SandInScales>();
            }
        }
        
        if (isWithWind == true)
        {
            for (int i = 0; i < obj_sands.Length; i++)
            {
                obj_sands[i].AddComponent<SandWithWind>();

                obj_sands[i].GetComponent<SandWithWind>().material = other_mats;
            }
        }
        //音を鳴らすために追加
        audioManager = GameObject.Find("GameManager");
        am = audioManager.GetComponent<Audio_Manager>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //砂の音生成
        if(am.seVol > 0.0f)
            am.PlaySandSE(audioClip);
    }

    // Update is called once per frame
    void Update()
    {
        //現在の砂の数を取得
        //砂はおそらく自由落下で13ほど
        Sands_Num     = 0;
        MoveSands_Cnt = 0;
        VeryMoveSands_Cnt = 0;
        Sands_Speed = 0;
        Sands_Speed_Avarage = 0;

        //砂の音の設定初期化
        am.source[2].volume = am.seVol;
        for (int i = 0; i < Sands_Max; i++)
        {
            if (obj_sands[i] != null)
            {
                //生きてる砂をカウントする
                Sands_Num++;

                //生きてる砂の速度をそれ用の変数に格納する
                Sands_velocity[i].x = rb_sands[i].velocity.x;
                Sands_velocity[i].y = rb_sands[i].velocity.y;

                //使いやすくするために+-を調整する
                if (Sands_velocity[i].x < 0)
                    Sands_velocity[i].x *= -1.0f;
                if (Sands_velocity[i].y < 0)
                    Sands_velocity[i].y *= -1.0f;

                //砂の速度が一定以上であったら動いてると判定する
                if (rb_sands[i].velocity.x < -0.5f || rb_sands[i].velocity.y < -0.5f)
                    MoveSands_Cnt++;

                //砂の速度を変数に格納
                Sands_Speed = (float)System.Math.Sqrt(System.Math.Pow(Sands_velocity[i].x,2) + System.Math.Pow(Sands_velocity[i].y, 2));

                Sands_Speed_Avarage += Sands_Speed;

                //砂の速さは2.3以上で早いと判断
                if (Sands_Speed > 2.3f)
                {
                    VeryMoveSands_Cnt++;
                }
            }
        }

        //SEの音量が0じゃなければ音量調節して再生
        //移動速度が大きい砂の数が多ければそれだけ音量が大きくなる
        if (am.seVol > 0.0f)
            am.source[2].volume += ((float)VeryMoveSands_Cnt / (float)Sands_Max - 0.5f) * 0.6f;

        //砂の速度の平均を計算してピッチを変更
        //0.7~1.3の変動までの変動は許容する
        //am.source[2].pitch += ((Sands_Speed_Avarage / Sands_Max) - 3.0f) * 0.1f;

        // 砂の一斉削除
        if (isSandsDelete == true)
        {
            for (int i = 0; i < Sands_Max; i++)
            {
                if (obj_sands[i] != null)
                {
                    Instantiate(ps, obj_sands[i].transform.position, Quaternion.identity);
                    Destroy(obj_sands[i]);
                }
            }
        }
    }
}