using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class hint : MonoBehaviour
{
    // Start is called before the first frame update

    public Image Lt;
    public Image Rt;
    public Image arrowL;
    public Image arrowR;
    Color col;
    int stage_type;
    bool tutrial;
    bool Fin;
    bool Fout;

    float display_count;
    int farst_count;
    int span = 100;
    int Dspan = 1200;
    float a_max = 0.84f;

    void Start()
    {
        Fin = false;
        Fout = false;
        col = Lt.color;

        if (SceneManager.GetActiveScene().name == "stage_risu")
        {
            stage_type = 0;
        }
        else if (SceneManager.GetActiveScene().name == "stage_cattle")
        {
            stage_type = 1;
        }
        else if (SceneManager.GetActiveScene().name == "stage_cell")
        {
            stage_type = 2;
        }
        else if (SceneManager.GetActiveScene().name == "stage_clione")
        {
            stage_type = 3;
        }
        else if (SceneManager.GetActiveScene().name == "stage_cobra")
        {
            stage_type = 4;
        }
        else if (SceneManager.GetActiveScene().name == "stage_crab")
        {
            stage_type = 5;
        }
        else if (SceneManager.GetActiveScene().name == "stage_crocodile")
        {
            stage_type = 6;
        }
        else if (SceneManager.GetActiveScene().name == "stage_dolphin")
        {
            stage_type = 7;
        }
        else if (SceneManager.GetActiveScene().name == "stage_gorira")
        {
            stage_type = 8;
        }
        else if (SceneManager.GetActiveScene().name == "stage_jellyfish")
        {
            stage_type = 9;
        }
        else if (SceneManager.GetActiveScene().name == "stage_penguin")
        {
            stage_type = 10;
        }
        else if (SceneManager.GetActiveScene().name == "stage_pig")
        {
            stage_type = 11;
        }
        else if (SceneManager.GetActiveScene().name == "stage_pigeon")
        {
            stage_type = 12;
        }
        else if (SceneManager.GetActiveScene().name == "stage_rabbits")
        {
            stage_type = 13;
        }
        else if (SceneManager.GetActiveScene().name == "stage_shell")
        {
            stage_type = 14;
        }
        else if (SceneManager.GetActiveScene().name == "stage_snails")
        {
            stage_type = 15;
        }
        else if (SceneManager.GetActiveScene().name == "stage_turtle")
        {
            stage_type = 16;
        }
        else if (SceneManager.GetActiveScene().name == "stage_uni")
        {
            stage_type = 17;
        }
        else if (SceneManager.GetActiveScene().name == "stage_volbox")
        {
            stage_type = 18;
        }
        else if (SceneManager.GetActiveScene().name == "stage_whale")
        {
            stage_type = 19;
        }

        int num = PlayerPrefs.GetInt("コイン" + 2, 0);

        if(num<1)
        {
            tutrial = true;
        }
        else
        {
            tutrial = false;
            col.a = 0.0f;
        }

        Lt.color = col;
        Rt.color = col;
        arrowL.color = col;
        arrowR.color = col;
    }

    // Update is called once per frame
    void Update()
    {
        float tri = Input.GetAxis("L_R_Trigger");
        //Debug.Log(tri);

        //Debug.Log(Input.GetKey(KeyCode.RightArrow));
        //Debug.Log(Input.GetKey(KeyCode.LeftArrow));

        //何も押されてなかったら
        if(Input.GetKey(KeyCode.RightArrow)==false &&Input.GetKey(KeyCode.LeftArrow)==false&& tri == 0)
        {
            // Debug.Log(1);
            display_count += 20 * Time.deltaTime;
        }
        else
        {
            display_count = 0;
            //fade_out();
            if(!Fin)
            {
                Fout = true;
            }

            //if (tutrial)
            //{
            //    if (farst_count > span)
            //    {
            //        farst_count = span;
            //        fade_out();
            //    }
            //}

        }

       // Debug.Log(display_count);

        if(display_count>span)
        {
            display_count = span;
            // fade_in();
            if(!Fout)
            {
                Fin = true;
            }
        }

        if(Fin)
        {
            fade_in();
        }

        if(Fout)
        {
            fade_out();
        }
    }

    private void FixedUpdate()
    {
       
    }

    public void fade_out()
    {
        col.a -= 0.2f * Time.deltaTime;

        if(col.a<0)
        {
            col.a = 0f;
            Fout = false;
        }

        Lt.color = col;
        Rt.color = col;
        arrowL.color = col;
        arrowR.color = col;

       
    }

    public void fade_in()
    {
        col.a += 0.2f * Time.deltaTime;

        if (col.a > a_max)
        {
            col.a = a_max;
            Fin = false;
        }

        Lt.color = col;
        Rt.color = col;
        arrowL.color = col;
        arrowR.color = col;

        
    }
}
