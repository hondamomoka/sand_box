using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandSwitch : MonoBehaviour
{
    public PlayerInScales Player;
    public ScalesHelper Other_Switch;
    public Material[] Mats;
    public int cnt;
    public int cnt_max;
    public bool isActive;

    Renderer Switch_Renderer;

    // Start is called before the first frame update
    void Start()
    {
        //isActive = false;
        Switch_Renderer = GetComponent<Renderer>();
        cnt = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.isOutBucket == true && isActive == false)
        {
            isActive = true;
            Switch_Renderer.material = Mats[0];

            // layer: wall_through_player
            gameObject.layer = 14;
        }

        if (cnt >= cnt_max)
        {
            Other_Switch.Set_Active(Mats[1]);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("sand_normal") && isActive == true)
        {
            cnt++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("sand_normal") && isActive == true)
        {
            cnt--;
        }
    }
}
