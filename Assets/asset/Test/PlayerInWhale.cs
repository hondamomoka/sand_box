using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInWhale : MonoBehaviour
{
    public bool isOnLift;

    // Start is called before the first frame update
    void Start()
    {
        isOnLift = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.name == "LiftBoard")
        {
            isOnLift = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.name == "LiftBoard")
        {
            isOnLift = false;
        }
    }
}
