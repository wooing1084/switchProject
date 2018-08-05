using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class title : MonoBehaviour {

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Click()
    {
        SceneManager.LoadScene(1);
    }
}