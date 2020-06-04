using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBook : MonoBehaviour
{
    public GameObject Coin;

    void Start()
    {

    }

    void Update()
    {

    }

    //接触したオブジェクトが引数otherとして渡される
    void OnTriggerEnter(Collider other)
    {
        //接触したオブジェクトのタグが"Player"のとき
        if (other.CompareTag("book"))
        {
            Coin.GetComponent<CoinUp>().StartCoinUp();
        }
    }
}
