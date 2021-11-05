using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Name2Propagate : MonoBehaviour
{
    // Start is called before the first frame update
    private string player2Name;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Load player 2 name from local files 
    void OnEnable() 
    {
        player2Name =  PlayerPrefs.GetString("name2");
        transform.gameObject.GetComponent<Text>().text = "Player 2: " + player2Name;
    }
}
