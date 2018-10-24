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

    public void SetHeight(GameObject me,GameObject beforeObject, float range)
    {
        Vector3 pos = me.transform.position;
        float min = beforeObject.transform.position.y - range;
        float max = beforeObject.transform.position.y + range;
        if (min < -5.0)
            min = -5.0f;
        if (max > 0.0f)
            max = 0.0f;
        pos.y = Random.Range(min, max);
        me.transform.position = pos;
    }
}
