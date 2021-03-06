﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Coll : MonoBehaviour {
    public float HpMax;
    public float Hp;
    private Vector2 vel;
    public SpriteRenderer Sp;
    public BirdCtr BC;
    // Use this for initialization
    void Start () {
        BC = GameObject.Find("Birds").GetComponent<BirdCtr>();
       
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Rigidbody2D>()==null)
        {
            return;
        }
        if (collision.gameObject.tag == "bird")
        { vel = collision.gameObject.GetComponent<Rigidbody2D>().velocity; }
        float recive = collision.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude;
        if(recive<=0)
        {
            return;
        }
        float damage = recive * 15;
        print(this.gameObject.name+damage);
        Hp = Hp - damage;
        if (Hp <= 0)
        {
            //if (collision.gameObject.tag == "bird")
            //{ collision.gameObject.GetComponent<Rigidbody2D>().velocity=vel*0.75f; }
            if(this.gameObject.tag=="Enemy")
            {
            BC.beaten++;
                ScoreCtr.score += 5000;
            }
            else
            {
                ScoreCtr.score += 500;
            }
            Destroy(this.gameObject);
        }
    }
}
