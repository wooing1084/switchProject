using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CheckAlphaData : MonoBehaviour {

    private Image fade;
    private GameObject fade2;
    private float alphaData;

    void Awake () {
        fade = GetComponent<Image>();
        fade2 = GameObject.FindGameObjectWithTag("UI");
    }
	
	void Update () {
        Color color = fade.color;
        alphaData = color.a;
        if (alphaData == 0f && SceneManager.GetActiveScene().buildIndex==2)
        {
            fade2.SetActive(false);
        }
    }
}
