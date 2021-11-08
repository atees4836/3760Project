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

	// Initialises Tile
    public void Init (bool isOdd, int col, int row)
	{
    	_renderer.color = isOdd ? _offsetColor : _baseColor;
    	this.col = col;
    	this.row = row;
    }


    // Places piece on tile: red = 1, black = 2
    public void ShowPiece(int colour)
	{
    	if (colour == 0) {
    		pieceColour = 0;
      		redPiece.SetActive(false);
      		blackPiece.SetActive(false);  		
    	} 
		else if (colour == 1)
		{
    		pieceColour = 1;
    		redPiece.SetActive(true);
    	} 
		else if (colour == 2)
		{
    		pieceColour = 2;
    		blackPiece.SetActive(true);
    	}
    }

	// Sets tile clicked state
    public void SetClicked(bool clicked)
	{
    	this.clicked = clicked;
    }

	// Returns tile clicked state
    public bool GetClicked()
	{
    	return clicked;
    }

	// Returns tile column
    public int GetCol()
	{
    	return col;
    }

	// Returns tile row
    public int GetRow() 
	{
    	return row;
    }

	// Sets piece colour
    public void SetColour(int colour) 
	{
    	pieceColour = colour;
    }

	// Returns piece colour
    public int GetColour()
	{
    	return pieceColour;
    }

	// Sets highlight state to true
    public void Highlight()
	{
    	_highlight.SetActive(true); 	
    }

	// Sets highlight state to false
    public void Unhighlight()
	{
    	_highlight.SetActive(false);  
    }

	// Sets highlight on when mouse is over tile
    void OnMouseEnter()
	{
    	_highlight.SetActive(true);
    }

	// Sets clicked when tile is clicked
    void OnMouseDown() 
	{
    	clicked = true;
    }

	// Sets highlight off when mouse leaves tile
    void OnMouseExit() 
	{
    	_highlight.SetActive(false);    	
    }
}
