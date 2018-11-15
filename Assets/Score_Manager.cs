using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score_Manager : MonoBehaviour {

    Text Score;
    int befScore = GlobalVariable.data.highestScore;

    void Awake()
    {
        Score = GetComponent<Text>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.B))      //테스트용 B키 입력시 점수증가
        {
            befScore = befScore + 10;
        }
        Score.text = befScore.ToString();
    }

}
