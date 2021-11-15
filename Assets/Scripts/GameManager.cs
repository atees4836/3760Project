using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;

	public Board board;

	private Player red;
	private Player black;
	private int curPlayer = 2;

	public GameObject blackPiece;
	public GameObject redPiece;

	void Awake()
	{
		instance = this;
	}

	// Set Players on start
    void Start()
    {
    	red = new Player("red", 1);
    	black = new Player("black", 2);

    	Debug.Log("It is player " + curPlayer + "'s turn.");

    	SetUp();
    }

	// Sets board to start state
    private void SetUp()
	{
    	board.InitBoard();
    }

	// Switches player turn 
    public void TurnSwitch()
	{
    	if (curPlayer == 1)
		{
    		curPlayer = 2;
    	}
		else if (curPlayer == 2)
		{
    		curPlayer = 1;
    	}
    	Debug.Log("It is player " + curPlayer + "'s turn.");
    }

	// Return current player
    public int GetTurn()
	{
    	return curPlayer;
    }
    
	public void EndGame()
	{
		Debug.Log("No legal moves remain");
	}
}
