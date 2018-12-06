using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinConvert : MonoBehaviour {

    void Start () {
    }

    public void Convert(int score)
    {
        if(GlobalVariable.data.highestScore < score)
        {
            GlobalVariable.data.highestScore = score;
        }
        GlobalVariable.data.coin += score / 5;
    }
}
