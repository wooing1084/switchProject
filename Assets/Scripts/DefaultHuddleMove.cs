using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DefaultHuddleMove : MonoBehaviour {
    //장애물의 X좌표가 -4를 넘으면 화면 밖으로 나감
    //장애물 부모의 Y좌표는 랜덤값을 만들때 -1 ~ -6으로 만들어야 탈출구멍이 화면안에 나옴
    //허들들 사이의 간격을 3

    //허들 타입
    public enum HuddleType { Default };

    public Vector2 moveDir = new Vector2(-1,0);
    public float moveAccel = 2.0f;
    public GameObject nextHuddle;                   //다음장애물
    public float distance = 4.0f;
    public HuddleType type;

	// Use this for initialization
	void Start () {
		
	}
   
	// Update is called once per frame
	void Update () {
        this.transform.Translate(moveDir * Time.deltaTime * moveAccel,Space.World);

        //카메라의 뷰 포트의 상대좌표로 어디에 위치해있는지 구함(오브젝트 위치 + 가로너비(이유는 박스 오른쪽이 화면에 나갔을 때가 나간것이기 때문))
        Vector3 range = Camera.main.WorldToViewportPoint(this.transform.position + new Vector3(this.transform.localScale.x,0,0));

        //맵밖으로 나가면 포지션 재설정
        if (range.x < 0f)
        {
            Vector3 pos = this.transform.position;
            pos.x = nextHuddle.transform.position.x + distance;
            this.transform.position = pos;

            //타입별로 스크립트 생성하여 GetComponent<클래스이름>().함수 사용하면 됨
            //타입 만들때 마다 enum에 추가
            switch (type)
            {
                case HuddleType.Default:
                    this.GetComponent<DefaultSetHeight>().SetHeight();
                    break;
                default:
                    break;
            }
            
        }
	}
}