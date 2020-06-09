using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class clear : MonoBehaviour
{
    public Camera came;
    Vector3 camera_pos;
    public GameObject coin;
    public bool on;
    public bool set;
    public postp postp;

    //音追加用
    private GameObject GameManager;
    private Audio_Manager am;
    private Scene_Manager sm;

    private GameObject rotateManager;
    private rotation rotateScript;

    // Start is called before the first frame update
    void Start()
    {
        camera_pos = came.transform.position;
        on = false;
        set = false;

        //音追加用
        GameManager = GameObject.Find("GameManager");
        am = GameManager.GetComponent<Audio_Manager>();
        sm = GameManager.GetComponent<Scene_Manager>();

        //ステージの値を無理やり取得(変更予定)
        rotateManager = GameObject.Find("stage");
        if (rotateManager == null)
            rotateManager = GameObject.Find("Stage");

        rotateScript = rotateManager.GetComponent<rotation>();
    }

    // Update is called once per frame
    void Update()
    {
        if(on)
        {
            Instantiate(coin, new Vector3(camera_pos.x, camera_pos.y + 3.0f, camera_pos.z + 1.5f), Quaternion.identity);
            on = false;
            set = true;
            postp.on = true;
            am.source[2].Stop();
            rotateScript.rotateFlag = false;

            if(sm.selectSelect != 20)
                sm.selectSelect++;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(!set)
        {
            if (other.gameObject.CompareTag("player"))
            {
                on = true;
            }
        }
        
    }
}
