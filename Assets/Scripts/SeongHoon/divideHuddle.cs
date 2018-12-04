using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class divideHuddle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void divide(GameObject stdHuddle, GameObject dividedHuddle,float maxDis,float minDis,bool stdIsParent)
    {
        float dis = Random.Range(minDis, maxDis);
        if (stdIsParent)
        {            
            Vector3 pos = dividedHuddle.transform.position;
            pos.x = stdHuddle.transform.position.x + dis;
            dividedHuddle.transform.position = pos;
        }
        else
        {
            Vector3 pos = stdHuddle.transform.localPosition;
            pos.x -= dis;
            stdHuddle.transform.localPosition = pos;
            pos = dividedHuddle.transform.position;
            pos.x += dis;
            dividedHuddle.transform.position = pos;
        }
    }
}
