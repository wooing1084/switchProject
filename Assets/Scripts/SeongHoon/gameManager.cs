using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour {

    private int score = 0;          //점수
    public static gameManager instance;
    public Text scoreText;

    private void Awake()
    {
        if (!instance)
            instance = this;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    //점수추가
    public void AddScore(int val)
    {
        score += val;
        //scoreText.text = "Score: " + score;
        scoreText.text = "" + score;
    }
}
