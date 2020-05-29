using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandCountTestZone : MonoBehaviour
{
    public int cnt;

    // Start is called before the first frame update
    void Start()
    {
        cnt = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("sand_normal") || other.gameObject.CompareTag("sands"))
        {
            cnt++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("sand_normal") || other.gameObject.CompareTag("sands"))
        {
            cnt--;
        }
    }
}
