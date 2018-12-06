using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//BinaryFormatter사용하기 위함
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class SaveNLoad : MonoBehaviour
{

    //모든 데이터 저장
    public void SaveAll()
    {
        //바이너리(2진) 포메터 생성
        BinaryFormatter bf = new BinaryFormatter();
        //파일 생성(쓰기용으로 열기) (Asset폴더에 Save.dat파일)
        FileStream file = new FileStream(Application.dataPath + "Save.dat", FileMode.Create);

        //데이터를 2진화시켜 저장
        bf.Serialize(file, GlobalVariable.data);

        Debug.Log("저장 완료");

        //파일 닫기
        file.Close();
    }

    //모든 데이터 로드
    public void LoadAll()
    {
        //이진변환기
        BinaryFormatter bf = new BinaryFormatter();
        //파일(읽기용으로)선언
        FileStream file = new FileStream(Application.dataPath + "Save.dat", FileMode.Open);

        //파일이 있으며 내용이 있을때
        if(file != null && file.Length > 0)
        {
            GlobalVariable.data = (Data)bf.Deserialize(file);

            Debug.Log("로드 완료");
        }

        //파일 닫기
        file.Close();

    }
    void Awake()
    {
        LoadAll();
    }
}