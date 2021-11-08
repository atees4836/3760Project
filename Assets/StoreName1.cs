using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoreName1 : MonoBehaviour
{
    private string Name1;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Store name inputted by user in player 1 name slot
    public void DisplayText(string s)
    {
        Name1 = s;
    }

    // Save player 1 name to user's local files
    void OnDisable() {
        PlayerPrefs.SetString("name1", Name1);
    }
}
