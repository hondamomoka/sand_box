using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Clear_Manager : MonoBehaviour
{
    //何かのobjectに衝突した時の処理
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            SceneManager.LoadScene("Selects");
        }
    }
}
