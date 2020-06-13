using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class swich_Wind : MonoBehaviour
{
    public wind_2 wind;
    bool on = false;
    public swichEFonly_cobra effect;

    [SerializeField] private AudioClip audioClip;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(10f * Time.deltaTime, 0, 20f * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (on == false)
        {
            if (other.gameObject.CompareTag("player"))
            {
                on = true;

                wind.start();
                effect.playPS();
                Game_Manager.Instance.am.PlaySE(audioClip);

                Destroy(this.gameObject);
            }
        }
    }
}
