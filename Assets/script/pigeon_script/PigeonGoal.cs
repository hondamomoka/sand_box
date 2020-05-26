using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PigeonGoal : MonoBehaviour
{
    public GameObject Door;
    public Material Mat;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Door == null)
        {
            GetComponent<Renderer>().material = Mat;

            // layer: wall_through_player
            gameObject.layer = 14;
        }
    }
}
