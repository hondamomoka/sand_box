﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandsChangeParent : MonoBehaviour
{
    public GameObject Parent;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("sands") &&
            other.transform.parent != Parent.transform)
        {
            other.transform.parent = Parent.transform;
        }
    }
}
