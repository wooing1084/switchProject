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

    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("Player");
    }

    void Awake()
    {
        fade = GetComponent<Image>();
    }

    void Update()
    {
        if (ball.activeSelf == false)
        {
            PlayFadeIn();
        }
    }

    void PlayFadeIn()
    {
        time += Time.deltaTime;
        Color color = fade.color;
        color.a = Mathf.Lerp(start, end, time * 2);
        fade.color = color;
        if (color.a == 1f)
        {
            SceneManager.LoadScene(2);
        }
    }
}