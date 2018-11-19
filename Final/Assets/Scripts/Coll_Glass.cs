using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coll_Glass : Coll {
    public Sprite[] glasses;
	// Use this for initialization
	void Start () {
        Hp = HpMax;
        Sp = this.GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
		if(Hp>75)
        {
            Sp.sprite = glasses[0];
        }
        else if(Hp>50&Hp<=75)
        {
            Sp.sprite = glasses[1];
        }
        else if (Hp > 25 & Hp <= 50)
        {
            Sp.sprite = glasses[2];
        }
        else if (Hp <=25)
        {
            Sp.sprite = glasses[3];
        }
    }
}
