using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switch_cattle2 : MonoBehaviour
{
    public int count;
    public int max_count;
    public bool on;
    public Material[] material;
    public GameObject cube;

    // Start is called before the first frame update
    void Start()
    {
        Transform mytra = this.transform;

        Vector3 size = mytra.localScale;

        max_count = (int)(size.x * size.y * 100);
        on = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!on)
        {
            if (count > max_count)
            {
                on = true;
                cube.GetComponent<Renderer>().material = material[1];
                cube.layer = 14;
                this.GetComponent<Renderer>().material = material[0];
            }
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!on)
        {
            if (other.gameObject.CompareTag("sand_normal"))
            {
                count++;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!on)
        {
            if (other.gameObject.CompareTag("sand_normal"))
            {
                count--;

                if(count<0)
                {
                    count = 0;
                }
            }
        }
    }
}
