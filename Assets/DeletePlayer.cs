using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletePlayer : MonoBehaviour
{
    Rigidbody Player;

    // Start is called before the first frame update
    void Start()
    {
        Player = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        if (gameObject.transform.position.y >= 15.9f && Player.isKinematic == false)
        {
            Player.isKinematic = true;
        }
    }
}
