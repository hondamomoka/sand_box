using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_Create_Sands : MonoBehaviour
{
    public int num = 500;
    public int line = 4;
    public float gy = Physics.gravity.y;
    public GameObject player;
    public GameObject sands;
    Transform    sands_o;
    GameObject   obj_player;
    GameObject[] obj_sands;

    // Start is called before the first frame update
    void Start()
    {
        int col = num / line;
        sands_o = GetComponent<Transform>();
        obj_player = Instantiate(player, sands_o.transform.position, Quaternion.identity);
        obj_player.transform.parent = GameObject.Find("Stage").transform;

        obj_sands = new GameObject[num];

        for (int i = 0; i < num; i++)
        {
            Vector3 pos = new Vector3(sands_o.transform.position.x + sands.transform.localScale.x * (i % col) - 20.0f,
                                      sands_o.transform.position.y + sands.transform.localScale.y * i / col - 1.0f,
                                      sands_o.transform.position.z);
            obj_sands[i] = Instantiate(sands, pos, Quaternion.identity);
            obj_sands[i].transform.parent = GameObject.Find("Stage").transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.J))
        {
            gy -= 0.5f;
            Physics.gravity.Set(Physics.gravity.x, gy, Physics.gravity.z);
        }
        if (Input.GetKey(KeyCode.K))
        {
            gy += 0.5f;
            Physics.gravity.Set(Physics.gravity.x, gy, Physics.gravity.z);
        }
    }
}
