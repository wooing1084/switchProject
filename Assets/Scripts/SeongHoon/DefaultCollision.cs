using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultCollision : MonoBehaviour
{

    public ParticleSystem Blueblast;

    GameObject ball;


    public int Getcomponent { get; private set; }
    public int Sphere { get; private set; }

    // Use this for initialization
    void Start()
    {

        ball = GameObject.FindGameObjectWithTag("Player");
    }


    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject == ball)
        {
            UnityEngine.Debug.Log("벽과 충돌");

            //게임오버 씬 전환부분

            Blueblast.transform.position = ball.transform.position;
            //볼이 장애물의 위치에 닿았을 때, 닿은 위치를 파티클 위치에 담는다.
            Blueblast.Play();

            ball.SetActive(false);
            //공 사라짐



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
    void Update()
    {
    }
}