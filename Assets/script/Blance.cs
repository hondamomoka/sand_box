using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blance : MonoBehaviour
{
    
    int stay_count = 0;  //回転までのカウント
    bool tf = false;            //回転on off
    float rot_count = 0;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //回転処理

        Transform tra = this.transform;
        Vector3 Angle = tra.eulerAngles;
       

        if(tf==true)
        {
            Angle.z += 1.0f;
            rot_count += 1.0f;

             if (rot_count>=45.0f)
            {
                rot_count = 0.0f;
               
                tf = false;
                stay_count = 0;
            }

            tra.eulerAngles = Angle;
        }

        
    }

    

       

       

    void OnCollisionEnter(Collision collision)
    {

        if (!tf)
        {
            if (collision.gameObject.CompareTag("sand"))
            {
                stay_count += 1;

                if (stay_count > 30)
                {
                    tf = true;
                }
            }
        }
    }
}
