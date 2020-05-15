using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hool_2 : MonoBehaviour
{
    public bool on;

    // Start is called before the first frame update
    void Start()
    {
        on = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(on)
        {
            if (other.gameObject.CompareTag("sand_normal"))
            {
                other.gameObject.layer = 19;
            }
        }

       
    }

    private void OnTriggerExit(Collider other)
    {
        if(on)
        {
            if (other.gameObject.CompareTag("sand_normal"))
            {
                other.gameObject.layer = 8;
            }
        }
      
    }
}
