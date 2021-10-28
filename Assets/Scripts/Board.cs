using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{

    private Tile[,] grid = new Tile[8, 8];
    [SerializeField] private Tile tile;

    public void initBoard() {
        for (int i = 0; i < 8; i++) {
            for (int j = 0; j < 8; j++) {
                var newTile = Instantiate(tile, new Vector3 (50 + (i * 100), 840 - (j * 100)), Quaternion.identity);
                newTile.name = $"tile {i} {j}";

                if (j < 3) {
                    if ((i % 2 != 0 && j % 2 != 0) || (i % 2 == 0 && j % 2 == 0)) {
                        newTile.showPiece(0);
                    }
                } else if (j > 4) {
                    if ((i % 2 != 0 && j % 2 != 0) || (i % 2 == 0 && j % 2 == 0)) {
                        newTile.showPiece(1);
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

    void Update() {
        if(Input.GetMouseButtonDown(0)) {
            Debug.Log("Board click");
        }
    }

}
