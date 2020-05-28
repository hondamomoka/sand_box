using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clear : MonoBehaviour
{
    public Camera came;
    Vector3 camera_pos;
    public GameObject coin;
    public bool on;
    public bool set;
    public postp postp;
    // Start is called before the first frame update
    void Start()
    {
        camera_pos = came.transform.position;
        on = false;
        set = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(on)
        {
            Instantiate(coin, new Vector3(camera_pos.x, camera_pos.y + 3.0f, camera_pos.z + 1.5f), Quaternion.identity);
            on = false;
            set = true;
            postp.on = true;

        }
     
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!set)
        {
            if (other.gameObject.CompareTag("player"))
            {
                on = true;
            }
        }
        
    }
}
