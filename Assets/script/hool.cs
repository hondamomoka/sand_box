using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hool : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision other)     //当たった時の判定
    {
        if (other.gameObject.CompareTag("player"))
        {
            Destroy(this.gameObject);
        }
    }
}
