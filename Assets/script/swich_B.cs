using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swich_B : MonoBehaviour
{
    public GameObject wall;
    bool on = false;

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
        if (on == false)
        {
            if (other.gameObject.CompareTag("player"))
            {
                on = true;
                transform.position += new Vector3(0, 0, 0.2f);
                Destroy(wall);
            }
        }
    }

}
