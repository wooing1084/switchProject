using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WideHuddlePatern : MonoBehaviour {

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetHeight(GameObject beforeObject, float range)
    {
        Vector3 pos = this.transform.position;
        float min = beforeObject.transform.position.y - range;
        float max = beforeObject.transform.position.y + range;
        if (min < -5.0)
            min = -5.0f;
        if (max > 0.0f)
            max = 0.0f;
        pos.y = Random.Range(min, max);
        this.transform.position = pos;
    }

    public void SetWidth(GameObject me, float widthRange)
    {
        Vector3 scaleVec = this.transform.localScale;
        float min = 1;
        float max = 1 + widthRange;
        if (max > 5.0f)
            max = 5.0f;
        scaleVec.x = Random.Range(min, max);
        scaleVec.y = 6;
        scaleVec.z = 1;
       // me.
        me.transform.localScale = scaleVec;
    }
}
