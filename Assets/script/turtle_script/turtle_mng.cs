using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turtle_mng : MonoBehaviour
{
    public switch_turtle switch1;
    public switch_turtle switch2;
    public GameObject cube;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(switch1.on&&switch2.on)
        {
            Destroy(cube);
        }
    }
}
