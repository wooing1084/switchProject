using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeScript : MonoBehaviour
{
    private Image fade;
    GameObject ball;

    private float start = 0f;
    private float end = 1f;
    private float time = 0f;
    private int playCount = 1;

    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Player");
        playCount = 1;
    }

    void Awake()
    {
        fade = GetComponent<Image>();
    }

    void Update()
    {
        if (ball.activeSelf == false)
        {
            PlayFadeOut();
        }

        if(playCount == 1)
        {
            PlayFadeIn();
        }
    }

    void PlayFadeOut()
    {
        time += Time.deltaTime;
        Color color = fade.color;
        color.a = Mathf.Lerp(start, end, time);
        fade.color = color;
        if (color.a == 1f)
        {
            SceneManager.LoadScene(2);
        }
    }

    void PlayFadeIn()
    {
        time += Time.deltaTime;
        Color color = fade.color;
        color.a = Mathf.Lerp(1f, 0f, time);
        fade.color = color;
        if (time > 1.0f)
        {
            playCount = 0;
            time = 0f;
        }
    }
}