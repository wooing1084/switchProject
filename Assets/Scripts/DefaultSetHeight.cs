using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultSetHeight : MonoBehaviour {

    public GameObject beforeObject;
    public float range;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetHeight()
    {
        Vector3 pos = this.transform.position;
        float min = beforeObject.transform.position.y - range;
        float max = beforeObject.transform.position.y + range;
        if (min < 0)
            min = 0;
        if (max > 5.0f)
            max = 5.0f;
        pos.y = Random.Range(min, max);
        this.transform.position = pos;
    }
}
