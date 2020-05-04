using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rot_right : MonoBehaviour
{
    // Start is called before the first frame update

    public shell_rotater shell;
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
            shell.rot_right = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("player"))
        {
            shell.rot_right = false;
        }
    }
}
