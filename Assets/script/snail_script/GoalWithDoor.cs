using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalWithDoor : MonoBehaviour
{
    public GameObject Door;
    public Material mat;

    Renderer Goal_Renderer;
    Renderer Door_Renderer;

    // Start is called before the first frame update
    void Start()
    {
        Goal_Renderer = GetComponent<Renderer>();
        Door_Renderer = Door.GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Door_Renderer.material == mat && Goal_Renderer.material != mat)
        {
            Goal_Renderer.material = mat;

            // layer: wall_through_player
            gameObject.layer = 14;
        }
    }
}
