using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreName2 : MonoBehaviour
{
    private string Name2;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Store name inputted by user in player 2 name slot
    public void DisplayText(string s) {
        Name2 = s;
    }

    // Save player 2 name to user's local files
    void OnDisable() {
        PlayerPrefs.SetString("name2", Name2);
    }
}
