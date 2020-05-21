using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scales : MonoBehaviour
{
    public GameObject scales;
    public GameObject[] joins;

    Vector3[] joins_pos;

    // Start is called before the first frame update
    void Start()
    {
        joins_pos = new Vector3[joins.Length];

        for(int i = 0; i < joins.Length; i++)
        {
            joins_pos[i] = joins[i].transform.localPosition;
            Debug.Log("joins_pos[" + i.ToString() + "]" + "x:" + joins_pos[i].x.ToString() + "y:" + joins_pos[i].y.ToString() + "z:" + joins_pos[i].z.ToString());
        }
    }

    // Update is called once per frame
    void Update()
    {
        //if(joins[0].GetComponent<Rigidbody>().mass == joins[1].GetComponent<Rigidbody>().mass)
        //{
        //    transform.localEulerAngles= new Vector3(0, 0, 0);
        //}
        //if (transform.localEulerAngles.z >= 60.0f && transform.localEulerAngles.z < 180.0f)
        //{
        //    transform.localEulerAngles = new Vector3(0, 0, 60.0f);
        //}

        //if (transform.localEulerAngles.z <= 300.0f && transform.localEulerAngles.z > 180.0f)
        //{
        //    transform.localEulerAngles = new Vector3(0, 0, 300.0f);
        //}

        for (int i = 0; i < joins.Length; i++)
        {
            joins[i].transform.eulerAngles = new Vector3(0, 0, 0);
            joins[i].transform.localPosition = joins_pos[i];
        }
    }
}
