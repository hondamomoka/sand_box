using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class clear : MonoBehaviour
{
    public Camera came;
    Vector3 camera_pos;
    public GameObject coin;
    public bool on;
    public bool set;
    public postp postp;
    public NeedleRot Stop_Watch;

    private GameObject rotateManager;
    private rotation rotateScript;
    private rotation_panguin rotateScript2;

    public hint hint;

    // Start is called before the first frame update
    void Start()
    {
        camera_pos = came.transform.position;
        on = false;
        set = false;

        //ステージの値を無理やり取得(変更予定)
        rotateManager = GameObject.Find("stage");
        if (rotateManager == null)
            rotateManager = GameObject.Find("Stage");

        //if (SceneManager.GetActiveScene().name != "stage_penguin")
        if(Game_Manager.Instance.sm.nowScene != Scene_Manager.Stage.STAGE_PENGUIN)
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
        if(on)
        {
            hint.count_save();
            hint.Stop();

            Instantiate(coin, new Vector3(camera_pos.x, camera_pos.y + 3.0f, camera_pos.z + 1.5f), Quaternion.identity);
            on = false;
            set = true;
            postp.on = true;

            //砂の音を消しましょう
            Game_Manager.Instance.am.source[2].Stop();

            //メニューが出てる状態でクリアしたら勝手に消す
            GameObject menu = GameObject.Find("menu(Clone)");
            if (menu != null)
            {
                Fade_Manager.Instance.MenuOut();
                Destroy(menu);
            }

            //これ以降このステージ内ではメニューは開けません
            Game_Manager.Instance.sm.menuFlag = true;

            //回転も禁止
            if (SceneManager.GetActiveScene().name != "stage_penguin")
            {
                rotateScript.rotateFlag = false;
            }
            else
            {
                rotateScript2.rotateFlag = false;
            }
            
            Stop_Watch.Set_Stop();

            switch (Game_Manager.Instance.sm.selectSelect)
            {
                case 2:
                case 12:
                case 5:
                case 15:
                    Game_Manager.Instance.sm.selectSelect += 4;
                    break;
                case 8:
                case 10:
                    Game_Manager.Instance.sm.selectSelect += 3;
                    break;
                case 18:
                    Game_Manager.Instance.sm.selectSelect = 3;
                    break;
                default:
                    Game_Manager.Instance.sm.selectSelect++;
                    break;
            }
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
