using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{

	[SerializeField] private Color _offsetColor, _baseColor;
	[SerializeField] private SpriteRenderer _renderer;
	[SerializeField] private GameObject _highlight; 
	[SerializeField] private GameObject redPiece;
	[SerializeField] private GameObject blackPiece;
	private int col, row, pieceColour;
	private bool clicked = false;

    public void Init (bool isOdd, int col, int row) {
    	_renderer.color = isOdd ? _offsetColor : _baseColor;
    	this.col = col;
    	this.row = row;
    }


    //red = 1, black = 2
    public void showPiece(int colour) {
    	if (colour == 0) {
    		pieceColour = 0;
      		redPiece.SetActive(false);
      		blackPiece.SetActive(false);  		
    	} else if (colour == 1) {
    		pieceColour = 1;
    		redPiece.SetActive(true);
    	} else if (colour == 2) {
    		pieceColour = 2;
    		blackPiece.SetActive(true);
    	}
    }

    public void setClicked(bool clicked) {
    	this.clicked = clicked;
    }

    public bool getClicked() {
    	return clicked;
    }

    public int getCol() {
    	return col;
    }

    public int getRow() {
    	return row;
    }

    public void setColour(int colour) {
    	pieceColour = colour;
    }

    public int getColour() {
    	return pieceColour;
    }

    public void highLight() {
    	_highlight.SetActive(true); 	
    }

    public void unHighLight() {
    	_highlight.SetActive(false);  
    }

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
