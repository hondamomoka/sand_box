using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class clear_coin : MonoBehaviour
{
    bool down;
    bool next;



    // Start is called before the first frame update
    void Start()
    {
     

        down = true;
        next = false;
        transform.rotation = Quaternion.Euler(0, 0, 90.0f);
 
    }

    // Update is called once per frame
    void Update()
    {
        if(down)
        {
            transform.Rotate(120.0f * Time.deltaTime,0, 0.0f);
            transform.Translate(-0.5f * Time.deltaTime, 0, 0);

            if(transform.position.y<=0.0f)
            {
                down = false;
                next = true;
                transform.rotation = Quaternion.Euler(0, 0, 90.0f);
            }
        }

        if(next)
        {
            if(Input.GetKey(KeyCode.Z)||Input.GetKey("joystick button 0")|| Input.GetKey("joystick button 1"))
            {
                SceneManager.LoadScene("Selects");
            }
        }
       
    }
}
