using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DefaultHuddleMove : MonoBehaviour {
    //장애물의 X좌표가 -4를 넘으면 화면 밖으로 나감
    //장애물 부모의 Y좌표는 랜덤값을 만들때 -1 ~ -6으로 만들어야 탈출구멍이 화면안에 나옴
    //허들들 사이의 간격을 3

    //허들 타입
    public enum HuddleType { Default, Wide, Lean, END };

    public Vector2 moveDir = new Vector2(-1,0);
    public float moveAccel = 2.0f;
    public GameObject nextHuddle;                   //다음장애물
    public float distance = 4.0f;                   //다음 장애물과의 거리
    public HuddleType type;
    public bool isScored = false;                   //공이 장애물을 넘었는지 체크(포지션이 재설정 될때 false로 다시 바뀜)  
    public float betweenDis = 1.5f;                 //허들 위아래 너비

    private GameObject ball;
    private GameObject childHuddle;                 //자식 허들

	// Use this for initialization
	void Start () {
        ball = GameObject.Find("ball");
        childHuddle = this.transform.GetChild(0).gameObject;

        //this.transform.position.y + 
        Vector3 pos = childHuddle.transform.localPosition;
        pos.y = betweenDis;
        childHuddle.transform.localPosition = pos;

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
            pos.x = nextHuddle.transform.position.x + distance + nextHuddle.transform.localScale.x;
            this.transform.position = pos;
            this.isScored = false;

            pos = childHuddle.transform.localPosition;
            pos.y = betweenDis;
            childHuddle.transform.localPosition = pos;

            //이전 허들 타입에 따른 변화 초기화
            this.transform.Rotate(0, 0, 0, Space.World);

            type =( HuddleType)Random.Range(0,(int)HuddleType.END);
            if(type == HuddleType.Default)
            {
                SetDefaultScale();
            }

            //타입별로 스크립트 생성하여 GetComponent<클래스이름>().함수 사용하면 됨
            //타입 만들때 마다 enum에 추가
            switch (type)
            {
                case HuddleType.Default:
                    GameObject.Find("ScriptCollector").GetComponent<DefaultSetHeight>().SetHeight(this.gameObject,nextHuddle,5,betweenDis);
                    break;
                case HuddleType.Wide:
                    GameObject.Find("ScriptCollector").GetComponent<DefaultSetHeight>().SetHeight(this.gameObject, nextHuddle, 5, betweenDis);
                    GameObject.Find("ScriptCollector").GetComponent<WideHuddlePatern>().SetWidth(this.gameObject,3.0f);
                    break;
                case HuddleType.Lean:
                    GameObject.Find("ScriptCollector").GetComponent<DefaultSetHeight>().SetHeight(this.gameObject, nextHuddle, 3, betweenDis);
                    GameObject.Find("ScriptCollector").GetComponent<WideHuddlePatern>().SetWidth(this.gameObject, 3.0f);
                    GameObject.Find("ScriptCollector").GetComponent<LeanHuddle>().SetRotate(this.gameObject, 25, -25);


                    break;
                default:
                    break;
            }     
        }

        //공을 지나갔는지 체크
        CheckBallPassed();

    }

    private void SetDefaultScale()
    {
        Vector3 scaleVec = this.transform.localScale;

        scaleVec.x = 0.5f;
        scaleVec.y = 6;
        scaleVec.z = 1;
        // me.
        this.transform.localScale = scaleVec;
    }

    private void CheckBallPassed()
    {
        if (!isScored)
        {
            if (ball.activeSelf)
            {
                if ((this.transform.position.x + this.transform.lossyScale.x) < ball.transform.position.x)
                {
                    //gameManager.instance.AddScore(1);
                    isScored = true;
                }
            }
        }
    }
}