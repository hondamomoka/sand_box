using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class clear_coin : MonoBehaviour
{
    bool down;
    bool next;
    bool slow;
   public float add;
    float add_pos;
    public ParticleSystem ps;
    bool effect;

    // Start is called before the first frame update
    void Start()
    {

        add = 100.0f;
        add_pos = -0.5f;
        down = true;
        slow = false;
        next = false;
        effect = false;
        transform.rotation = Quaternion.Euler(0, 0, 90.0f);
 
    }

    // Update is called once per frame
    void Update()
    {
        if(down)
        {
            add_pos += 0.01f * Time.deltaTime;
            add -= 5.0f * Time.deltaTime;

            if (add_pos>-0.005f)
            {
                add_pos = -0.005f;
            }
            
            transform.Rotate(add * Time.deltaTime,0, 0.0f);
            transform.Translate(add_pos * Time.deltaTime, 0, 0);

            if(transform.position.y<=0.0f)
            {
                down = false;
                slow = true;
               // next = true;
               
            }
        }

        if(slow)
        {
            add -= 15.0f * Time.deltaTime;

            if(add<25)
            {
                Debug.Log("最低値");
                add = 25;
            }

            transform.Rotate(add * Time.deltaTime, 0, 0.0f);

            if (transform.rotation.y>0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 90.0f);
                slow = false;
                next = true;

            }
        }

        if(next)
        {
            if(!effect)
            {
                Instantiate(ps, new Vector3(this.transform.position.x, transform.position.y, transform.position.z + 1), Quaternion.Euler(-90,0,0));
                effect = true;
            }
           

            if (Input.GetKey(KeyCode.Z)||Input.GetKey("joystick button 0")|| Input.GetKey("joystick button 1"))
            {
                SceneManager.LoadScene("Selects");
            }
        }

       
    }
}
