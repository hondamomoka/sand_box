﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class coin_mode : MonoBehaviour
{
    public Material[] material;
    int stage_type;

    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "stage_risu")
        {
            stage_type = 0;
        }
        else if(SceneManager.GetActiveScene().name == "stage_cattle")
        {
            stage_type = 1;
        }
        else if(SceneManager.GetActiveScene().name == "stage_cell")
        {
            stage_type = 2;
        }
        else if(SceneManager.GetActiveScene().name == "stage_clione")
        {
            stage_type = 3;
        }
        else if(SceneManager.GetActiveScene().name == "stage_cobra")
        {
            stage_type = 4;
        }
        else if(SceneManager.GetActiveScene().name == "stage_crab")
        {
            stage_type = 5;
        }
        else if(SceneManager.GetActiveScene().name == "stage_crocodile")
        {
            stage_type = 6;
        }
        else if(SceneManager.GetActiveScene().name == "stage_dolphin")
        {
            stage_type = 7;
        }
        else if(SceneManager.GetActiveScene().name == "stage_gorira")
        {
            stage_type = 8;
        }
        else if(SceneManager.GetActiveScene().name == "stage_jellyfish")
        {
            stage_type = 9;
        }
        else if(SceneManager.GetActiveScene().name == "stage_penguin")
        {
            stage_type = 10;
        }
        else if(SceneManager.GetActiveScene().name == "stage_pig")
        {
            stage_type = 11;
        }
        else if(SceneManager.GetActiveScene().name == "stage_pigeon")
        {
            stage_type = 12;
        }
        else if(SceneManager.GetActiveScene().name == "stage_rabbits")
        {
            stage_type = 13;
        }
        else if(SceneManager.GetActiveScene().name == "stage_shell")
        {
            stage_type = 14;
        }
        else if(SceneManager.GetActiveScene().name == "stage_snails")
        {
            stage_type = 15;
        }
        else if(SceneManager.GetActiveScene().name == "stage_turtle")
        {
            stage_type = 16;
        }
        else if(SceneManager.GetActiveScene().name == "stage_uni")
        {
            stage_type = 17;
        }
        else if(SceneManager.GetActiveScene().name == "stage_volbox")
        {
            stage_type = 18;
        }
        else if(SceneManager.GetActiveScene().name == "stage_whale")
        {
            stage_type = 19;
        }
        else
        {
            stage_type = 1;
        }

        this.GetComponent<Renderer>().material = material[stage_type];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
