using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetUpObjects : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SetScaleX(float scale_x)
    {
        float scale_y = GetComponent<Transform>().localScale.y;
        float scale_z = GetComponent<Transform>().localScale.z;
        GetComponent<Transform>().localScale = new Vector3(scale_x, scale_y, scale_z);
    }

    void SetScaleY(float scale_y)
    {
        float scale_x = GetComponent<Transform>().localScale.x;
        float scale_z = GetComponent<Transform>().localScale.z;
        GetComponent<Transform>().localScale = new Vector3(scale_x, scale_y, scale_z);
    }

    void SetScaleZ(float scale_z)
    {
        float scale_x = GetComponent<Transform>().localScale.x;
        float scale_y = GetComponent<Transform>().localScale.y;
        GetComponent<Transform>().localScale = new Vector3(scale_x, scale_y, scale_z);
    }

    void SetPosition(Vector3 pos)
    {
        GetComponent<Transform>().transform.Translate(pos, Space.Self);
    }

    void Set_Material(Material m)
    {
        gameObject.GetComponent<Renderer>().sharedMaterial = m;
    }

    //void Set_Layer(LayerMask lm)
    //{
    //    gameObject.layer = lm;
    //}

    void Set_Layer(string lm)
    {
        gameObject.layer = LayerMask.NameToLayer(lm);
    }

    //void Set_Layer(int lm)
    //{
    //    gameObject.layer = lm;
    //}
}
