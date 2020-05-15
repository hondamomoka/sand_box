using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gear_risu : MonoBehaviour
{
    public int count;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(count>20)
        {
            transform.Rotate(0, 0.0f, 1.0f);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("sand_normal"))
        {
            count++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("sand_normal"))
        {
            count--;
        }
    }

 
}
