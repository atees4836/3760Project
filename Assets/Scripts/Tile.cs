using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* The tile class represents a single square on the board. It is responsible for keeping track of its own coordinates, colour,
   and wheher or not a piece occupying it. Pieces and highlights are implemented as layers in the Unity editor. */

public class Tile : MonoBehaviour
{

	[SerializeField] private Color _offsetColor, _baseColor;
	[SerializeField] private SpriteRenderer _renderer;
	[SerializeField] private GameObject _highlight; 

	[SerializeField] private GameObject redPiece;
	[SerializeField] private GameObject blackPiece;
	[SerializeField] private GameObject redKing;
	[SerializeField] private GameObject blackKing;	

	private int col, row, pieceColour;
	private bool clicked = false;
	private bool isKing = false;

	//Creates a tile with given colour and coordinates
    public void Init (bool isOdd, int col, int row) {
    	_renderer.color = isOdd ? _offsetColor : _baseColor;
    	this.col = col;
    	this.row = row;
    }


    //Tells the piece what it should rendeer. no piece = 0, red = 1, black = 2
    public void showPiece(int colour) {
    	if (colour == 0) {
    		pieceColour = 0;
      		redPiece.SetActive(false);
      		redKing.SetActive(false);
      		blackPiece.SetActive(false); 
      		blackKing.SetActive(false);
    	} else if (colour == 1) {
    		pieceColour = 1;
    		if (isKing) {
    			redKing.SetActive(true);
    		} else {
    			redPiece.SetActive(true);
    		}
    	} else if (colour == 2) {
    		pieceColour = 2;
    		if (isKing) {
    			blackKing.SetActive(true);
    		} else {
    			blackPiece.SetActive(true);
    		}
    	}
    }

    //Highlights the tile manually
    public void highLight() {
    	_highlight.SetActive(true); 	
    }

    //Removes highlight manually
    public void unHighLight() {
    	_highlight.SetActive(false);  
    }

    //Various getters and setters for tile attributes

    public bool getClicked() {
    	return clicked;
    }

    public void setClicked(bool clicked) {
    	this.clicked = clicked;
    }

    public int getCol() {
    	return col;
    }

    public int getRow() {
    	return row;
    }

    public int getColour() {
    	return pieceColour;
    }

    public void setColour(int colour) {
    	pieceColour = colour;
    }

    public bool getKing() {
    	return isKing;
    }

    public void setKing() {
    	isKing = true;
    }

    //Implemented mouse functions
    void OnMouseEnter () {
    	_highlight.SetActive(true);
    }

    void OnMouseDown() {
    	clicked = true;
    }

    void OnMouseExit () {
    	_highlight.SetActive(false);    	
    }
}
