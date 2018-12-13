using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlingShoot : MonoBehaviour {
    public LineRenderer LeftLineRenderer;  //左线组件
    public Transform LeftPos;           //弹弓左定点
    public LineRenderer RightLineRenderer; //右线组件
    public Transform RightPos;          //弹弓右定点
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void SlingShort()
    {
        //给弹弓划线
        RightLineRenderer.enabled = true;
        LeftLineRenderer.enabled = true;
        RightLineRenderer.SetPosition(0, RightPos.position);
        RightLineRenderer.SetPosition(1, transform.position);
        LeftLineRenderer.SetPosition(0, LeftPos.position);
        LeftLineRenderer.SetPosition(1, transform.position);
    }
}
