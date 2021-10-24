using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PieceAttributes;

public class GameManager : MonoBehaviour
{

	public static GameManager instance;

	public Board board;

	private Player red;
	private Player black;
	private int curPlayer = 1;

	public GameObject blackPiece;
	public GameObject redPiece;
	
	[SerializeField] private Tile tile;


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

    	for (int i = 0; i < 4; i++) {
    		for (int j = 0; j < 3; j++) {
    			if (j == 1) {
    				board.AddPiece(blackPiece, black, 150 + (i * 200), 840 - (j * 100));
    				board.AddPiece(redPiece, red, 50 + (i * 200), 340 - (j * 100));
    			} else {
    				board.AddPiece(blackPiece, black, 50 + (i * 200), 840 - (j * 100));
    		    	board.AddPiece(redPiece, red, 150 + (i * 200), 340 - (j * 100));	
    			}
    		}
    	}

    	for (int i = 0; i < 8; i++) {
    		for (int j = 0; j < 8; j++) {
    			var newTile = Instantiate(tile, new Vector3 (50 + (i * 100), 840 - (j * 100)), Quaternion.identity);
    			newTile.name = $"tile {i} {j}";

    			var isOdd = (i % 2 == 0 && j % 2 != 0) || (i % 2 != 0 && j % 2 == 0); 
    			newTile.Init(isOdd);
    		}
    	}
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
