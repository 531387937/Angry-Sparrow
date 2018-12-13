using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour {
    public float FireForce;
    public float ForceRise;
    public Transform firPos;
    private Vector3 Pos;
    private Vector3 FireDir;
   public float ForceMax;
    private float Forcee;
    private Rigidbody2D rig;
    public Camera ca;
    public bool Fired=false;

    public LineRenderer LeftLineRenderer;  //左线组件
    public Transform LeftPos;           //弹弓左定点
    public LineRenderer RightLineRenderer; //右线组件
    public Transform RightPos;          //弹弓右定点
    private void OnEnable()
    {
        firPos = GameObject.FindGameObjectWithTag("FirePos").transform;
        rig = GetComponent<Rigidbody2D>();
        ca = GameObject.Find("Camera").GetComponent<Camera>();
        transform.position = firPos.position;
        LeftPos = GameObject.Find("Left").transform;
        LeftLineRenderer = LeftPos.gameObject.GetComponent<LineRenderer>();
        RightPos = GameObject.Find("Right").transform;
        RightLineRenderer = RightPos.gameObject.GetComponent<LineRenderer>();
    }
    // Use this for initialization
    void Start () {
        rig = GetComponent<Rigidbody2D>();
        ca = GameObject.Find("Camera").GetComponent<Camera>();
        transform.position = firPos.position;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        Pos = ca.WorldToScreenPoint(firPos.position);
        if (Input.GetMouseButton(0)&&!Fired)
        {transform.position =ca.ScreenToWorldPoint(Input.mousePosition);
            FireDir = (-Input.mousePosition + Pos).normalized;
            ca.GetComponent<CamerFol>().enabled = false;
            transform.position +=new Vector3(0,0,10);
            if (Vector3.Distance(firPos.position, transform.position) >= 1.5f)
            {
                Vector3 pos = (transform.position - firPos.position).normalized;
                pos = pos *1.5f;
                transform.position = pos + firPos.position;
            }            
            FireForce = Vector3.Distance(Input.mousePosition, Pos) * ForceRise;
            if(FireForce>=ForceMax)
            {
                FireForce = ForceMax;
            }
            SlingShort();
        }
        if(Input.GetMouseButtonUp(0)&&!Fired)
        {
            ca.GetComponent<CamerFol>().enabled = true;
            rig.bodyType = RigidbodyType2D.Dynamic;
            rig.AddForce(new Vector2(FireDir.x, FireDir.y) * FireForce);
            Fired = true;
            ca.GetComponent<CamerFol>().enabled = true;
        }
        if(Fired)
        {
            GetComponent<Disappear>().enabled = true;
            RightLineRenderer.enabled = false;
            LeftLineRenderer.enabled = false;
        }
	}
    void SlingShort()
    {
        RightLineRenderer.enabled = true;
        LeftLineRenderer.enabled = true;
        RightLineRenderer.SetPosition(0, RightPos.position);
        RightLineRenderer.SetPosition(1, transform.position);
        LeftLineRenderer.SetPosition(0, LeftPos.position);
        LeftLineRenderer.SetPosition(1, transform.position);
    }
}
