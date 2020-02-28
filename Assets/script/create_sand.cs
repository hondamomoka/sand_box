using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class create_sand : MonoBehaviour {

    public GameObject sand;
    GameObject[] obj_sand;
    public float x;
    public float y;
    // Use this for initialization
    void Start()
    {
        obj_sand = new GameObject[400];
        float count = -2.8f;
       // float y = 0.0f;

        Transform mytra = this.transform;

        Vector3 size = mytra.localScale;
        Vector3 pos = mytra.position;

        x= pos.x - (size.x / 2);
        y= pos.y - (size.y / 2);

        for (int j = 0; j < (int)size.y * 10; j++)
        {
            for (int i = 0; i < (int)size.x * 10; i++)
            {
                obj_sand[i] = Instantiate(sand, new Vector3(x + ((float)i / 10), y + ((float)j / 10), -0.1f), Quaternion.identity);

                obj_sand[i].transform.parent = GameObject.Find("stage_2").transform;

                //count += 0.1f;

                //if (count > 2.8)
                //{
                //    count = -2.8f;
                //    y += 0.1f;
                //}
            }
        }
    }
	
	// Update is called once per frame
	void Update () {

      
    }
}
