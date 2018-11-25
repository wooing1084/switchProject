using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameManager : MonoBehaviour {

    private int score = 0;          //점수
    public static gameManager instance;
    public Text scoreText;
    GameObject Score;
    GameObject Ball;

    private void Awake()
    {
        if (!instance)
            instance = this;
        Score = GameObject.FindGameObjectWithTag("Text");
        Ball = GameObject.FindGameObjectWithTag("Player");
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Score.transform.position.y > 380f){
            Score.transform.Translate(new Vector2(0, -3));
        }
    }

    //점수추가
    public void AddScore(int val)
    {
        score += val;
        //scoreText.text = "Score: " + score;
        scoreText.text = "" + score;
    }
}
