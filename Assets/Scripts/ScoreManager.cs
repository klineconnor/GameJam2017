using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour {

    public int[] scores;
    public float[] healths;

    public GameObject winPanel;
    public Text winText;
    public Text[] HealthTexts;
    public Text[] ScoreTexts;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i <= 3; i++)
        {
            HealthTexts[i].text = "Health: " + healths[i];
        }
        for (int i = 0; i <= 3; i++)
        {
            ScoreTexts[i].text = "P" + (i+1)+ " Score: " + scores[i];
        }
    }

    public void UpdateScore(int playerNum, int score)
    {
        scores[playerNum-1] += score;
        if (scores[playerNum-1] >= 10)
        {
            DisplayWinner(playerNum);
        }
    }

    public void UpdateHealth(int playerNum, float health)
    {
        healths[playerNum-1] =health;
    }
    public void DisplayWinner(int winnerNum)
    {
        winPanel.SetActive(true);
        winText.text = "Player " + winnerNum + "  Wins!!!";
        GameObject.Find("Persistant").GetComponent<TitleScreen>().winnerNum = winnerNum;
        SceneManager.LoadScene("WinScene");
    }
}
