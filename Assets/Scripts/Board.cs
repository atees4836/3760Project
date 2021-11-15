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
  
    // Sets up game board with pieces
    public void InitBoard() 
    {
        gameManager = FindObjectOfType<GameManager>();

        for (int i = 0; i < 8; i++) 
        {
            for (int j = 0; j < 8; j++) 
            {
                var newTile = Instantiate(tile, new Vector3 (50 + (i * 100), 840 - (j * 100)), Quaternion.identity);
                newTile.name = $"tile {i} {j}";
                // Add pieces to gameboard
                if (j < 3) 
                {
                    if ((i % 2 != 0 && j % 2 != 0) || (i % 2 == 0 && j % 2 == 0)) 
                    {
                        newTile.ShowPiece(1);
                    }
                } else if (j > 4) 
                {
                    if ((i % 2 != 0 && j % 2 != 0) || (i % 2 == 0 && j % 2 == 0)) 
                    {
                        newTile.ShowPiece(2);
                    }
                }

                grid[i,j] = newTile;

                var isOdd = (i % 2 == 0 && j % 2 != 0) || (i % 2 != 0 && j % 2 == 0); 
                newTile.Init(isOdd, i, j);
            }
        }

    }

    // Finds last tile clicked by the user
    private Tile GetSelectedTile() 
    {
        for (int i = 0; i < 8; i++) 
        {
            for (int j = 0; j < 8; j++) 
            {
                if (start == null && grid[i, j].GetClicked()) 
                {
                    return grid[i, j];
                }
                else 
                {
                    if (grid[i, j].GetClicked() && !(start.GetCol() == i && start.GetRow() == j)) 
                    {
                        return grid[i, j];
                    }
                }
            }
        }
        Debug.Log("WARNING NULL TILE");
        return null;
    }

    // Highlights posible moves
    private void ShowMoves() 
    {
        int x = start.GetCol();
        int y = start.GetRow();

        if (gameManager.GetTurn() == 1) 
        {
            if (BoundCheck(x - 1)) 
            {
                left = grid[x - 1, y + 1];
            }
            if (BoundCheck(x + 1)) 
            {
                right = grid[x + 1, y + 1];
            }
        } 
        else if (gameManager.GetTurn() == 2) 
        {
            if (BoundCheck(x - 1)) 
            {
                left = grid[x - 1, y - 1];
            }
            if (BoundCheck(x + 1)) 
            {
                right =grid[x + 1, y - 1]; 
            }
        }

        if (left) 
        {
            left.Highlight();
        }
        if (right) 
        {
            right.Highlight();
        }

    }

    // Checks if coord is outside of game board
    private bool BoundCheck(int coord) 
    {
        if (coord > 0 && coord < 7) 
        {
            return true;
        }
        return false;
    }


    //Checks if selected move is valid 
    private bool Move () 
    {
        bool capture = false;

        //Check if destination tile is empty
        if (CheckEmptyTile() == false) 
        {
            Undo();
            return false;
        }
        //Checks movement logic 
        if (CheckBasicStep() == true)
        {
            Debug.Log("Player " + gameManager.GetTurn() + " Move their piece moved to an empty square");
        }
        else if (CheckBasicCapture() == true) 
        {
            capture = true;
        }
        else
        {
            Undo();
            return false;
        }

        // If capture flag is set capture piece 
        if (capture == true)
        {
            RemovePiece();
            dest.ShowPiece(start.GetColour());
            start.ShowPiece(0);
            Undo();
        }
        else
        {
            dest.ShowPiece(start.GetColour());
            start.ShowPiece(0);
            Undo();
        }
        return true;
    }

    //checks if destination tile is empty
    private bool CheckEmptyTile() 
    {
        if (dest.isOccupied()) 
        {
            Debug.Log("Selected destination tile is already occupied");
            return false;
        }
        return true;
    }

    //Movement check for basic piece moving forward
    private bool CheckBasicStep()
    {

        int deltaX = (start.GetRow() - dest.GetRow());
        int deltaY = (start.GetCol() - dest.GetCol());
        //Checks if piece is basic 
        if (start.GetColour() != 1 && start.GetColour() != 2)
        {
            return false;
        }
        //Checks if piece is moving by one square
        if (Math.Abs(deltaX) != 1 || Math.Abs(deltaY) != 1)
        {
            return false;
        }
        //Checks if piece is moving forward 
        if ((start.GetColour() == 1) && (deltaX > 0))
        {
            return false;
        }
        else if ((start.GetColour() == 2) && (deltaX < 0))
        {
            return false;
        }
        
        return true;
    }

    // Check for testing if basic piece is making a valid capture
    private bool CheckBasicCapture()
    {   
        int deltaX = (start.GetRow() - dest.GetRow());
        int deltaY = (start.GetCol() - dest.GetCol());
        int captureX = (start.GetRow() + dest.GetRow())/ 2;
        int captureY = (start.GetCol() + dest.GetCol()) / 2;
        //Checks if piece is basic 
        if (start.GetColour() != 1 && start.GetColour() != 2)
        {
            return false;
        }
        //Checks if piece is moving by two squares
        if (Math.Abs(deltaX) != 2 || Math.Abs(deltaY) != 2)
        {
            return false;
        }
        //Checks if piece is moving forward 
        if ((start.GetColour() == 1) && (deltaX > 0))
        {
            return false;
        }
        else if ((start.GetColour() == 2) && (deltaX < 0))
        {
            return false;
        }
        //Check for piece to capture
        if ((grid[captureY, captureX].GetColour() == start.GetColour()) || (grid[captureY, captureX].GetColour() == 0))
        {
            return false;
        }

        return true;
    }

    // Removes piece between start and destination tiles
    private void RemovePiece() 
    {
        int captureX = (start.GetRow() + dest.GetRow())/ 2;
        int captureY = (start.GetCol() + dest.GetCol()) / 2;

        grid[captureY, captureX].ShowPiece(0);

        return;
    }

    // Unselects start and destination tiles
    private void Undo ()
    {
        start.SetClicked(false);
        start = null;

        if (dest) 
        {
            dest.SetClicked(false);
            dest = null;
        }

        if (left)
        {
            left.Unhighlight();
            left = null;
        }
        if (right)
        {
            right.Unhighlight();
            right = null;
        }

    }

    private bool NoLegalMoves()
    {
        for (int i = 0; i < 8; i++) 
        {
            for (int j = 0; j < 8; j++) 
            {
                tile = grid[i,j];
                if (tile.GetColour() == gameManager.GetTurn())
                {
                    if(CheckBasicStep())
                    {
                        return false;
                    } else if(CheckBasicCapture())
                    {
                        return false;
                    }
                }
            }
        }
        return true;
    }

    // Updates game state
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if (start == null)
            {
                start = GetSelectedTile();
                if(start)
                {
                    if (start.GetColour() != gameManager.GetTurn())
                    {
                        Debug.Log("Not your turn.");
                        Undo();
                    }
                }
            } else if (start != null)
            {
                dest = GetSelectedTile();
                if (dest != null)
                {
                    //switch player turn if move is valid
                    if (Move() == true)
                    {
                        gameManager.TurnSwitch();
                    }

                }
                else 
                {
                    Undo();
                }
            }
        }

        if (start) 
        {
            ShowMoves();
        } 

        // if(NoLegalMoves())
        // {
        //     gameManager.EndGame();
        // }
    }

}
