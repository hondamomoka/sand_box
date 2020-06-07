using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalesBehaviour : MonoBehaviour
{
    public GameObject Player;
    public GameObject SandCreater;
    public GameObject Handle;
    public GameObject[] StickJoin;
    public GameObject[] Stick;
    public GameObject[] Bucket;
    public GameObject Scales_Pos;
    public float[] weights;
    public int weights_index;
    public float rot_limit;
    public float return_rot_speed;
    public float deviation;
    public Vector3 handle_Angular_Velocity;
    public GameObject[] obj_sands;
    public bool isPlayerInBucket;
    public bool isWithPlayer;

    Transform Handle_Trs;
    Transform[] StickJoin_Trs;
    Transform[] Stick_Trs;

    Rigidbody Player_Rb;
    Rigidbody Handle_Rb;

    SandInScales[] obj_sands_Script;

    Vector3 Weights_World_Pos; // 天秤の両端に力を加える点

    public enum HANDLE_STATE
    {
        STATE_NONE,
        STATE_BALANCE,
        STATE_TURN_TO_LEFT,
        STATE_TURN_TO_RIGHT,
        STATE_STAY_IN_LEFT,
        STATE_STAY_IN_RIGHT,
        STATE_RETURN_BALANCE_FROM_LEFT,
        STATE_RETURN_BALANCE_FROM_RIGHT,
        STATE_RETURN_BALANCE_FROM_HELPER,
    };

    public HANDLE_STATE Handle_State;

    // Start is called before the first frame update
    void Start()
    {
        // HandleのTransformの取得
        Handle_Trs = Handle.GetComponent<Transform>();

        // StickJoinのTransformの取得
        StickJoin_Trs = new Transform[StickJoin.Length];

        for (int i = 0; i < StickJoin.Length; i++)
        {
            StickJoin_Trs[i] = StickJoin[i].GetComponent<Transform>();
        }

        // StickのTransformの取得
        Stick_Trs = new Transform[Stick.Length];

        for (int i = 0; i < Stick.Length; i++)
        {
            Stick_Trs[i] = Stick[i].GetComponent<Transform>();
        }

        // StickJoinの大きさ（Local）の初期化
        Vector3 ls = new Vector3(Handle_Trs.localScale.x, Handle_Trs.localScale.y, Handle_Trs.localScale.z);
        StickJoin_Trs[0].localScale = new Vector3(1 / ls.x, 1 / ls.y, 1 / ls.z);

        // StickJoinLeft・StickJoinRightの位置（Local）の初期化
        Vector3 lp = ls / 2;
        StickJoin_Trs[1].localPosition = new Vector3(-lp.x * 0.95f, -lp.y, lp.z - Stick_Trs[0].localScale.z / 2);
        StickJoin_Trs[2].localPosition = new Vector3(lp.x * 0.95f, -lp.y, lp.z - Stick_Trs[0].localScale.z / 2);

        // PlayerのRigidbodyの取得
        Player_Rb = Player.GetComponent<Rigidbody>();

        // HandleのRigidbodyの取得
        Handle_Rb = Handle.GetComponent<Rigidbody>();

        // Handle_Stateの初期化
        Handle_State = HANDLE_STATE.STATE_BALANCE;

        // 砂の取得
        obj_sands = SandCreater.GetComponent<CreateSandsKyo>().obj_sands;

        // 天秤にPlayerがいるかどうか
        isPlayerInBucket = false;

        // 天秤にPlayerがいたかどうか
        isWithPlayer = false;

        obj_sands_Script = new SandInScales[obj_sands.Length];

        for (int i = 0; i < obj_sands.Length; i++)
        {
            obj_sands_Script[i] = obj_sands[i].GetComponent<SandInScales>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        handle_Angular_Velocity = Handle_Rb.angularVelocity;

        // 天秤の位置更新
        if (Scales_Pos != null)
        {
            transform.position = Scales_Pos.transform.position;
        }

        int work_weight_idx = 0;

        for (int i = 0; i < obj_sands.Length; i++)
        {
            if (obj_sands[i] != null)
            {
                if (obj_sands_Script[i].Sand_State == SandInScales.SAND_STATE.SAND_STATE_STAY_IN_BUCKET)
                {
                    work_weight_idx++;
                }
            }
        }

        weights[0] = work_weight_idx * 10.0f + 50;

        // Handle_Stateのチェック・回転前
        Check_Handle_State_Before_Rotate();

        // Handle_StateによるHandleの回転
        Handld_State_Rot(Handle_State);

        // Handle_Stateのチェック・回転後（回転角度の制限）
        Check_Handle_State_After_Rotate(Handle_State, rot_limit, 90.0f);

        // StickJoinLeft・StickJoinRightの回転（Worldを0に）
        for (int i = 1; i < StickJoin.Length; i++)
        {
            StickJoin_Trs[i].eulerAngles = Vector3.zero;
        }

        // 天秤に何もない場合
        if (weights[0] == 50 && weights[1] == 50)
        {
            isWithPlayer = false;
        }
    }

    // Handle_Stateのチェック・回転前
    void Check_Handle_State_Before_Rotate()
    {
        // 左端が重い
        if (weights[0] > weights[1] &&
            Handle_State != HANDLE_STATE.STATE_STAY_IN_LEFT)
        {
            Handle_State = HANDLE_STATE.STATE_TURN_TO_LEFT;
        }

        // 右端が重い
        if (weights[0] < weights[1] &&
            Handle_State != HANDLE_STATE.STATE_STAY_IN_RIGHT)
        {
            Handle_State = HANDLE_STATE.STATE_TURN_TO_RIGHT;
        }

        // 両端の重さが同じ
        if (weights[0] == weights[1])
        {
            // 左端が沈んでいる
            if (Handle_State == HANDLE_STATE.STATE_STAY_IN_LEFT ||
                Handle_State == HANDLE_STATE.STATE_TURN_TO_LEFT)
            {
                Handle_State = HANDLE_STATE.STATE_RETURN_BALANCE_FROM_LEFT;
            }
            // 右端が沈んでいる
            else if (Handle_State == HANDLE_STATE.STATE_STAY_IN_RIGHT ||
                Handle_State == HANDLE_STATE.STATE_TURN_TO_RIGHT)
            {
                Handle_State = HANDLE_STATE.STATE_RETURN_BALANCE_FROM_RIGHT;
            }
        }
    }

    // Handle_StateによるHandleの回転
    void Handld_State_Rot(HANDLE_STATE hs)
    {
        switch (hs)
        {
            case HANDLE_STATE.STATE_TURN_TO_LEFT:
                // 力を加える点のワールド座標の取得
                Weights_World_Pos = LocalPos_To_World_Pos(Handle_Trs.localPosition, -0.45f, 0.5f, 0);
                // 力を加える
                Handle_Rb.AddForceAtPosition(Vector3.down * (weights[0] - weights[1]) / weights_index, Weights_World_Pos);
                break;
            case HANDLE_STATE.STATE_TURN_TO_RIGHT:
                // 力を加える点のワールド座標の取得
                Weights_World_Pos = LocalPos_To_World_Pos(Handle_Trs.localPosition, 0.45f, 0.5f, 0);
                // 力を加える
                Handle_Rb.AddForceAtPosition(Vector3.down * (weights[1] - weights[0]) / weights_index, Weights_World_Pos);
                break;
            case HANDLE_STATE.STATE_RETURN_BALANCE_FROM_LEFT:
            case HANDLE_STATE.STATE_RETURN_BALANCE_FROM_HELPER:
                Return_To_Balance(rot_limit, -return_rot_speed);
                break;
            case HANDLE_STATE.STATE_RETURN_BALANCE_FROM_RIGHT:
                Return_To_Balance(rot_limit, return_rot_speed);
                break;
            default:
                Handle_Rb.angularVelocity = Vector3.zero;
                break;
        }
    }

    // Handle_Stateのチェック・回転後（回転角度の制限）
    void Check_Handle_State_After_Rotate(HANDLE_STATE hs, float range_low, float range_high)
    {
        switch (hs)
        {
            case HANDLE_STATE.STATE_TURN_TO_LEFT:
                if (Handle_Trs.localEulerAngles.z > range_low + deviation && Handle_Trs.localEulerAngles.z < range_high)
                {
                    Handle_Trs.localEulerAngles = new Vector3(0, 0, range_low);

                    Handle_State = HANDLE_STATE.STATE_STAY_IN_LEFT;
                }
                break;
            case HANDLE_STATE.STATE_TURN_TO_RIGHT:
                if (Handle_Trs.localEulerAngles.z < 360.0f - range_low - deviation && Handle_Trs.localEulerAngles.z > 360.0f - range_high)
                {
                    Handle_Trs.localEulerAngles = new Vector3(0, 0, 360.0f - range_low);

                    Handle_State = HANDLE_STATE.STATE_STAY_IN_RIGHT;
                }
                break;
            case HANDLE_STATE.STATE_RETURN_BALANCE_FROM_LEFT:
            case HANDLE_STATE.STATE_RETURN_BALANCE_FROM_RIGHT:
            case HANDLE_STATE.STATE_RETURN_BALANCE_FROM_HELPER:
                if (Mathf.Cos(Handle_Trs.localEulerAngles.z * Mathf.Deg2Rad) >= Mathf.Cos(return_rot_speed * Mathf.Deg2Rad))
                {
                    Handle_Trs.localEulerAngles = Vector3.zero;
                    Handle_State = HANDLE_STATE.STATE_BALANCE;
                }
                break;
            default:
                break;
        }
    }

    // ローカル座標をワールド座標に更新
    Vector3 LocalPos_To_World_Pos(Vector3 pos_from_local, float lx, float ly, float lz)
    {
        Vector3 pos;

        pos = Handle_Trs.TransformPoint(
            new Vector3(
                pos_from_local.x + lx,
                pos_from_local.y + ly,
                pos_from_local.z + lz));

        return pos;
    }

    // 均衡状態に戻る
    void Return_To_Balance(float range, float rot_speed)
    {
        float z = Handle_Trs.localEulerAngles.z + rot_speed;
        Handle_Trs.localEulerAngles = new Vector3(Handle_Trs.localEulerAngles.x, Handle_Trs.localEulerAngles.y, z);
    }

    public void Reset_Sands(GameObject SC)
    {
        // 砂の取得
        obj_sands = SC.GetComponent<CreateSandsKyo>().obj_sands;
    }
}
