using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turtle_mng : MonoBehaviour
{
    public switch_turtle switch1;
    public switch_turtle switch2;
    public GameObject cube;
    public Material[] material;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(switch1.on&&switch2.on)
        {
            cube.GetComponent<Renderer>().material = material[0];
            cube.layer = 14;
            switch1.fin = true;
            switch2.fin = true;
        }
    }
}
