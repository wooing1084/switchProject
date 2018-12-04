using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultSetHeight : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetHeight(GameObject me,float beforeHuddleY, float range,float dis)
    {
        Vector3 pos = me.transform.position;
        float min = beforeHuddleY - range;
        float max = beforeHuddleY + range;
        //최대 -2, 최소 -5
        if (max > -2.0f)
            max = -2.0f;
        if (min < -5.0f)
            min = -5.0f;
        pos.y = Random.Range(min, max);
        me.transform.position = pos;
    }
}
