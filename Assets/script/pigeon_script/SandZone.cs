using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandZone : MonoBehaviour
{
    public GameObject Wall;
    public Material[] mats;
    public int cnt;
    public int cnt_max;

    Renderer Wall_Renderer;

    // Start is called before the first frame update
    void Start()
    {
        Wall_Renderer = Wall.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cnt >= cnt_max)
        {
            Wall_Renderer.material = mats[1];

            // layer: wall_through_player
            Wall.layer = 14;
        }
        else
        {
            Wall_Renderer.material = mats[0];

            // layer: default
            Wall.layer = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("sand_normal"))
        {
            cnt++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("sand_normal"))
        {
            cnt--;
        }
    }
}
