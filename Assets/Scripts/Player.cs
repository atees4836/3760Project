using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
{
    public string name;
    public int playerNum;
    private int numPieces;


    public Player(string name, int playerNum) {
    	this.name = name;

    	//player 1 = red, player 2 = black
    	this.playerNum = playerNum; 
        numPieces = 12;
    }

    public void SetNumPieces(int num) {
        this.numPieces = num;
    }

    public int GetNumPieces() {
        return this.numPieces;
    }
}
