using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultBallMove : MonoBehaviour {
    public float moveSpeed;                         //초기 움직임 속도
    Vector2 moveDir;                         //움직일 방향 벡터
    public float moveAccel;                         //가속도
    public float initSpeed;

    private float flowTime = 0.0f;

    // Use this for initialization
    void Start () {
        moveSpeed = initSpeed = 1.5f;
        moveDir.x = 0; moveDir.y = 1;
        moveAccel =  0.1f;
    }
	
	// Update is called once per frame
	void Update () {
        //키입력
        //0.5초에 한번씩 전환가능
        if (flowTime >= 0.15f)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                moveDir *= -1;               //방향전환
                moveSpeed *= 0.8f;       //가속도 증가
                if (moveSpeed < initSpeed)
                    moveSpeed = initSpeed;
                flowTime = 0;
            }
        }

        //방향과 가속도를이용해 이동
        this.transform.Translate(moveDir * (moveSpeed) * Time.deltaTime, Space.World);
        //4 ~ -2
        if (this.transform.position.y >= 4.0f)
        {
            Vector3 pos = this.transform.position;
            pos.y -= moveDir.y * (moveSpeed) * Time.deltaTime;
            this.transform.position = pos;
        }
        else if (this.transform.position.y <= -2.0f)
        {
            Vector3 pos = this.transform.position;
            pos.y -= moveDir.y * (moveSpeed) * Time.deltaTime;
            this.transform.position = pos;
        }
        else
             moveSpeed += moveAccel;

        flowTime += Time.deltaTime;

    }

}
