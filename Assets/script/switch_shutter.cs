using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switch_shutter : MonoBehaviour
{
    public GameObject wall;
    int count = 0;
    bool on = false;
    int max_count;
    public Material[] material;

    //音をつけるために追加
    private GameObject audioManager;
    private Audio_Manager script;
    [SerializeField] private AudioClip audioClip;

    // Start is called before the first frame update
    void Start()
    {
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
            on = true;
            count = 0;
            transform.position += new Vector3(0, 0, 0.2f);

            wall.layer = 0;
            wall.GetComponent<Renderer>().material = material[1];
            script.PlaySE(audioClip);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (on == false)
        {
            if (other.gameObject.CompareTag("sand_normal") || other.gameObject.CompareTag("sand_float"))
            {
                count++;
            }
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (on == false)
        {
            if (other.gameObject.CompareTag("sand_normal") || other.gameObject.CompareTag("sand_float"))
            {
                count--;
            }
        }
    }
}
