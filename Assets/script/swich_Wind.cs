using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swich_Wind : MonoBehaviour
{
    public wind_2 wind;
    bool on = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (on == false)
        {
            if (other.gameObject.CompareTag("player"))
            {
                on = true;

                wind.start();
              
                Destroy(this.gameObject);
            }
        }
    }
}
