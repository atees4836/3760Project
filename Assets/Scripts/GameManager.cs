using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

	public static GameManager instance;

	private Player red;
	private Player black;
	private int curPlayer = 1;


	void Awake() {
		instance = this;
	}

    void Start()
    {
    	red = new Player("red", 1);
    	black = new Player("black", 2);

    	Debug.Log("It is player " + curPlayer + "'s turn.");
    }

public void print() {
	Debug.Log("Poopoosus");
}
    
}
