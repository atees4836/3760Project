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
	private int col, row;
	private bool clicked = false;

    public void Init (bool isOdd, int col, int row) {
    	_renderer.color = isOdd ? _offsetColor : _baseColor;
    	this.col = col;
    	this.row = row;
    }


    //red = 0, black = 1
    public void showPiece(int colour) {
    	if (colour == 0) {
    		redPiece.SetActive(true);
    	} else if (colour == 1) {
    		blackPiece.SetActive(true);
    	}
    }

    public void setClicked(bool clicked) {
    	this.clicked = clicked;
    }

    public bool getClicked() {
    	return clicked;
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
