using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappear : MonoBehaviour {
    private Rigidbody2D rig;
    public bool dis=false;
    public Animator an;
    private bool begin = false;
	// Use this for initialization
	void Start () {
        rig = GetComponent<Rigidbody2D>();
        an=GetComponent<Animator>();
        StartCoroutine(beg());
    }
	
	// Update is called once per frame
	void FixedUpdate () {
		if(rig.velocity.magnitude==0&&begin)
        {
            dis = true;
            an.SetBool("Dis", true);
        }
        if(dis)
        {
            StartCoroutine(disa());
        }
	}
    IEnumerator disa()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject);
    }
    IEnumerator beg()
    {
        yield return new WaitForSeconds(1.5f);
        begin = true;
    }
}
