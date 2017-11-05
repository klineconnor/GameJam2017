using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScreen : MonoBehaviour {


	public int numPlayers = 0;

	void Awake()
	{
		DontDestroyOnLoad(gameObject);
	}

	public void setPlayers(int num)
	{
		print ("SetPlayer" + num);
		numPlayers = num;
	}
}
