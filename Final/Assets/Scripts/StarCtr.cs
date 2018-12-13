using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCtr : MonoBehaviour {
    public GameObject Star;
    public int level;
	// Use this for initialization
	void Start () {
        Star.SetActive(true);
        int s = PlayerPrefs.GetInt("Level" + level);
        switch(s)
        {
            case 3:
                break;
            case 2:
                Star.transform.GetChild(0).gameObject.SetActive(false);
                break;
            case 1:
                Star.transform.GetChild(0).gameObject.SetActive(false);
                Star.transform.GetChild(1).gameObject.SetActive(false);
                break;
            case 0:
                Star.SetActive(false);
                break;
        }
	}

}
