using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandWithWind : MonoBehaviour
{
    public Material[] material;

    Vector3 force;
    Renderer Sand_Renderer;
    Rigidbody Sand_Rb;

    // Start is called before the first frame update
    void Start()
    {
        force = new Vector3(0.0f, 30.0f, 0.0f);
        Sand_Renderer = GetComponent<Renderer>();
        Sand_Rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("wind"))
        {
            //レイヤーをsand_floatに変える
            gameObject.layer = 9;
            Sand_Renderer.material = material[1];
            Sand_Rb.AddForce(force);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("wind"))
        {
            // layer: sand_normal
            gameObject.layer = 8;
            Sand_Renderer.material = material[0];
        }
    }
}
