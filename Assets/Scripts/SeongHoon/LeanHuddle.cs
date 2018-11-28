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

    public void SetRotate(GameObject me,float Maxangle,float MinAngle)
    {
        if (Maxangle >= 20)
            Maxangle = 20.0f;
        else if (MinAngle <= -20.0f)
            MinAngle = -20.0f;

        float angle = Random.Range(MinAngle, Maxangle);


        me.transform.Rotate(0, 0, angle, Space.World);
    }
}
