using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultHuddleMove : MonoBehaviour {
    //장애물의 X좌표가 -4를 넘으면 화면 밖으로 나감
    //장애물 부모의 Y좌표는 랜덤값을 만들때 -1 ~ -6으로 만들어야 탈출구멍이 화면안에 나옴
    //허들들 사이의 간격을 3


    public Vector2 moveDir = new Vector2(-1,0);
    public float moveAccel = 2.0f;
    public GameObject nextHuddle;                   //다음장애물

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.transform.Translate(moveDir * Time.deltaTime * moveAccel,Space.World);
        //맵밖으로 나가면 포지션 재설정
        if(this.transform.position.x <= -4)
        {
            Vector3 pos = this.transform.position;
            pos.x = nextHuddle.transform.position.x + 3;
            pos.y = Random.Range(0.0f, -5.0f);
            this.transform.position = pos;

        }
	}
}
