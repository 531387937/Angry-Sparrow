using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamLimt : MonoBehaviour {
    public float xMax;
    public float xMin;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (this.transform.position.x >= xMax)
            transform.position = new Vector3(xMax, transform.position.y, transform.position.z);
        if (this.transform.position.x <= xMin)
            transform.position = new Vector3(xMin, transform.position.y, transform.position.z);
    }
}
