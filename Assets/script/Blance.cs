using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blance : MonoBehaviour
{
    public float rot = 0.0f;
    public int stay_count = 0;
    bool tf = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (rot != 0.0f)
        //{
        //    if (rot < 0.0f)
        //    {
        //        transform.Rotate(0.0f, 0.0f, -rot);
        //        rot = 0.0f;
        //    }
        //    else
        //    {
        //        transform.Rotate(0.0f, 0.0f, rot);
        //        rot = 0.0f;
        //    }
        //}

        //回転処理

        //stay_count--;

        Transform tra = this.transform;
        Vector3 Angle = tra.eulerAngles;

        //if (stay_count < 0)
        //{
        //    stay_count = 0;

        //    if (Angle.z < 0)
        //    {
        //        rot -= 0.2f;

        //        if(rot<0.0f)
        //        {
        //            rot = 0.0f;
        //        }
        //    }
        //    else if (Angle.z > 0)
        //    {
        //        rot += 0.2f;

        //        if(rot>0.0f)
        //        {
        //            rot = 0.0f;
        //        }
        //    }
        //}

        if(stay_count>30)
        {
            stay_count = 0;
            Angle.z += 45.0f;
            tra.eulerAngles = Angle;
        }

        
    }

    

       

       

    void OnCollisionEnter(Collision collision)
    {
       
        Transform tra = this.transform;
        Vector3 pos = tra.position;

        if (collision.gameObject.CompareTag("sand"))
        {
            //if(collision.transform.position.x-pos.x<0.0f)
            //{
            //    rot += 0.01f;
            //}
            //else if (collision.transform.position.x - pos.x > 0.0f)
            //{
            //    rot -= 0.01f;
            //}

            stay_count += 1;
        }
    }
}
