using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switch_turtle : MonoBehaviour
{
    int count;
    int max_count;
    public bool on;
    public Material[] material;
    public bool fin;
    public ParticleSystem ps1;

    public GameObject Turtle_Leg;
    public Material[] Turtle_Leg_Mat;

    Renderer Turtle_Renderer;

    // Start is called before the first frame update
    void Start()
    {
        ps1.Stop();
        count = 0;
        on = false;
        fin = false;

        Transform mytra = this.transform;
        Vector3 size = mytra.localScale;
        max_count = (int)(size.x * size.y * 100);

        Turtle_Renderer = Turtle_Leg.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(10f * Time.deltaTime, 0, 20f * Time.deltaTime);

        if (!fin)
        {
            if (count >= max_count)
            {
                if(!on)
                {
                    on = true;
                    this.GetComponent<Renderer>().material = material[1];
                    ps1.Play();

                    Turtle_Renderer.material = Turtle_Leg_Mat[1];

                    // layer: wall_through_sands
                    Turtle_Leg.layer = 15;
                }
                
            }
            else
            {
                if(on)
                {
                    on = false;
                    this.GetComponent<Renderer>().material = material[0];
                    Turtle_Renderer.material = Turtle_Leg_Mat[0];

                    // layer: default
                    Turtle_Leg.layer = 0;
                }
               
            }
        }
        else
        {
            this.GetComponent<Renderer>().material = material[2];
            //ps1.Play();
        }
       
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("sand_normal"))
        {
            count++;
        }
    }

    private void OnTriggerExit(Collider other)
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
