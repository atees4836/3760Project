using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

	public static GameManager instance;

	public Board board;

	private Player red;
	private Player black;
	private int curPlayer = 2;

	public GameObject blackPiece;
	public GameObject redPiece;
	public GameObject blackKing;
	public GameObject redKing;

	public GameObject EndGamePanel;

	void Awake() {
		instance = this;
	}

    void Start()
    {
    	red = new Player("red", 1);
    	black = new Player("black", 2);

    	Debug.Log("It is player " + curPlayer + "'s turn.");

    	setup();
    }

    private void setup() {
		EndGamePanel = GameObject.Find("EndGamePanel");
        EndGamePanel.SetActive(false);

    	board.initBoard();
    }

    public void turnSwitch() {
    	if (curPlayer == 1) {
    		curPlayer = 2;
    	} else if (curPlayer == 2) {
    		curPlayer = 1;
    	}
    	Debug.Log("It is player " + curPlayer + "'s turn.");
    }

    public int getTurn() {
    	return curPlayer;
    }

	public Player getCurPlayer() {
		if(curPlayer == 2) {
			return this.black;
		} else if (curPlayer == 1) {
			return this.red;
		} else {
			return null;
		}
	}

	public Player getOppPlayer() {
		if(curPlayer == 1) {
			return this.black;
		} else if (curPlayer == 2) {
			return this.red;
		} else {
			return null;
		}
	}
    
	public void EndGame(string winner) {
		Debug.Log("No legal moves remain");

		// EndGamePanel.SetActive(true);
		SceneManager.LoadScene("Game Over");
		GameObject winnerText = GameObject.Find("Winner");
		winnerText.transform.GetComponent<Text>().text = winner;
		// EndGamePanel.transform.SetAsFirstSibling();
	}
}
