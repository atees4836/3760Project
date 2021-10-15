using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PieceAttributes;

public class Normal : Piece
{

	public void print() {
		Debug.Log("Poopoosus");
	}

	public override Colour getColour() {
		return colour;
	}

	public override void setColour(Colour colour) {
		this.colour = colour;
	}

	public override PieceType getPieceType() {
		return type;
	}

	public override void setPieceType(PieceType pieceType) {
		this.type = pieceType;
	}

}
