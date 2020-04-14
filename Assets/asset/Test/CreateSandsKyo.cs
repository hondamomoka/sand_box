using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateSandsKyo : MonoBehaviour
{
    public  GameObject sands;   // 発生するオブジェクト
    public  int        line;    // 発生するオブジェクトの行数
    public  int        col;     // 発生するオブジェクトの列数
    public  string     stage;
    //public  int        num;     // 発生するオブジェクトの総数

    GameObject[] obj_sands;    // 生成されたオブジェクトを格納する行列
    Transform    sandscreater; // 生成器のTransform情報

    // Start is called before the first frame update
    void Start()
    {
        int num = line * col;

        obj_sands = new GameObject[num];
        sandscreater = GetComponent<Transform>();

        for (int i = 0; i < num; i++)
        {
            Vector3 pos = new Vector3(sandscreater.position.x - (col - 1) / 2 * sands.transform.localScale.x + (i % col) * sands.transform.localScale.x,
                                      sandscreater.position.y - sands.transform.localScale.y * i / col,
                                      //-Random.Range(sandscreater.position.z + sands.transform.localScale.z / 2, 1 - sands.transform.localScale.z / 2));
                                      -1.5f);
            obj_sands[i] = Instantiate(sands, pos, Quaternion.identity);
            obj_sands[i].transform.parent = GameObject.Find(stage).transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}