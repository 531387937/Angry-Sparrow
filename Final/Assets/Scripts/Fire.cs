using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {
    public float FireForce;
    public float ForceRise;
    private Vector3 Pos;
    private Vector3 FireDir;
   public float ForceMax;
    private float Forcee;
    private Rigidbody2D rig;
    public Camera ca;
    public bool Fired=false;
	// Use this for initialization
	void Start () {
        rig = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        Pos = ca.WorldToScreenPoint(transform.position);
        if (Input.GetMouseButton(0))
        {
            FireDir = (-Input.mousePosition + Pos).normalized;
            FireForce = Vector3.Distance(Input.mousePosition, Pos) * ForceRise;
            if(FireForce>=ForceMax)
            {
                FireForce = ForceMax;
            }
        }
        if(Input.GetMouseButtonUp(0))
        {
            rig.AddForce(new Vector2(FireDir.x, FireDir.y) * FireForce);
            Fired = true;
        }
        if(Fired)
        {
            GetComponent<Disappear>().enabled = true;
        }
	}
}
