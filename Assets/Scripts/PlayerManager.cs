using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

	public static GameManager instance;

	void Awake()
	{
		instance = this;
	}

	int PlayerAmount;

	public void setPlayerAmount(int amount)
	{
		PlayerAmount = amount;
	}

	public int getPlayerAmount()
	{
		return PlayerAmount;
	}
}
