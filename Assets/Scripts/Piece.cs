using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PieceAttributes;

namespace PieceAttributes {
	public enum PieceType {King, Normal};
	public enum Colour {Red, Black};
}

public abstract class Piece : MonoBehaviour
{
    protected PieceType type;
    protected Colour colour;

	public abstract Colour getColour();

	public abstract void setColour(Colour colour);

	public abstract PieceType getPieceType();

	public abstract void setPieceType(PieceType pieceType);
}