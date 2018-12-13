using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MeunCtr : MonoBehaviour {
    public GameObject Choose;
    public GameObject[] Hide;
    private void Awake()
    {
        
    }
    public void CHooseLevel()
    {
        Choose.SetActive(true);
        foreach(GameObject hide in Hide)
        {
            hide.SetActive(false);
        }
    }
    public void Switch_Level(int i)
    {
        SceneManager.LoadScene(i);
    }
}
