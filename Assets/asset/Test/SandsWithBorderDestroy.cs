using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandsWithBorderDestroy : MonoBehaviour
{
    public Material[] material;
    public ParticleSystem ps;
    public float Size_Change_Idx;

    GameObject Watch;
    float degree;
    float move_index;
    Renderer Sand_Renderer;

    // Start is called before the first frame update
    void Start()
    {
        Watch = GameObject.Find("PocketWatchZone");
        move_index = 16.0f;
        Sand_Renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.layer == 28)
        {
            transform.position = new Vector3(
                transform.position.x + Mathf.Cos(degree) / move_index,
                transform.position.y + Mathf.Sin(degree) / move_index,
                Watch.transform.position.z);
            transform.localScale *= Size_Change_Idx;
            //transform.localScale *= 1.05f;

            if (move_index > 1.0f)
            {
                move_index -= 0.1f;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Watch)
        {
            Instantiate(ps, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("stage_border"))
        {
            // layer: sands_and_watch
            gameObject.layer = 28;

            gameObject.tag = "Untagged";

            transform.parent = null;

            degree = Mathf.Atan2(
                Watch.transform.position.y + Random.Range(-Watch.transform.lossyScale.z, Watch.transform.lossyScale.z) / 3 - transform.position.y,
                Watch.transform.position.x + Random.Range(-Watch.transform.lossyScale.x, Watch.transform.lossyScale.x) / 3 - transform.position.x);
            GetComponent<Rigidbody>().isKinematic = true;

            Sand_Renderer.material = material[material.Length - 1];
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //if (other.gameObject.CompareTag("stage_border"))
        //{
        //    // layer: sands_and_watch
        //    gameObject.layer = 28;

        //    degree = Mathf.Atan2(
        //        Watch.transform.position.y - transform.position.y,
        //        Watch.transform.position.x - transform.position.x);
        //    GetComponent<Rigidbody>().useGravity = false;
        //}
    }
}
