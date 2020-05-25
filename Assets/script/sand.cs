using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sand : MonoBehaviour {

    int freeze_time = 0;
    public int float_time = 0;
    public int type = 0;//0;normal 1:float
    public Material[] material;
    Vector3 add;
    public bool move;
    public ParticleSystem ps;

    // Use this for initialization
    void Start () {
        add = new Vector3(0.0f, 30.0f, 0.0f);
        move = true;
        //ps.Stop();
    }
	
	// Update is called once per frame
	void Update () {

        if(move)
        {
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


                    this.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                }
            }

            //削除処理
            if (this.transform.position.y < -10)
            {
                Destroy(this.gameObject);
            }



        }
    }


    private void OnTriggerStay(Collider other)
    {
        if(move)
        {
            if (other.gameObject.CompareTag("wind"))
            {
                //レイヤーをsand_floatに変える
                this.gameObject.layer = 9;
                type = 1;
                this.GetComponent<Renderer>().material = material[type];
                this.GetComponent<Rigidbody>().AddForce(add);
            }

            if (other.gameObject.CompareTag("Finish"))
            {
                delete();
            }
        }
       
    }

    private void OnTriggerExit(Collider other)
    {
        if(move)
        {
            if (other.gameObject.CompareTag("wind"))
            {
                type = 0;
                this.gameObject.layer = 19;
                this.GetComponent<Renderer>().material = material[type];
            }
        }
        

    }

    public void delete()
    {
        Instantiate(ps, new Vector3(this.transform.position.x,transform.position.y,transform.position.z), Quaternion.identity);
        Destroy(this.gameObject);
    }
}
