using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wind_penguin : MonoBehaviour
{
    public wind_2 wind;
    public wind_2 wind2;
    // Start is called before the first frame update
    void Start()
    {
        wind.start();
        wind2.start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
