using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalesHelper : MonoBehaviour
{
    public GameObject Scales;
    public GameObject Bucket_Board;
    public GameObject SandCreater;
    public GameObject[] obj_sands;
    public GameObject Sands_Trigger;

    ScalesBehaviour Scales_Script;
    Collider Bucket_Board_Collider;

    bool isHelper;

    // Start is called before the first frame update
    void Start()
    {
        Scales_Script = Scales.GetComponent<ScalesBehaviour>();

        Bucket_Board_Collider = Bucket_Board.GetComponent<Collider>();

        // 砂の取得
        obj_sands = SandCreater.GetComponent<CreateSandsKyo>().obj_sands;

        for (int i = 0; i < obj_sands.Length; i++)
        {
            //obj_sands_Collier[i] = obj_sands[i].GetComponent<Collider>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isHelper == true && Scales_Script.Handle_State != ScalesBehaviour.HANDLE_STATE.STATE_RETURN_BALANCE_FROM_HELPER)
        {
            Bucket_Board_Collider.isTrigger = false;
            isHelper = false;
            Sands_Trigger.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("player") && Scales_Script.weights[0] > 50)
        {
            Scales_Script.Handle_State = ScalesBehaviour.HANDLE_STATE.STATE_RETURN_BALANCE_FROM_HELPER;
            Bucket_Board_Collider.isTrigger = true;
            isHelper = true;
            Scales_Script.weights[0] = 50;
            Sands_Trigger.SetActive(true);
        }
    }
}
