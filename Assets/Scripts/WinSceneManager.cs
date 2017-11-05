using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class WinSceneManager : MonoBehaviour {

    public Text winText;
    public int waitTime;
    public int waitCount;
	// Use this for initialization
	void Start () {
        int winnerNum = GameObject.Find("Persistant").GetComponent<TitleScreen>().winnerNum;
        winText.text = "Player " + winnerNum + "  Wins!!!";
        waitCount = 0;
    }
	
	// Update is called once per frame
	void Update () {
		if (waitCount >= waitTime)
        {
            SceneManager.LoadScene("TitleScreen");
        }
        waitCount++;
	}
}
