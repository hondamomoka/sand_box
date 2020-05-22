using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SelectController : MonoBehaviour
{
    public enum StageSelect
    {
        none,
        stage_1,
        stage_2,
        stage_3,
        stage_4,
        stage_5,
        stage_6,
        stage_7,
        stage_8,
        stage_9,
        stage_10,
        stage_11,
        stage_12,
        stage_13,
        stage_14,
        stage_15,
        stage_16,
        stage_17,
        stage_18,
        stage_19,
        stage_20,
        MAX
    }

    public StageSelect CursorPos;

    // Start is called before the first frame update
    void Start()
    {
        CursorPos = StageSelect.stage_1;
    }
       

    // Update is called once per frame
    void Update()
    {
        // 左に移動
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (CursorPos != StageSelect.stage_1)
            {
                CursorPos -= 1;
            }
 
        }
        // 右に移動
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if(CursorPos != StageSelect.stage_20){
                CursorPos += 1;
            }
        }
        // 上に移動
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (CursorPos != StageSelect.stage_1 && CursorPos != StageSelect.stage_2 && CursorPos != StageSelect.stage_5 && CursorPos != StageSelect.stage_10 && CursorPos != StageSelect.stage_11 && CursorPos != StageSelect.stage_12 && CursorPos != StageSelect.stage_13 && CursorPos != StageSelect.stage_18)
            {
                CursorPos -= 2;
            }
            else if( CursorPos != StageSelect.stage_1 && CursorPos != StageSelect.stage_2)
            {
                CursorPos -= 3;
            }
        }
        // 下に移動
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (CursorPos != StageSelect.stage_3 && CursorPos != StageSelect.stage_8 && CursorPos != StageSelect.stage_9 && CursorPos != StageSelect.stage_10 && CursorPos != StageSelect.stage_11 && CursorPos != StageSelect.stage_16 && CursorPos != StageSelect.stage_19 && CursorPos != StageSelect.stage_20)
            {
                CursorPos += 2;
            }
            else if (CursorPos != StageSelect.stage_19 && CursorPos != StageSelect.stage_20)
            {
                CursorPos += 3;
            }
        }


        switch (CursorPos)
        {
            case StageSelect.stage_1:
                this.gameObject.transform.position = new Vector3(-2.323f, 1.14f, 1.29f);
                break;

            case StageSelect.stage_2:
                this.gameObject.transform.position = new Vector3(-1.18f, 1.14f, 1.29f);
                break;

            case StageSelect.stage_3:
                this.gameObject.transform.position = new Vector3(-2.7f, 1.14f, 0.25f);
                break;

            case StageSelect.stage_4:
                this.gameObject.transform.position = new Vector3(-1.73f, 1.14f, 0.25f);
                break;

            case StageSelect.stage_5:
                this.gameObject.transform.position = new Vector3(-0.65f, 1.14f, 0.25f);
                break;

            case StageSelect.stage_6:
                this.gameObject.transform.position = new Vector3(-2.31f, 1.14f, -0.86f);
                break;

            case StageSelect.stage_7:
                this.gameObject.transform.position = new Vector3(-1.16f, 1.14f, -0.86f);
                break;

            case StageSelect.stage_8:
                this.gameObject.transform.position = new Vector3(-2.688f, 1.14f, -1.9f);
                break;

            case StageSelect.stage_9:
                this.gameObject.transform.position = new Vector3(-1.686f, 1.14f, -1.9f);
                break;

            case StageSelect.stage_10:
                this.gameObject.transform.position = new Vector3(-0.7f, 1.14f, -1.9f);
                break;

            case StageSelect.stage_11:
                this.gameObject.transform.position = new Vector3(0.812f, 1.14f, 1.318f);
                break;

            case StageSelect.stage_12:
                this.gameObject.transform.position = new Vector3(1.798f, 1.14f, 1.318f);
                break;

            case StageSelect.stage_13:
                this.gameObject.transform.position = new Vector3(2.8f, 1.14f, 1.318f);
                break;

            case StageSelect.stage_14:
                this.gameObject.transform.position = new Vector3(1.272f, 1.14f, 0.278f);
                break;

            case StageSelect.stage_15:
                this.gameObject.transform.position = new Vector3(2.422f, 1.14f, 0.278f);
                break;

            case StageSelect.stage_16:
                this.gameObject.transform.position = new Vector3(0.762f, 1.14f, -0.831f);
                break;

            case StageSelect.stage_17:
                this.gameObject.transform.position = new Vector3(1.842f, 1.14f, -0.831f);
                break;

            case StageSelect.stage_18:
                this.gameObject.transform.position = new Vector3(2.812f, 1.14f, -0.831f);
                break;

            case StageSelect.stage_19:
                this.gameObject.transform.position = new Vector3(1.292f, 1.14f, -1.871f);
                break;

            case StageSelect.stage_20:
                this.gameObject.transform.position = new Vector3(2.37f, 1.14f, -1.871f);
                break;
        }
        
    }
}
