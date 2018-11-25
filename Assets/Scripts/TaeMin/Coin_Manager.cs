using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin_Manager : MonoBehaviour {

    Text Coin;
    int befCoin = GlobalVariable.data.coin;

    void Awake()
    {
        Coin = GetComponent<Text>();
    }

	void Update () {
        if (Input.GetKey(KeyCode.A))      //테스트용 A키 입력시 점수증가
        {
            befCoin = befCoin + 10;
        }
        Coin.text = befCoin.ToString();
    }
}
