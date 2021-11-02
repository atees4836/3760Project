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

    public void displayText(string s) {
        Name2 = s;
        Debug.Log(Name2);
    }

    void OnDisable() {
        PlayerPrefs.SetString("name2", Name2);
    }
}
