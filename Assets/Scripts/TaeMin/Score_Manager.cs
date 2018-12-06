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
        Score.text = befScore.ToString();
    }

}
