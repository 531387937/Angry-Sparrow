using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdCtr : MonoBehaviour {
    public GameObject bird;
    public GameObject[] birds;
    private int birdNum;
    public GameObject[] enemys;
    private int enemyNum=0;
    public int beaten=0;
    private bool gameOver = false;
    public GameObject win;
    public GameObject lose;
    public GameObject gameCtr;
	// Use this for initialization
	void Awake () {
		for(int i=0;i<birds.Length;i++)
        {
           birds[i]= Instantiate(bird, this.transform.position + new Vector3(-1.5f * i, 0, 0), this.transform.rotation);
        }
        birdNum = birds.Length;
        enemys = GameObject.FindGameObjectsWithTag("Enemy");
        enemyNum = enemys.Length;
	}
	
	// Update is called once per frame
	void Update () {
		if(beaten==enemys.Length&&gameOver==false)
        {
            
            Victory();birds = null;
        }
        if(birds[birdNum-1]==null&&gameOver ==false)
        {
            birds = null;
            Defeat();
        }
	}
    void Victory()
    {
        gameOver = true;
        for(int i=0;i<birds.Length;i++)
        {
            if(birds[i]!=null&&birds[i].GetComponent<Fire>().Fired==false)
            {
                ScoreCtr.score += 10000;
            }
            StartCoroutine(WinWait());
        }
    }
    void Defeat()
    {
        lose.SetActive(true);
    }
    IEnumerator WinWait()
    {
        yield return new WaitForSeconds(3);
        gameCtr.SetActive(true);
    }
}
