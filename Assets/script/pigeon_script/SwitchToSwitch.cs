using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchToSwitch : MonoBehaviour
{
    public GameObject other_switch;
    public Material Mat;

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
        if(other.gameObject.CompareTag("player"))
        {
            other_switch.GetComponent<Collider>().isTrigger = true;
            other_switch.GetComponent<Renderer>().material = Mat;
        }
    }
}
