using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateJellyfish : MonoBehaviour
{
    public float a;
    public float b;
    public int   changeAngle; // 回転角度

    public Material[] mat; 

    private Vector3 center;
    private float   angle;
    private float   space;
    private float   legLength;
    private float   zoom_y;

    GameObject[] obj_body;
    GameObject[] obj_legA;
    GameObject[] obj_legB;
    GameObject[] obj_legC;
    GameObject[] obj_legD;

    // Start is called before the first frame update
    void Start()
    {
        int LegAL = 98;
        int LegAR = 113;
        int LegBL = 121;
        int LegBR = 129;
        int LegCL = 269 - LegBR;
        int LegCR = 269 - LegBL;
        int LegDL = 269 - LegAR;
        int LegDR = 269 - LegAL;

        CreateBody(LegAL, LegAR, LegBL, LegBR, LegCL, LegCR, LegDL, LegDR);
        zoom_y = CreateLeg(LegAL, LegAR, obj_legA);
        SetZoom(LegAL, LegAR, "ZoomA");
        zoom_y = CreateLeg(LegBL, LegBR, obj_legB);
        SetZoom(LegBL, LegBR, "ZoomB");
        zoom_y = CreateLeg(LegCL, LegCR, obj_legC);
        SetZoom(LegCL, LegCR, "ZoomC");
        zoom_y = CreateLeg(LegDL, LegDR, obj_legD);
        SetZoom(LegDL, LegDR, "ZoomD");
        SetDoor(LegBR, LegCL);  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateBody(int aL,int aR,int bL, int bR, int cL, int cR, int dL, int dR)
    {
        int body_parts = 360 / changeAngle;
        obj_body = new GameObject[body_parts];

        angle = 0;
        space = 0.2f;
        legLength = 10.0f;

        center = GetComponent<Transform>().position;

        body_parts = 360 / changeAngle;

        for (int i = 0; i < body_parts; i++)
        {
            float radian = angle / 180 * Mathf.PI;
            float posx = center.x + a * Mathf.Cos(radian);
            float posy = center.y + b * Mathf.Sin(radian);
            angle += changeAngle;

            obj_body[i] = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            obj_body[i].transform.name = "Body" + i.ToString();
            obj_body[i].transform.parent = GameObject.Find("jellyfish").transform;
            obj_body[i].transform.position = new Vector3(posx, posy, center.z);
            obj_body[i].transform.Rotate(90, 0, 0, Space.World);
            obj_body[i].transform.localScale = new Vector3(1.0f, 2.0f, 1.0f);
            obj_body[i].GetComponent<CapsuleCollider>().height = 4;
            obj_body[i].GetComponent<Renderer>().enabled = true;
            obj_body[i].GetComponent<Renderer>().sharedMaterial = mat[0];

            if ((i >= aL && i <= aR) || (i >= bL && i <= cR) || (i >= dL && i <= dR))
            //if ((i >= aL && i <= aR) || (i >= bL && i <= bR) || (i >= cL && i <= cR) || (i >= dL && i <= dR))
            {
                obj_body[i].SetActive(false);
            }
        }
    }

    float CreateLeg(int left, int right, GameObject[] obj_leg)
    {
        float posCy = 0.0f;

        int leg_partsA;
        int leg_partsB;
        if (obj_body[left].transform.position.y > obj_body[right].transform.position.y)
        {
            leg_partsA = (int)((obj_body[left].transform.position.y - obj_body[right].transform.position.y + legLength) / space) + 1;
            leg_partsB = (int)(legLength / space);
        }
        else
        {
            leg_partsA = (int)(legLength / space) + 1;
            leg_partsB = (int)((obj_body[right].transform.position.y - obj_body[left].transform.position.y + legLength) / space);
        }
        int leg_partsC = (int)((obj_body[right].transform.position.x - obj_body[left].transform.position.x) / space);

        obj_leg = new GameObject[leg_partsA + leg_partsB + leg_partsC];

        for(int i = 0; i < leg_partsA; i++)
        {
            float posx = center.x + obj_body[left].transform.position.x;
            float posy = center.y + obj_body[left].transform.position.y - i * space;

            obj_leg[i] = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            obj_leg[i].transform.name = "Leg" + i.ToString();
            obj_leg[i].transform.parent = GameObject.Find("jellyfish").transform;
            obj_leg[i].transform.position = new Vector3(posx, posy, center.z);
            obj_leg[i].transform.Rotate(90, 0, 0, Space.World);
            obj_leg[i].transform.localScale = new Vector3(1.0f, 2.0f, 1.0f);
            obj_leg[i].GetComponent<CapsuleCollider>().height = 4;
            obj_leg[i].GetComponent<Renderer>().enabled = true;
            obj_leg[i].GetComponent<Renderer>().sharedMaterial = mat[0];
        }

        for (int i = leg_partsA; i < leg_partsA + leg_partsB; i++)
        {
            float posx = center.x + obj_body[right].transform.position.x;
            float posy = center.y + obj_body[right].transform.position.y - (i - leg_partsA) * space;

            obj_leg[i] = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            obj_leg[i].transform.name = "Leg" + i.ToString();
            obj_leg[i].transform.parent = GameObject.Find("jellyfish").transform;
            obj_leg[i].transform.position = new Vector3(posx, posy, center.z);
            obj_leg[i].transform.Rotate(90, 0, 0, Space.World);
            obj_leg[i].transform.localScale = new Vector3(1.0f, 2.0f, 1.0f);
            obj_leg[i].GetComponent<CapsuleCollider>().height = 4;
            obj_leg[i].GetComponent<Renderer>().enabled = true;
            obj_leg[i].GetComponent<Renderer>().sharedMaterial = mat[0];
        }

        for (int i = leg_partsA + leg_partsB; i < leg_partsA + leg_partsB + leg_partsC; i++)
        {
            float posx = center.x + obj_leg[leg_partsA - 1].transform.position.x + (i - leg_partsA - leg_partsB + 1) * space;
            float posy = center.y + obj_leg[leg_partsA - 1].transform.position.y;

            obj_leg[i] = GameObject.CreatePrimitive(PrimitiveType.Cylinder);
            obj_leg[i].transform.name = "Leg" + i.ToString();
            obj_leg[i].transform.parent = GameObject.Find("jellyfish").transform;
            obj_leg[i].transform.position = new Vector3(posx, posy, center.z);
            obj_leg[i].transform.Rotate(90, 0, 0, Space.World);
            obj_leg[i].transform.localScale = new Vector3(1.0f, 2.0f, 1.0f);
            obj_leg[i].GetComponent<CapsuleCollider>().height = 4;
            obj_leg[i].GetComponent<Renderer>().enabled = true;
            obj_leg[i].GetComponent<Renderer>().sharedMaterial = mat[0];

            posCy = posy;
        }

        return posCy;
    }

    void SetDoor(int left, int right)
    {
        GameObject doorL, doorR;
        Vector3 pos;
        float scale_x = (obj_body[right].transform.position.x - obj_body[left].transform.position.x) / 2;
        float scale_z = 4;

        doorL = GameObject.Find("DoorL");
        pos = obj_body[left].transform.position;
        pos.x += scale_x / 2;
        doorL.SendMessage("SetScaleX", scale_x);
        doorL.SendMessage("SetScaleZ", scale_z);
        doorL.SendMessage("SetPosition", pos);

        doorR = GameObject.Find("DoorR");
        pos.x = obj_body[right].transform.position.x;
        pos.x -= scale_x / 2;
        doorR.SendMessage("SetScaleX", scale_x);
        doorR.SendMessage("SetScaleZ", scale_z);
        doorR.SendMessage("SetPosition", pos);
    }

    void SetZoom(int left,int right, string name)
    {
        GameObject zoom;
        Vector3 pos;
        float scale_x = obj_body[right].transform.position.x - obj_body[left].transform.position.x - obj_body[left].transform.localScale.x;
        float scale_z = 4;

        zoom = GameObject.Find(name);
        pos.x = (obj_body[left].transform.position.x + obj_body[right].transform.position.x) / 2;
        pos.y = zoom_y + obj_body[left].transform.localScale.z / 2 + zoom.transform.localScale.y / 2;
        pos.z = center.z;
        zoom.SendMessage("SetScaleX", scale_x);
        zoom.SendMessage("SetScaleZ", scale_z);
        zoom.SendMessage("SetPosition", pos);
    }
}
