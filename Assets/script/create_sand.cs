using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class create_sand : MonoBehaviour {

    public GameObject sand;
    GameObject[] obj_sand;

    // Use this for initialization
    void Start()
    {
        obj_sand = new GameObject[400];
        float count = -2.8f;
        float y = 0.0f;

        for (int i = 0; i < 400; i++)
        {
            obj_sand[i] = Instantiate(sand, new Vector3(count, y, -0.1f), Quaternion.identity);

            obj_sand[i].transform.parent = GameObject.Find("stage").transform;

            count += 0.1f;

            if (count > 2.8)
            {
                count = -2.8f;
                y += 0.1f;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {

      
    }
}
