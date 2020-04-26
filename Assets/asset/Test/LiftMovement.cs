using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftMovement : MonoBehaviour
{
    public float      move_y;
    public GameObject obj;

    private Vector3 origin_pos;
    private int     directionY;
    private float   lift_speed;
    private float   moved_y;
    private bool    moving;

    // Start is called before the first frame update
    void Start()
    {
        origin_pos = GetComponent<Transform>().transform.position;
        moved_y = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(directionY != 0 && moved_y < move_y)
        {
            MoveY();

            if (moved_y >= move_y)
            {
                if (directionY < 0)
                {
                    obj.SetActive(true);
                }
                else if(directionY > 0)
                {
                    GameObject player = GameObject.Find("Player");
                    player.transform.parent = GameObject.Find("Stage").transform;
                    //player.GetComponent<Rigidbody>().AddForce(new Vector3(0, 10000, 0), ForceMode.Force);
                }
                directionY = 0;
                moved_y = 0;
            }
        }
    }

    void Set_DirectionY(int dy)
    {
        directionY = dy;
    }

    void Set_Speed(float s)
    {
        lift_speed = s;
    }

    void MoveY()
    {
        float movement = lift_speed * directionY;
        GetComponent<Transform>().transform.Translate(new Vector3(0, movement, 0), Space.Self);
        moved_y +=  Mathf.Abs(movement);
    }
}
