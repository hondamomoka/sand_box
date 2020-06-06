using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    GameObject cursor;
    private GameObject openbook;
    private float cursor_x;//進行先カメラ位置
    private float cursor_z;
    private float nowcursor_x;//進行中カメラ位置
    private float nowcursor_y;
    private float nowcursor_z;
    private float angle_x;//カメラ角度
    private float nowangle_x;
    private bool movecursor;
    public float CameraPos_y;
    public float MoveSpeed;
    Vector3 commonpos;
    Vector3 commonangle;
    Vector3 commoncursor;


    // Start is called before the first frame update
    void Start()
    {
        commonpos = this.transform.position;
        commonangle = this.transform.eulerAngles;
        angle_x = 90.0f;
        nowangle_x = commonangle.x;
        nowcursor_x = commonpos.x;
        nowcursor_y = commonpos.y;
        nowcursor_z = commonpos.z;
        movecursor = false;
        openbook = GameObject.Find("Coin");

    }

    // Update is called once per frame
    void Update()
    {
        cursor = GameObject.Find("SelectCursor");
        MoveCursor();
        if (movecursor == true)
        {
            cursor_x = cursor.transform.position.x;
            cursor_z = cursor.transform.position.z;
        }

        if (openbook.GetComponent<CoinUp>().EndCoinUp() == true)
        {
            if (Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.Joystick1Button3))
            {
                MagnifyPos();
                MagnifyAng();
            }
            else
            {
                ReducingPos();
                ReducingAng();
            }
        }
    }

    //拡大
    void MagnifyPos()
    {
        if (nowcursor_x > cursor_x)
        {
            nowcursor_x -= (nowcursor_x - cursor_x) / 100 * MoveSpeed;
        }
        if (nowcursor_x < cursor_x)
        {
            nowcursor_x += (cursor_x - nowcursor_x) / 100 * MoveSpeed;
        }
        if (nowcursor_y >= CameraPos_y)
        {
            nowcursor_y -= (nowcursor_y - CameraPos_y) / 100 * MoveSpeed;
        }
        if (nowcursor_z < cursor_z)
        {
            nowcursor_z += (cursor_z - nowcursor_z) / 100 * MoveSpeed;
        }
        if (nowcursor_z > cursor_z)
        {
            nowcursor_z -= (nowcursor_z - cursor_z) / 100 * MoveSpeed;
        }

        this.transform.position = new Vector3(nowcursor_x, nowcursor_y, nowcursor_z);
    }
    void MagnifyAng()
    {
        if (nowangle_x <= angle_x)
        {
            nowangle_x += (angle_x - commonangle.x) / 100 * MoveSpeed;
        }
        this.transform.eulerAngles = new Vector3(nowangle_x, 0.0f, 0.0f);

    }

    //縮小
    void ReducingPos()
    {
        if (nowcursor_x > commonpos.x)
        {
            nowcursor_x -= (nowcursor_x - commonpos.x) / 100 * MoveSpeed;
        }
        if (nowcursor_x < commonpos.x)
        {
            nowcursor_x += (commonpos.x - nowcursor_x) / 100 * MoveSpeed;
        }
        if (nowcursor_y <= commonpos.y)
        {
            nowcursor_y += (commonpos.y - nowcursor_y) / 100 * MoveSpeed;
        }
        if (nowcursor_z > commonpos.z)
        {
            nowcursor_z -= (nowcursor_z - commonpos.z) / 100 * MoveSpeed;
        }


        this.transform.position = new Vector3(nowcursor_x, nowcursor_y, nowcursor_z);
    }
    void ReducingAng()
    {
        if (nowangle_x >= commonangle.x)
        {
            nowangle_x -= (angle_x - commonangle.x) / 100 * MoveSpeed;
        }
        this.transform.eulerAngles = new Vector3(nowangle_x, 0.0f, 0.0f);
    }

    //カーソル移動判定
    void MoveCursor()
    {
        if (cursor_x != cursor.transform.position.x || cursor_z != cursor.transform.position.z)
        {
            movecursor = true;
        }
        else
        {
            movecursor = false;
        }
    }
}
