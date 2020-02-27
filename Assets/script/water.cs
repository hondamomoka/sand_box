using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water : MonoBehaviour
{
    int life = 0;
    bool tacth = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(tacth==true)
        {
            life -= 1;

            if(life<0)
            {
                Destroy(this.gameObject);
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("wall"))
        {
            life = 15;
            tacth = true;
        }

        if (other.gameObject.CompareTag("sand"))
        {
            Destroy(this.gameObject);
        }
    }
}
