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

    private bool moveCheck() {
        int deltaX = Math.Abs(start.getRow() - dest.getRow());
        int deltaY = Math.Abs(start.getCol() - dest.getCol());

        if (deltaX == 1 && deltaY == 1) {
            return true;
        }
        return false;
    }

    //make a bool, should not call turnswitch
    private void Move () {
        //Empty square
        if (dest.getColour() == 0 && moveCheck()) {
            Debug.Log("Player " + gameManager.getTurn() +  " Move their piece moved to an empty square");
            dest.showPiece(start.getColour());
            start.showPiece(0);
            gameManager.turnSwitch();
        }

        Undo();
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
                    Move();
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
