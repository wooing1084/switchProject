using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinFst : MonoBehaviour {

    private SpriteRenderer spriterenderer;
    public Sprite[] sprites = new Sprite[10];
    /*int sum1 = GlobalVariable.coin;   
    int sum2 = GlobalVariable.coin;
    int sum3 = GlobalVariable.coin;*/
    int sum1 = 12;   
    int sum2 = 12;
    int sum3 = 12;
    int s1, s2, s3;
    // Use this for initialization
    void Start () {
        spriterenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        s1 = sum1 / 100;
        s2 = sum2 / 10;
        s3 = sum3 / 1;
		if(s1 == 0)
        {
            if(s2 == 0)
            {
                if(s3 == 0)
                {
                    spriterenderer.sprite = sprites[0];
                }
                else
                {
                    spriterenderer.sprite = sprites[s3];
                }
            }
            else
            {
                spriterenderer.sprite = sprites[s2];
            }
        }
        else
        {
            spriterenderer.sprite = sprites[s1];
        }
	}
}
