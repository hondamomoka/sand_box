using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallVisible : MonoBehaviour
{
    public Material[] mat;

    Renderer[] children;

    // Start is called before the first frame update
    void Start()
    {
        children = GetComponentsInChildren<Renderer>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Be_Visible()
    {
        for (int i = 0; i < children.Length; i++)
        {
            children[i].sharedMaterial = mat[1];
        }
    }

    void Be_Invisible()
    {
        for (int i = 0; i < children.Length; i++)
        {
            children[i].sharedMaterial = mat[0];
        }
    }
}
