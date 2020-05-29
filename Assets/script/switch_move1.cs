using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switch_move1 : MonoBehaviour
{
    public move_cube cube;
    int max_count;
    int count;
    public Material[] material;

    //音をつけるために追加
    private GameObject audioManager;
    private Audio_Manager script;
    [SerializeField] private AudioClip audioClip;

    // Start is called before the first frame update
    void Start()
    {
        cube.move = false;

        Transform mytra = this.transform;
        Vector3 size = mytra.localScale;
        max_count = (int)(size.x * size.y * 100);

        //音をつけるために追加
        audioManager = GameObject.Find("GameManager");
        script = audioManager.GetComponent<Audio_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (count > max_count)
        {
            if (cube.move == false)
            {
                cube.move = true;
                count = 0;
                this.GetComponent<Renderer>().material = material[1];
                script.PlaySE(audioClip);
            }
        }

        if(cube.move==false)
        {
            this.GetComponent<Renderer>().material = material[0];
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("sand_normal"))
        {
            count++;
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("sand_normal"))
        {
            count--;
            if (count < 0)
            {
                count = 0;
            }
        }
    }
}
