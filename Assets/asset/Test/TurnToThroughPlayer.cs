using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnToThroughPlayer : MonoBehaviour
{
    public Material Mat;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Set_Alpha()
    {
        // layer: wall_Through_player;
        gameObject.layer = 14;

        GetComponent<Renderer>().material = Mat;
    }
}
