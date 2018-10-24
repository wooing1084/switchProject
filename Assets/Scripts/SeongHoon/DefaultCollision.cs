using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultCollision : MonoBehaviour {

    GameObject ball;

	// Use this for initialization
	void Start () {
        ball = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject == ball)
        {
            UnityEngine.Debug.Log("벽과 충돌");
            //게임오버 씬 전환부분
            ball.SetActive(false);
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject == ball)
        {
            UnityEngine.Debug.Log("벽과 충돌에서 나옴");
        }
    }

    // Update is called once per frame
    void Update () {
	}
}
