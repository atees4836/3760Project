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

    public void displayText(string s) {
        Name1 = s;
    }

    void OnDisable() {
        PlayerPrefs.SetString("name1", Name1);
    }
}
