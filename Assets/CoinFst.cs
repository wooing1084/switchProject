using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinFst : MonoBehaviour
{

    private SpriteRenderer spriterenderer;
    public Sprite[] sprites = new Sprite[10];
    /*int sum1 = GlobalVariable.coin;   
    int sum2 = GlobalVariable.coin;
    int sum3 = GlobalVariable.coin;*/
    int coin = GlobalVariable.data.coin;

    // Use this for initialization
    void Start()
    {
        spriterenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //나누는 수
        int divNum = 10;
        //현재 수
        int nowNum;

        while (coin % divNum != coin)
        {
            //n자리수까지 자름
            nowNum = coin % divNum;
            //n자리수 숫자 구하기 ex) nowNum = 350 divNum = 1000일때 저 공식을 사용하면 350 / 100 이기 때문에 3이 된다
            nowNum /= (divNum / 10);
        }

    }
}