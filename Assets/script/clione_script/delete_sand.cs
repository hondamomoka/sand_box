using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delete_sand : MonoBehaviour
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
        if (on)
        {
            transform.Translate(0, 0, -1);
            on = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        
        
    }
}
