using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ScoreCtr : MonoBehaviour {
    public static int score=0;
    private Text te;
	// Use this for initialization
	void Start () {
        te=GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        te.text = "Score:  " + score;
	}
}
