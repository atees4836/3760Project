using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    GameManager gameManager;

    private Tile[,] grid = new Tile[8, 8];
    private Tile start;
    private Tile dest; 
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

    private void Move () {
        dest.showPiece(start.getColour());
        start.showPiece(0);

        Undo();
    }

    private void Undo () {
        start.setClicked(false);
        start = null;

        if (dest != null) {
            dest.setClicked(false);
            dest = null;
        }

    }

    void Update() {
        if(Input.GetMouseButtonDown(0)) {
            if (start == null) {
                start = getSelectedTile();
                if (start.getColour() != gameManager.getTurn()) {
                    Debug.Log("Not your turn.");
                    Undo();
                } else { 
                    Debug.Log("" + start.getCol() + " " + start.getRow() + " chosen as start position.");
                }
            } else if (start != null) {
                dest = getSelectedTile();
                if (dest != null) {
                    Debug.Log("" + dest.getCol() + " " + dest.getRow() + " chosen as end position.");
                    Move();
                    gameManager.turnSwitch();
                } else {
                    Undo();
                }
            }
        }
    }

}
