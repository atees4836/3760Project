using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    GameManager gameManager;

    private Tile[,] grid = new Tile[8, 8];
    private Tile start;
    private Tile dest; 
    private Tile left;
    private Tile right;
    [SerializeField] private Tile tile;

    public void initBoard() {
        gameManager = FindObjectOfType<GameManager>();

        for (int i = 0; i < 8; i++) {
            for (int j = 0; j < 8; j++) {
                var newTile = Instantiate(tile, new Vector3 (50 + (i * 100), 840 - (j * 100)), Quaternion.identity);
                newTile.name = $"tile {i} {j}";

                if (j < 3) {
                    if ((i % 2 != 0 && j % 2 != 0) || (i % 2 == 0 && j % 2 == 0)) {
                        newTile.showPiece(1);
                    }
                } else if (j > 4) {
                    if ((i % 2 != 0 && j % 2 != 0) || (i % 2 == 0 && j % 2 == 0)) {
                        newTile.showPiece(2);
                    }
                }

                grid[i,j] = newTile;

                var isOdd = (i % 2 == 0 && j % 2 != 0) || (i % 2 != 0 && j % 2 == 0); 
                newTile.Init(isOdd, i, j);
            }
        }

    }
    
    public GameObject DrawSquare (GameObject prefab, int col, int row) {
    	Vector3 vec = new Vector3 (col, row, -10);
        GameObject newTile = Instantiate(prefab, vec, Quaternion.identity);
        return newTile;
    }

    private Tile getSelectedTile() {
        for (int i = 0; i < 8; i++) {
            for (int j = 0; j < 8; j++) {
                if (start == null && grid[i, j].getClicked()) {
                    return grid[i, j];
                } else {
                    if (grid[i, j].getClicked() && !(start.getCol() == i && start.getRow() == j)) {
                        return grid[i, j];
                    }
                }
            }
        }
        Debug.Log("WARNING NULL TILE");
        return null;
    }

    private void showMoves() {
        int x = start.getCol();
        int y = start.getRow();

        if (gameManager.getTurn() == 1) {
            if (boundCheck(x - 1)) {
            left = grid[x - 1, y + 1];
            }
            if (boundCheck(x + 1)) {
            right = grid[x + 1, y + 1];
            }
        } else if (gameManager.getTurn() == 2) {
            if (boundCheck(x - 1)) {
            left = grid[x - 1, y - 1];
            }
            if (boundCheck(x + 1)) {
            right =grid[x + 1, y - 1]; 
            }
        }

        if (left) {
            left.highLight();
        }
        if (right) {
            right.highLight();
        }

    }

    private bool boundCheck(int coord) {
        if (coord > 0 && coord < 7) {
            return true;
        }
        return false;
    }


    //Checks if selected move is valid 
    private bool Move () {

        bool capture = false;

        //Check if destination tile is empty
        if (checkEmptyTile() == false) {
            Undo();
            return false;
        }
        //Checks movement logic 
        if (checkBasicStep() == true){
            Debug.Log("Player " + gameManager.getTurn() + " Move their piece moved to an empty square");
        }
        else if (checkBasicCapture() == true) {
            capture = true;
        }
        else
        {
            Undo();
            return false;
        }


        if (capture == true){
            removePiece();
            dest.showPiece(start.getColour());
            start.showPiece(0);
            Undo();
        }
        else{
            dest.showPiece(start.getColour());
            start.showPiece(0);
            Undo();
        }
        return true;
    }

    //checks if destination tile is empty
    private bool checkEmptyTile() {
        if (dest.getColour() != 0) {
            Debug.Log("Selected destination tile is already occupied");
            return false;
        }
        return true;
    }

    //Movement check for basic piece moving forward
    private bool checkBasicStep() {

        int deltaX = (start.getRow() - dest.getRow());
        int deltaY = (start.getCol() - dest.getCol());
        //Checks if piece is basic 
        if (start.getColour() != 1 && start.getColour() != 2) {
            return false;
        }
        //Checks if piece is moving by one square
        if (Math.Abs(deltaX) != 1 || Math.Abs(deltaY) != 1) {
            return false;
        }
        //Checks if piece is moving forward 
        if ((start.getColour() == 1) && (deltaX > 0)){
            return false;
        }
        else if ((start.getColour() == 2) && (deltaX < 0)) {
            return false;
        }
        
        return true;
    }

    private bool checkBasicCapture() {
        
        int deltaX = (start.getRow() - dest.getRow());
        int deltaY = (start.getCol() - dest.getCol());
        int captureX = (start.getRow() + dest.getRow())/ 2;
        int captureY = (start.getCol() + dest.getCol()) / 2;
        //Checks if piece is basic 
        if (start.getColour() != 1 && start.getColour() != 2)
        {
            return false;
        }
        //Checks if piece is moving by two squares
        if (Math.Abs(deltaX) != 2 || Math.Abs(deltaY) != 2) {
            return false;
        }
        //Checks if piece is moving forward 
        if ((start.getColour() == 1) && (deltaX > 0))
        {
            return false;
        }
        else if ((start.getColour() == 2) && (deltaX < 0))
        {
            return false;
        }
        //Check for piece to capture
        if ((grid[captureY, captureX].getColour() == start.getColour()) || (grid[captureY, captureX].getColour() == 0)) {
            return false;
        }

        return true;
    }

    private void removePiece() {
        int captureX = (start.getRow() + dest.getRow())/ 2;
        int captureY = (start.getCol() + dest.getCol()) / 2;

        grid[captureY, captureX].showPiece(0);

        return;
    }

    private void Undo () {
        start.setClicked(false);
        start = null;

        if (dest) {
            dest.setClicked(false);
            dest = null;
        }

        if (left) {
            left.unHighLight();
            left = null;
        }
        if (right) {
            right.unHighLight();
            right = null;
        }

    }

    void Update() {
        if(Input.GetMouseButtonDown(0)) {
            if (start == null) {
                start = getSelectedTile();
                if (start.getColour() != gameManager.getTurn()) {
                    Debug.Log("Not your turn.");
                    Undo();
                }
            } else if (start != null) {
                dest = getSelectedTile();
                if (dest != null) {

                    //switch player turn if move is valid
                    if (Move() == true) {
                        gameManager.turnSwitch();
                    }

                } else {
                    Undo();
                }
            }
        }

        if (start) {
            showMoves();
        } 

    }

}
