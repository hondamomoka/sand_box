using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateSandsKyo : MonoBehaviour
{
    public  GameObject sands;   // 発生するオブジェクト
    public  int        line;    // 発生するオブジェクトの行数
    public  int        col;     // 発生するオブジェクトの列数
    public  float      size;
    public  string     stage;
    public  Material   mat;
    public  string     sands_layer;
    public bool isWithScales;
    //public  int        num;     // 発生するオブジェクトの総数

    public GameObject[] obj_sands;    // 生成されたオブジェクトを格納する行列
    Transform    sandscreater; // 生成器のTransform情報

    void Awake()
    {
        int num = line * col;

        obj_sands = new GameObject[num];
        sandscreater = GetComponent<Transform>();

        if (size == 0)
        {
            size = sands.transform.localScale.x;
        }

        for (int i = 0; i < num; i++)
        {
            Vector3 pos = new Vector3(sandscreater.position.x - (col - 1) / 2 * size + (i % col) * size,
                                      sandscreater.position.y - size * i / col,
                                      sandscreater.position.z);
            obj_sands[i] = Instantiate(sands, pos, Quaternion.identity);
            obj_sands[i].transform.parent = GameObject.Find(stage).transform;
            obj_sands[i].transform.localScale = new Vector3(size, size, size);

            if (mat != null)
            {
                obj_sands[i].GetComponent<Renderer>().sharedMaterial = mat;
            }

            if (sands_layer != "sands_normal")
            {
                obj_sands[i].layer = LayerMask.NameToLayer(sands_layer);
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

        //if (SceneManager.GetActiveScene().name == "stage_snails")
        //{
        //    GameObject.Find("Scales").SendMessage("Get_Sands", obj_sands);
        //}
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}