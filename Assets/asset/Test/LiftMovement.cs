using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftMovement : MonoBehaviour
{
    public GameObject Player;
    //public GameObject Player_Force;
    public GameObject Switch;
    public float speed;
    public float force;
    public float move_y;

    float origin_pos_y;

    public enum LIFT_STATE
    {
        STATE_NONE,
        STATE_STOP,
        STATE_MOVE_UP,
        STATE_MOVE_DOWN,
        STATE_STAY_IN_UP,
        STATE_STAY_IN_DOWN,
    };

    public LIFT_STATE Lift_State;

    // Start is called before the first frame update
    void Start()
    {
        origin_pos_y = transform.localPosition.y;
        Lift_State = LIFT_STATE.STATE_STAY_IN_UP;
    }

    // Update is called once per frame
    void Update()
    {
        switch(Lift_State)
        {
            case LIFT_STATE.STATE_MOVE_UP:
                State_Move_Up();
                break;
            case LIFT_STATE.STATE_MOVE_DOWN:
                State_Move_Down();
                break;
            case LIFT_STATE.STATE_STAY_IN_UP:
                State_Stay_In_Up();
                break;
            case LIFT_STATE.STATE_STAY_IN_DOWN:
                State_Stay_In_Down();
                break;
            default:
                break;
        }
    }

    void State_Move_Up()
    {
        transform.localPosition = new Vector3(
            transform.localPosition.x,
            transform.localPosition.y + speed,
            transform.localPosition.z);

        if (transform.localPosition.y >= origin_pos_y)
        {
            transform.localPosition = new Vector3(
                transform.localPosition.x,
                origin_pos_y,
                transform.localPosition.z);
            Lift_State = LIFT_STATE.STATE_STAY_IN_UP;
            //Player.GetComponent<FreezeLocalTransform>().LocalPosX = true;
        }
    }

    void State_Move_Down()
    {
        transform.localPosition = new Vector3(
            transform.localPosition.x,
            transform.localPosition.y - speed,
            transform.localPosition.z);

        if (transform.localPosition.y < origin_pos_y - move_y)
        {
            transform.localPosition = new Vector3(
                transform.localPosition.x,
                origin_pos_y - move_y,
                transform.localPosition.z);
            Lift_State = LIFT_STATE.STATE_STAY_IN_DOWN;
        }
    }

    void State_Stay_In_Up()
    {
        if (Player.transform.parent == transform)
        {
            Vector3 pos = Player.transform.localPosition;
            pos.y -= 0.1f;

            pos = gameObject.transform.TransformPoint(pos);

            Player.GetComponent<Rigidbody>().isKinematic = false;
            Player.GetComponent<Rigidbody>().AddForceAtPosition(
                (Player.transform.position - pos).normalized * force,
                Player.transform.position,
                ForceMode.Impulse);

            Player.transform.parent = null;
        }
    }

    void State_Stay_In_Down()
    {
        if (Player.transform.parent != transform)
        {
            Switch.SetActive(true);
        }
    }
}
