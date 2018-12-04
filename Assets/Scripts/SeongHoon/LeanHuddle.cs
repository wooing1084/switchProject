using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeanHuddle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetRotate(GameObject me)
    {
        float angle = Random.Range(10.0f, -10.0f);
        
        me.transform.Rotate(0, 0, angle, Space.World);
    }
}
