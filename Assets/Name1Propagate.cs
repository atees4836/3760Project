using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Name1Propagate : MonoBehaviour
{
    private string player1Name;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Load player 1 name from user local files
    void OnEnable() 
    {
        player1Name =  PlayerPrefs.GetString("name1");
        transform.gameObject.GetComponent<Text>().text = "Player 1: " + player1Name;
    }
}
