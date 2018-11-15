using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//BinaryFormatter사용하기 위함
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

//데이터 클래스
//여기에 추가하고싶은 전역변수 public 변수형 변수명
//만약 초기값이 정해져 있다면 Init함수에서 초기화시키면 됨

//전역변수 사용방법
//GlobalVariable.data.변수이름 하면 접근 가능
[Serializable]
public class Data
{
    //돈
    public  int coin = 0;
    //최고점수
    public  int highestScore = 0;

    //초기화
    public void Init()
    {
        coin = 0;
        highestScore = 0;
    }
}


public static class GlobalVariable {

    public static Data data = new Data();
}