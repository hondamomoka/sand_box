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

   

    private void OnCollisionEnter(Collision collision)
    {
        if (!on)
        {
            if (collision.gameObject.CompareTag("sand_normal"))
            {
                //Destroy(collision.gameObject);
                this.GetComponent<Renderer>().material = material[0];
                on = true;
                this.gameObject.GetComponent<Collider>().isTrigger = true;
                Destroy(this.gameObject);
            }
        }
    }
}
