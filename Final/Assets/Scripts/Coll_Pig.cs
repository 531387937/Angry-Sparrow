using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coll_Pig : Coll {
    public Sprite pigs;
	// Use this for initialization
	void Start () {
		Hp = HpMax;
        Sp = this.GetComponent<SpriteRenderer>();
	}

}
