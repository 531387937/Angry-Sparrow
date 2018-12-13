using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOVer : MonoBehaviour {
    public int nextLevel;
    public int[] ScoreLevel;
    public GameObject[] Star;
    private void OnEnable()
    {
        int i = SceneManager.GetActiveScene().buildIndex;
       
        if (ScoreCtr.score >= ScoreLevel[2])
        {
            PlayerPrefs.SetInt("Level" + i, 3);
        }
        if(ScoreCtr.score>=ScoreLevel[1]&&ScoreCtr.score<ScoreLevel[2])
        {
            if(PlayerPrefs.GetInt("Level"+i)>=2)
            {
                return;
            }
            PlayerPrefs.SetInt("Level" + i, 2);
            Star[2].SetActive(false);
        }
        if (ScoreCtr.score >= ScoreLevel[0] && ScoreCtr.score < ScoreLevel[1])
        {
            if (PlayerPrefs.GetInt("Level" + i) >= 1)
            {
                return;
            }
            PlayerPrefs.SetInt("Level" + i, 1);
            Star[2].SetActive(false);
            Star[1].SetActive(false);
        }
    }
    public void LoadNext()
    {
        ScoreCtr.score = 0;
        SceneManager.LoadScene(nextLevel);
    }
    public void ReLoad()
    {
        ScoreCtr.score = 0;
        SceneManager.LoadScene(nextLevel-1);
    }
}
