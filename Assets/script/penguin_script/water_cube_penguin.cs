using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water_cube_penguin : MonoBehaviour
{
    public Material[] material;
    bool on;

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
        if(!on)
        {
            if (other.gameObject.CompareTag("sand_normal") &&other.gameObject.layer==8)
            {
                Destroy(other);
                this.GetComponent<Renderer>().material = material[0];
                on = true;
                this.gameObject.GetComponent<Collider>().isTrigger = false;
            }
        }
       
    }
}
