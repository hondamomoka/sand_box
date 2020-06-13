using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDestroy : MonoBehaviour
{
    public ParticleSystem ps1;

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
        if(other.gameObject.name == "KillCoin")
        {
            Instantiate(ps1, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
