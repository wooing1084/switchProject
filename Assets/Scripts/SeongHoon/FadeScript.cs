using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeScript : MonoBehaviour
{
    private Image fade;
    private Text Score;
    GameObject ball;
    GameObject fade2;

    private float time = 0f;
    private int playCount = 1;

    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Player");
        fade2 = GameObject.FindGameObjectWithTag("UI");
        playCount = 1;
    }

    void Awake()
    {
        fade = GetComponent<Image>();
        Score = GetComponent<Text>();
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
        color.a = Mathf.Lerp(0f, 1f, time);
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

        if(color.a == 0f)
        {
            if (fade2.activeSelf == true && SceneManager.GetActiveScene().buildIndex == 0)
            {
                fade2.SetActive(false);
            }

        }
    }
}