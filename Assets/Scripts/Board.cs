using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* The board class stores an array of Tiles which represents the game board. The class hosts functions that render the board
   and implement piece movement/capturing. */

public class Board : MonoBehaviour
{
    GameManager gameManager;

    private Tile[,] grid = new Tile[8, 8];
    private Tile start;
    private Tile dest; 
    private Tile left;
    private Tile right;
    [SerializeField] private Tile tile;

    //Instantiates all 64 tiles and arranges them into the appropriate board. It is called once at the start of each game.
    public void initBoard() {
        gameManager = FindObjectOfType<GameManager>();

        for (int i = 0; i < 8; i++) {
            for (int j = 0; j < 8; j++) {

                //Draw the tile to the screen
                var newTile = Instantiate(tile, new Vector3 (50 + (i * 100), 840 - (j * 100)), Quaternion.identity);
                newTile.name = $"tile {i} {j}";

                //Draw a piece on the appropriate tile
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

                //Alternate black and white
                var isOdd = (i % 2 == 0 && j % 2 != 0) || (i % 2 != 0 && j % 2 == 0); 
                newTile.Init(isOdd, i, j);
            }
        }

    }

    /*Searches the board for a tile that the player has chosen and returns a referance to it.
      Returns null if no such tile exists.*/
    private Tile getSelectedTile() {
        for (int i = 0; i < 8; i++) {
            for (int j = 0; j < 8; j++) {

                //Selects either a start tile, or a destination tile
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

    //Highlights tiles for which a selected pieces may move.
    private void showMoves() {
        int x = start.getCol();
        int y = start.getRow();

        //Search for which tile is valid
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

        //Highlight the selected tiles
        if (left) {
            left.highLight();
        }
        if (right) {
            right.highLight();
        }

    }

    //Helper to decide whether a coordinate is within appropriate bounds
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
            Debug.Log("Player " + gameManager.getTurn() + " Moved their piece moved to an empty square");
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
            kingCheck();
            dest.showPiece(start.getColour());
            start.showPiece(0);
            Undo();
        }
        else{
            kingCheck();
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

    private void kingCheck() {
        if ((dest.getRow() == 7 && start.getColour() == 1) || (dest.getRow() == 0 && start.getColour() == 2) || (start.getKing())) {
            Debug.Log("King event triggered");
            Debug.Log(" " + dest.getCol() + ", " + dest.getRow());
            dest.setKing();
        }
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
        if (start.getKing() == false) {
            if ((start.getColour() == 1) && (deltaX > 0)){
                return false;
            }
            else if ((start.getColour() == 2) && (deltaX < 0)) {
                return false;
            }
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

    //Removes a piece based off of the start and destination positions
    private void removePiece() {
        int captureX = (start.getRow() + dest.getRow())/ 2;
        int captureY = (start.getCol() + dest.getCol()) / 2;

        grid[captureY, captureX].showPiece(0);

        Player p = gameManager.getOppPlayer();
        p.SetNumPieces(p.GetNumPieces() - 1);
        Debug.Log(p.GetNumPieces());

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

    private bool GameOver() {
        Player curPlayer = gameManager.getCurPlayer();
        if(curPlayer == null) {
            return true;
        }
        
        if(curPlayer.GetNumPieces() <= 0) {
            Debug.Log("Current player has no pieces remaining.");
            return true;
        }
        return false;
    }

    void Update() {
        if(GameOver()) {
            gameManager.EndGame();
        }
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

        /*if (start) {
            showMoves();
        }*/

    }

}
