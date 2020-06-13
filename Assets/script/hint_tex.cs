using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hint_tex : MonoBehaviour
{
    public Material[] material;
    int stage_type;

    // Start is called before the first frame update
    void Start()
    {
        stage_type = FindObjectOfType<hint>().Get_stagetype();

        Debug.Log(stage_type);

        this.GetComponent<Image>().material = material[stage_type];

        if (stage_type==0)
        {
            this.transform.localScale = new Vector3(11, 1, 1);
        }
        else if(stage_type==1)
        {
            
        }
        else if(stage_type==2)
        {
            this.transform.localScale = new Vector3(13, 1, 1);
        }
        else if(stage_type==3)
        {
            this.transform.localScale = new Vector3(5, 1, 1);
        }
        else if(stage_type==4)
        {
            this.transform.localScale = new Vector3(11, 1, 1);
        }
        else if(stage_type==5)
        {
            this.transform.localScale = new Vector3(7, 1, 1);
        }
        else if(stage_type==6)
        {
            
        }
        else if(stage_type==7)
        {
            this.transform.localScale = new Vector3(11, 1, 1);
        }
        else if(stage_type==8)
        {
            this.transform.localScale = new Vector3(13, 1, 1);
        }
        else if(stage_type==9)
        {
            this.transform.localScale = new Vector3(10, 1, 1);
        }
        else if(stage_type==10)
        {
            this.transform.localScale = new Vector3(13, 1, 1);
        }
        else if(stage_type==11)
        {

        }else if(stage_type==12)
        {
            this.transform.localScale = new Vector3(5, 1, 1);
        }
        else if(stage_type==13)
        {
            this.transform.localScale = new Vector3(9, 1, 1);
        }
        else if(stage_type==14)
        {
            this.transform.localScale = new Vector3(9, 1, 1);
        }
        else if(stage_type==15)
        {
            this.transform.localScale = new Vector3(12, 1, 1);
        }
        else if(stage_type==16)
        {
            this.transform.localScale = new Vector3(6, 1, 1);
        }
        else if(stage_type==17)
        {
            this.transform.localScale = new Vector3(10, 1, 1);
        }
        else if(stage_type==18)
        {

        }else if(stage_type==19)
        {
            this.transform.localScale = new Vector3(10, 1, 1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
