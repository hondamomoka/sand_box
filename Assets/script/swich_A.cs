using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swich_A : MonoBehaviour
{
    public GameObject wall;
    int count = 0;
    bool on = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(count>10)
        {
            on = true;
            count = 0;
            transform.position += new Vector3(0, 0, 0.2f);

            Destroy(wall);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (on == false)
        {
            if (other.gameObject.CompareTag("sand_normal")|| other.gameObject.CompareTag("sand_float"))
            {
                count++;
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (on == false)
        {
            if (other.gameObject.CompareTag("sand_normal") || other.gameObject.CompareTag("sand_float"))
            {
                count--;
            }
        }
    }

}
