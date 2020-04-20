using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sand : MonoBehaviour {

    int freeze_time = 0;
    public int float_time = 0;
    public int type = 0;//0;normal 1:float

    public Material[] material;

    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        Rigidbody rb = this.GetComponent<Rigidbody>();
        Transform tra = this.transform;

        

        //normal_ver
        if (type == 0)
        {
            if (freeze_time > 0)
            {
                freeze_time--;
            }
            else
            {
                freeze_time = 0;


                rb.constraints = RigidbodyConstraints.None;
            }
        }
        //float_ver
        else
        {
            if (float_time > 0)
            {
                float_time--;

                Vector3 add = new Vector3(0.0f, 3.0f, 0.0f);

                rb.AddForce(add);

            }
            //float_timeが終わったら元のsandに戻す
            else
            {
                float_time = 0;
                type = 0;
                this.gameObject.layer = 8;
                this.GetComponent<Renderer>().material = material[type];
                rb.mass = 1.0f;
            }
        }
    

        //削除処理
        if (tra.position.y < -10)
        {
            Destroy(this.gameObject);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = this.GetComponent<Rigidbody>();

        if(type==0)
        {
            if (other.gameObject.CompareTag("rain"))
            {
                freeze_time = 100;
                rb.constraints = RigidbodyConstraints.FreezePosition;
            }
            //windに当たった場合ｘ秒間自身をsand_floatに変える
            else if (other.gameObject.CompareTag("wind"))
            {
                //レイヤーをsand_floatに変える
                this.gameObject.layer = 9;
                type = 1;
                float_time = 300;
                this.GetComponent<Renderer>().material = material[type];
                rb.mass = 0.2f;
               
            }
        }
        else
        {
            if (other.gameObject.CompareTag("rain"))
            {
                float_time = 300;
            }
        }
    }

    

    private void OnCollisionEnter(Collision other)
    {
       
        Rigidbody rb = this.GetComponent<Rigidbody>();

        if (other.gameObject.CompareTag("wall"))
        {
            freeze_time = 0;
            rb.constraints = RigidbodyConstraints.None;
        }
    }
}
