using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamCtr : MonoBehaviour {
    private Camera ca;
    
	// Use this for initialization
	void Start () {
        ca = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetAxisRaw("Mouse ScrollWheel")<0)
        {
            if (ca.orthographicSize < 5.3)
                ca.orthographicSize += 0.1f;
            else
                return;
        }
        if (Input.GetAxisRaw("Mouse ScrollWheel") > 0)
        {
            if (ca.orthographicSize > 2.9)
                ca.orthographicSize -= 0.1f;
            else
                return;
        }
        if(Input.GetMouseButton(1))
        {
            if(Input.GetAxisRaw("Mouse X")>0)
            {

            }
        }
    }
}
