using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchBehaviour : MonoBehaviour
{
    public int          frame;
    public Material[]   mat;
    public GameObject[] other_gimmick;
    public GameObject   obj_name;
    public string       obj_layer;
    public string       action;
    public bool isShining;

    private int cnt;
    // Start is called before the first frame update
    void Start()
    {
        cnt = 0;
    }

    // Update is called once per frame
    void Update()
    {
        cnt++;

        if(cnt % frame == 0)
        {
            gameObject.GetComponent<Renderer>().sharedMaterial = mat[cnt / frame % mat.Length];
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("player"))
        {
            gameObject.SetActive(false);

            if(other_gimmick != null)
            {
                for(int i = 0; i < other_gimmick.Length; i++)
                {
                    other_gimmick[i].SetActive(true);
                }
            }

            if (action == "Set")
            {
                obj_name.SendMessage("Set_Material", mat[mat.Length - 1]);
                obj_name.SendMessage("Set_Layer", obj_layer);
            }
            else if (action == "MoveUp")
            {
                GameObject player = GameObject.Find("Player");
                player.transform.parent = GameObject.Find("Lift").transform;
                obj_name.SendMessage("Set_Speed", 0.1f);
                obj_name.SendMessage("Set_DirectionY", 1);
                obj_name.SendMessage("MoveY");
            }
            else if (action == "MoveDown")
            {
                obj_name.SendMessage("Set_Speed", 0.01f);
                obj_name.SendMessage("Set_DirectionY", -1);
                obj_name.SendMessage("MoveY");
            }
            
            //SendMessage(action);
        }
    }

    void Set()
    {
        obj_name.SendMessage("Set_Material", mat[mat.Length - 1]);
        obj_name.SendMessage("Set_Layer", obj_layer);
    }

    void Move()
    {

    }
}
