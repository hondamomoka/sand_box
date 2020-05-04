using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rot_left : MonoBehaviour
{
    public shell_rotater shell;

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
        if (other.gameObject.CompareTag("player"))
        {
            shell.rot_left = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            shell.rot_left = false;
        }
    }
}
