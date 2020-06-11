using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class clear_ocean : MonoBehaviour
{
    public Camera came;
    Vector3 camera_pos;
    public GameObject coin;
    public bool on;
    public bool set;
    public postp_ocean postp;
    public NeedleRot Stop_Watch;

    private GameObject rotateManager;
    private rotation rotateScript;
    private rotation_panguin rotateScript2;

    //音追加用
    private GameObject audioManager;
    private Audio_Manager script;
    [SerializeField] private AudioClip audioClip;

    // Start is called before the first frame update
    void Start()
    {
        camera_pos = came.transform.position;
        on = false;
        set = false;

        //音追加用
        audioManager = GameObject.Find("GameManager");
        script = audioManager.GetComponent<Audio_Manager>();

        //ステージの値を無理やり取得(変更予定)
        rotateManager = GameObject.Find("stage");
        if (rotateManager == null)
            rotateManager = GameObject.Find("Stage");

        if (SceneManager.GetActiveScene().name != "stage_penguin")
        {
            rotateScript = rotateManager.GetComponent<rotation>();
        }
        else
        {
            rotateScript2 = rotateManager.GetComponent<rotation_panguin>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (on)
        {
            Instantiate(coin, new Vector3(camera_pos.x, camera_pos.y + 3.0f, camera_pos.z + 1.5f), Quaternion.identity);
            on = false;
            set = true;
            postp.on = true;

            if (SceneManager.GetActiveScene().name != "stage_penguin")
            {
                rotateScript.rotateFlag = false;
            }
            else
            {
                rotateScript2.rotateFlag = false;
            }

            Stop_Watch.Set_Stop();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (!set)
        {
            if (other.gameObject.CompareTag("player"))
            {
                on = true;
                script.source[2].Stop();
            }
        }

    }
}
