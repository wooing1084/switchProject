using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultBallMove : MonoBehaviour {
    public float moveSpeed;                         //초기 움직임 속도
    Vector2 moveDir;                         //움직일 방향 벡터
    public float moveAccel;                         //가속도
    public float initSpeed;

    // Use this for initialization
    void Start () {
        moveSpeed = initSpeed = 1.5f;
        moveDir.x = 0; moveDir.y = 1;
        moveAccel =  0.1f;
    }
	
	// Update is called once per frame
	void Update () {
        //키입력
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            moveDir *= -1;               //방향전환
            moveSpeed *= 0.8f;       //가속도 증가
            if (moveSpeed < initSpeed)
                moveSpeed = initSpeed;
        }

        //방향과 가속도를이용해 이동
        this.transform.Translate(moveDir * (moveSpeed) * Time.deltaTime, Space.World);
        moveSpeed += moveAccel;

    }

}
