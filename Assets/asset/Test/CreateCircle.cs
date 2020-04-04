using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCircle : MonoBehaviour
{
    public  float a;
    public  float b;
    public  int   changeAngle; // 回転角度

    private float angle;

    GameObject[] obj_parts;

    // Start is called before the first frame update
    void Start()
    {
        int num = 360 / changeAngle;
        obj_parts = new GameObject[num];

        angle = 0;

        Vector3 center = GetComponent<Transform>().position;

        num = 360 / changeAngle;

        for(int i = 0; i < num; i++)
        {
            float radian = angle / 180 * Mathf.PI;
            float posx = center.x + a * Mathf.Cos(radian);
            float posy = center.y + b * Mathf.Sin(radian);
            angle += changeAngle;

            obj_parts[i] = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            obj_parts[i].transform.parent = GameObject.Find("Circle").transform;
            obj_parts[i].transform.position = new Vector3(posx, posy, center.z);
            obj_parts[i].transform.Rotate(90, 0, 0, Space.World);
            obj_parts[i].transform.localScale = new Vector3(1.0f, 0.5f, 1.0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
