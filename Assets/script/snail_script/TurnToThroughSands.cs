using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnToThroughSands : MonoBehaviour
{
    public Material mat;

    Renderer[] Snail_Alpha;

    // Start is called before the first frame update
    void Start()
    {
        Snail_Alpha = GetComponentsInChildren<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Set_Snail_Alpha()
    {
        for (int i = 0; i < Snail_Alpha.Length; i++)
        {
            Snail_Alpha[i].material = mat;

            // layer: wall_through_sands
            Snail_Alpha[i].gameObject.layer = 15;
        }
    }
}
