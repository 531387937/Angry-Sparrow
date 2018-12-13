using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coll_Glass : Coll {
    public Sprite[] glasses;
    public int heat;
    public int broken;
    private float stage1;
    private float stage2;
    private float stage3;
    private bool plus1=false;
    private bool plus2=false;
    private bool plus3=false;
    // Use this for initialization
    void Start () {
        Hp = HpMax;
        stage1 = HpMax / 4 * 3;
        stage2 = HpMax / 2;
        stage3 = HpMax / 4;
        Sp = this.GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
		if(Hp>stage1)
        {
            Sp.sprite = glasses[0];
        }
        else if(Hp>stage2&&Hp<=stage1&&!plus1)
        {
            ScoreCtr.score += heat;
            Sp.sprite = glasses[1];
            plus1 = true;
        }
        else if (Hp > stage3 && Hp <= stage2&&!plus2)
        {
            ScoreCtr.score += heat;
            Sp.sprite = glasses[2];
            plus2 = true;
        }
        else if (Hp <=stage3&&plus3)
        {
            ScoreCtr.score += heat;
            Sp.sprite = glasses[3];
            plus3 = true;
        }
    }
}
