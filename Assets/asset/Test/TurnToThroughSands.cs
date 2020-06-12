using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnToThroughSands : MonoBehaviour
{
    public Material mat;

    Renderer[] Alpha;

    // Start is called before the first frame update
    void Start()
    {
        Alpha = GetComponentsInChildren<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Set_Alpha()
    {
        for (int i = 0; i < Alpha.Length; i++)
        {
            Alpha[i].material = mat;

            // layer: wall_through_sands
            Alpha[i].gameObject.layer = 15;
        }
    }
}
