using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rain : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }


    void Move()
    {
        Transform tra = this.transform;

        //削除処理
        if (tra.position.y<-5)
        {
            Destroy(this.gameObject);
        }
    }


    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("wall"))
        {
            Destroy(this.gameObject);
        }
    }
    
}
