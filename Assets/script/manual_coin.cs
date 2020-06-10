using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manual_coin : MonoBehaviour
{
    public int animalnum;
    public Material[] material;
    // Start is called before the first frame update
    void Start()
    {
        int body = PlayerPrefs.GetInt("コイン" + animalnum, 0);

        if(body!=0)
        {
            body = body - 1;
            this.GetComponent<Renderer>().material = material[body];
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
