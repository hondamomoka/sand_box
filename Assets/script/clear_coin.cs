using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class clear_coin : MonoBehaviour
{
    bool down;
    bool next;
    bool slow;
    public float add;
    float add_pos;
    public ParticleSystem ps;
    public ParticleSystem ps2;
    public ParticleSystem ps3;
    public ParticleSystem ps4;
    public float par;
    bool effect;
    public save save;
    public coin_mode made;
    public Material[] material;
    public GameObject coinbody;
    int lank;


    //音をつけるために追加
    private GameObject audioManager;
    private Audio_Manager am;
    [SerializeField] private AudioClip audioClip;
    private bool soundflag;
    private float soundTime;

    //シーンフェードをつけるために追加
    private GameObject sceneManager;
    private Scene_Manager sm;

    // Start is called before the first frame update
    void Start()
    {
        add = 100.0f;
        add_pos = -0.5f;
        down = true;
        slow = false;
        next = false;
        effect = false;
        transform.rotation = Quaternion.Euler(0, 0, 90.0f);

        //音をつけるために追加
        audioManager = GameObject.Find("GameManager");
        am = audioManager.GetComponent<Audio_Manager>();
        soundflag = false;
        soundTime = 0.0f;

        //シーンフェードをつけるために追加
        sceneManager = GameObject.Find("GameManager");
        sm = sceneManager.GetComponent<Scene_Manager>();

        par = FindObjectOfType<NeedleRot>().safe_rate;



        if ((float)par >= 0.8f)
        {
            lank = 4;
            coinbody.GetComponent<Renderer>().material = material[0];
        }
        else if ((float)par < 0.8f && (float)par >= 0.6f)
        {
            lank = 3;
            coinbody.GetComponent<Renderer>().material = material[1];
        }
        else if ((float)par < 0.6f && (float)par >= 0.4f)
        {
            lank = 2;
            coinbody.GetComponent<Renderer>().material = material[2];
        }
        else if ((float)par < 0.4f)
        {
            lank = 1;
            coinbody.GetComponent<Renderer>().material = material[3];
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (down)
        {
            add_pos += 0.01f * Time.deltaTime;
            add -= 5.0f * Time.deltaTime;

            if (add_pos > -0.005f)
            {
                add_pos = -0.005f;
            }

            transform.Rotate(add * Time.deltaTime, 0, 0.0f);
            transform.Translate(add_pos * Time.deltaTime, 0, 0);

            if (transform.position.y <= 0.0f)
            {
                down = false;
                slow = true;
                //next = true;

            }
        }

        if (slow)
        {
            add -= 15.0f * Time.deltaTime;

            if (add < 25)
            {
                Debug.Log("最低値");
                add = 25;
                if (!soundflag)
                {
                    soundTime += Time.deltaTime;
                    if (soundTime > 1.0f)
                    {
                        am.PlaySE(audioClip);
                        soundflag = true;
                    }
                }
            }

            transform.Rotate(add * Time.deltaTime, 0, 0.0f);

            if (transform.rotation.y > 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, 90.0f);
                slow = false;
                next = true;


            }
        }

        if (next)
        {
            if (!effect)
            {
                Debug.Log(par);

                if ((float)par >= 0.8f)
                {
                    Instantiate(ps, new Vector3(this.transform.position.x, transform.position.y, transform.position.z + 1), Quaternion.Euler(-90, 0, 0));

                }
                else if ((float)par < 0.8f && (float)par >= 0.6f)
                {
                    Instantiate(ps2, new Vector3(this.transform.position.x, transform.position.y, transform.position.z + 1), Quaternion.Euler(-90, 0, 0));

                }
                else if ((float)par < 0.6f && (float)par >= 0.4f)
                {
                    Instantiate(ps3, new Vector3(this.transform.position.x, transform.position.y, transform.position.z + 1), Quaternion.Euler(-90, 0, 0));

                }
                else if ((float)par < 0.4f)
                {
                    Instantiate(ps4, new Vector3(this.transform.position.x, transform.position.y, transform.position.z + 1), Quaternion.Euler(-90, 0, 0));

                }

                int oldLank = PlayerPrefs.GetInt("コイン" + made.stage_type, 0);
                Debug.Log("前セーブデータ" + oldLank);

                if (lank > oldLank)
                {
                    save.save_coin(made.stage_type, lank);
                }
                //Instantiate(ps, new Vector3(this.transform.position.x, transform.position.y, transform.position.z + 1), Quaternion.Euler(-90, 0, 0));

                effect = true;
            }


            if (Input.GetKeyDown(KeyCode.Z) || Input.GetKeyDown(KeyCode.Joystick1Button0) || Input.GetKeyDown(KeyCode.Joystick1Button1))
            {
                if (FindObjectOfType<postp>())
                {
                    FindObjectOfType<postp>().end();
                }
                sm.SceneChange(Scene_Manager.Stage.SELECTS);
            }
        }


    }
}
