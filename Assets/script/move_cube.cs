using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move_cube : MonoBehaviour
{
    float Add_move = 0.01f;
    public bool move = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(move==true)
        {
            this.transform.Translate(new Vector3(0, Add_move, 0), Space.Self);
        }
       
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("distination"))
        {
            Add_move *= -1.0f;
            move = false;
        }
        else if(other.gameObject.CompareTag("move_cube"))
        {
            move = false;
        }
    }

   
}



