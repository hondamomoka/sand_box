using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bucket : MonoBehaviour
{
    Vector3 bucket_pos;

    // Start is called before the first frame update
    void Start()
    {
        bucket_pos = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = bucket_pos;
    }
}
