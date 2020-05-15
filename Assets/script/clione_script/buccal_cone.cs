using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buccal_cone : MonoBehaviour
{
    public int count;
    int count_max;
    public Material[] material;
    public GameObject gorl;
    public hool_2 hool;
    bool on;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        count_max = 0;
        on = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(on==true)
        {
            if (count > 340)
            {
                Destroy(gorl);
                hool.on = true;
                on = false;
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("sand_normal"))
        {
            count++;
            other.GetComponent<Renderer>().material = material[1];
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("sand_normal"))
        {
            count--;
            other.GetComponent<Renderer>().material = material[0];
        }
    }
}
