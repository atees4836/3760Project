using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

	public static GameManager instance;

	public Board board;

	private Player red;
	private Player black;
	private int curPlayer = 1;

	public GameObject blackPiece;


	void Awake() {
		instance = this;
	}

    void Start()
    {
    	red = new Player("red", 1);
    	black = new Player("black", 2);

    	Debug.Log("It is player " + curPlayer + "'s turn.");

    	setup();
    }

    private void setup() {
    	board.AddPiece(blackPiece, black, -500, 500);
    }

    public void turnSwitch() {
    	if (curPlayer == 1) {
    		curPlayer = 2;
    	} else if (curPlayer == 2) {
    		curPlayer = 1;
    	}
    	Debug.Log("It is player " + curPlayer + "'s turn.");
    }
    
}
