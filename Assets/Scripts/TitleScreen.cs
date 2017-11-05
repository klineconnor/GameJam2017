using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreen : MonoBehaviour {

	void Awake()
	{
		DontDestroyOnLoad(gameObject);
	}
	public int numPlayers = 0;

	public void setPlayers(int num)
	{
		numPlayers = num;
	}
}
