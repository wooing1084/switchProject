using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DefaultHuddleMove : MonoBehaviour {
    //장애물의 X좌표가 -4를 넘으면 화면 밖으로 나감
    //장애물 부모의 Y좌표는 랜덤값을 만들때 -1 ~ -6으로 만들어야 탈출구멍이 화면안에 나옴
    //허들들 사이의 간격을 3

    //허들 타입
    //                      기본      넓은  나누어진(아래가 뒤로, 위에)   기울어진
    public enum HuddleType { Default, Wide, botDivide, topDivide, Lean, END };

    public Vector2 moveDir = new Vector2(-1,0);
    public float moveAccel = 2.0f;
    public GameObject frontHuddle;                   //앞장애물
    public float distance = 4.0f;                   //앞 장애물과의 거리
    public HuddleType type;
    public bool isScored = false;                   //공이 장애물을 넘었는지 체크(포지션이 재설정 될때 false로 다시 바뀜)  
    public float betweenDis;                        //허들 위아래 너비

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
        //가장 안쪽(카메라중심으로 가까운)좌표를 찾음
        Vector3 botPos = this.transform.position + new Vector3(this.transform.localScale.x, 0, 0);
        Vector3 topPos = childHuddle.transform.position + new Vector3(childHuddle.transform.localScale.x, 0, 0);
        Vector3 position = botPos.x > topPos.x ? botPos : topPos;
        Vector3 range = Camera.main.WorldToViewportPoint(position);


        //맵밖으로 나가면 포지션 재설정
        if (range.x < -0.05f)
        {
            Vector3 pos = this.transform.position;
            GameObject frontChild = frontHuddle.GetComponent<DefaultHuddleMove>().childHuddle;
            Transform trn = frontHuddle.transform.position.x > frontChild.transform.position.x ? 
                frontHuddle.transform : frontChild.transform;
            pos.x = trn.position.x + distance + trn.localScale.x;
            this.transform.position = pos;
            this.isScored = false;

            pos = childHuddle.transform.localPosition;
            pos.y = betweenDis;
            childHuddle.transform.localPosition = pos;

            //이전 허들 타입에 따른 변화 초기화
            this.transform.Rotate(0, 0, 0, Space.World);

            //이전 패턴에서 변경점 초기화
            setDefault();
            
            CalculatePattern();
            float frontHuddleY = frontHuddle.transform.position.y;
                


            //타입별로 스크립트 생성하여 GetComponent<클래스이름>().함수 사용하면 됨
            //타입 만들때 마다 enum에 추가
            switch (type)
            {
                case HuddleType.Default:
                    GameObject.Find("ScriptCollector").GetComponent<DefaultSetHeight>().SetHeight(this.gameObject, frontHuddleY, 3,betweenDis);
                    break;
                case HuddleType.Wide:
                    GameObject.Find("ScriptCollector").GetComponent<DefaultSetHeight>().SetHeight(this.gameObject, frontHuddleY, 3, betweenDis);
                    GameObject.Find("ScriptCollector").GetComponent<WideHuddlePatern>().SetWidth(this.gameObject,3.0f);
                    break;
                case HuddleType.botDivide:
                    GameObject.Find("ScriptCollector").GetComponent<DefaultSetHeight>().SetHeight(this.gameObject, frontHuddleY, 3, betweenDis);
                    GameObject.Find("ScriptCollector").GetComponent<WideHuddlePatern>().SetWidth(this.gameObject, 2.0f);
                    GameObject.Find("ScriptCollector").GetComponent<divideHuddle>().divide(childHuddle, this.gameObject,2,1,false);
                    break;
                case HuddleType.topDivide:
                    GameObject.Find("ScriptCollector").GetComponent<DefaultSetHeight>().SetHeight(this.gameObject, frontHuddleY, 3, betweenDis);
                    GameObject.Find("ScriptCollector").GetComponent<WideHuddlePatern>().SetWidth(this.gameObject, 2.0f);
                    GameObject.Find("ScriptCollector").GetComponent<divideHuddle>().divide(this.gameObject,childHuddle, 2, 1,true);
                    break;
                case HuddleType.Lean:
                    GameObject.Find("ScriptCollector").GetComponent<DefaultSetHeight>().SetHeight(this.gameObject, frontHuddleY, 3, betweenDis);
                    GameObject.Find("ScriptCollector").GetComponent<WideHuddlePatern>().SetWidth(this.gameObject, 3.0f);
                    GameObject.Find("ScriptCollector").GetComponent<LeanHuddle>().SetRotate(this.gameObject);
                    break;

                    
                default:
                    break;
            }     
        }

        //공을 지나갔는지 체크
        CheckBallPassed();

    }

    private void setDefault()
    {
        //스케일
        Vector3 scaleVec = this.transform.localScale;
        scaleVec.x = 0.5f;
        scaleVec.y = 6;
        scaleVec.z = 1;
        this.transform.localScale = scaleVec;
        //회전
        this.transform.rotation = new Quaternion(0, 0, 0, 1);
        //자식
        childHuddle.transform.position = this.transform.position;
        childHuddle.transform.localPosition = new Vector3(0, betweenDis, 0);
    }

    private void CheckBallPassed()
    {
        if (!isScored)
        {
            if (ball.activeSelf)
            {
                if ((this.transform.position.x + this.transform.lossyScale.x) < ball.transform.position.x)
                {
                    gameManager.instance.AddScore(1);
                    isScored = true;
                }
            }
        }
    }

    //패턴 연산함수(조건에 따라 패턴 내보냄)
    private void CalculatePattern()
    {
        HuddleType prevType = type;
        //이전타입과 변경된 타입이 같지 않을때까지
        while (prevType == type)
        {
            //앞에 기울어진 장애물이 있을때 나는 기울어진것을 제외한 타입을 가짐
            if (frontHuddle.GetComponent<DefaultHuddleMove>().type == HuddleType.Lean)
                type = (HuddleType)Random.Range(0, (int)HuddleType.Lean);
            //아닐때 모든 타입
            else
                type = (HuddleType)Random.Range(0, (int)HuddleType.END);
            //
            if (type == HuddleType.botDivide)
            {
                if (this.frontHuddle.GetComponent<DefaultHuddleMove>().type == type)
                    type = prevType;
            }
            else if (type == HuddleType.topDivide)
            {
                if (this.frontHuddle.GetComponent<DefaultHuddleMove>().type == type)
                    type = prevType;
            }
        }

    }

}