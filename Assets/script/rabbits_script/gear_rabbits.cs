using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gear_rabbits : MonoBehaviour
{
    public  float count;
    float count_max;
    public bool moving;
    public bool stop;
    public ParticleSystem ps1;

    //音追加用
    private GameObject audioManager;
    private Audio_Manager script;
    [SerializeField] private AudioClip audioClip;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        ps1.Stop();
        count = 0;
        count_max = 10;
        moving = false;
        stop = false;

        //音追加用
        audioManager = GameObject.Find("GameManager");
        script = audioManager.GetComponent<Audio_Manager>();
        time = 0.6f;
    }

    // Update is called once per frame
    void Update()
    {
        if(!moving)
        {
            if (count > count_max)
            {
                moving = true;
                ps1.Play();
            }
        }
        

        if(!stop)
        {
            if (moving)
            {
                transform.Rotate(0, 1.0f, 0);

                time += Time.deltaTime;
                if (time > 0.6f)
                {
                    script.PlaySE(audioClip);
                    time = 0.0f;
                }
            }
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(!moving)
        {
            if (other.gameObject.CompareTag("sand_normal"))
            {

                count += 1.0f;
            }
        }
       
    }

    private void OnTriggerExit(Collider other)
    {
        if(!moving)
        {
            if (other.gameObject.CompareTag("sand_normal"))
            {

                count -= 1.0f;
            }
        }
       
    }
}
