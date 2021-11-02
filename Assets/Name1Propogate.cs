using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Name1Propogate : MonoBehaviour
{
    // Start is called before the first frame update
    private string player1Name;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnEnable() {
        player1Name =  PlayerPrefs.GetString("name1");
        transform.gameObject.GetComponent<Text>().text = "Player 1: " + player1Name;
    }
}
