using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gear_risu : MonoBehaviour
{
    public int count;

    //音追加用
    private GameObject audioManager;
    private Audio_Manager script;
    [SerializeField] private AudioClip audioClip;
    private float time;

    // Start is called before the first frame update
    void Start()
    {
        //音追加用
        audioManager = GameObject.Find("GameManager");
        script = audioManager.GetComponent<Audio_Manager>();
        time = 0.6f;
    }

    // Update is called once per frame
    void Update()
    {
        if(count>20)
        {
            transform.Rotate(0, 0.0f, 1.0f);

            time += Time.deltaTime;
            if (time > 0.6f)
            {
                script.PlaySE(audioClip);
                time = 0.0f;
            }
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
        }
    }

 
}
