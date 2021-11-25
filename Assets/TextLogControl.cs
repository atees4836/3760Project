using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextLogControl : MonoBehaviour
{
    [SerializeField]
    private GameObject textTemplate;
    private List<GameObject> textItems;

    void Start()
    {
        textItems = new List<GameObject>();
        
        int i;
        string name1TextTemp;
        string name2TextTemp;
        string name1Temp;
        string name2Temp;
        string winnerTextTemp;
        string winnerTemp;
        int gameNumTemp;
        int gameNum;
        Color myColour;

        i = 0;
        myColour = Color.white;
        gameNumTemp = 1;
        gameNum = PlayerPrefs.GetInt("gameNum", 0);
        Debug.Log("Gamenum is " + gameNum);


        for(i = 0; i < gameNum; ++i) {
            name1TextTemp = "name1_game_" + gameNumTemp;
            name2TextTemp = "name2_game_" + gameNumTemp;
            winnerTextTemp = "winner_game_" + gameNumTemp;
            name1Temp = PlayerPrefs.GetString(name1TextTemp);
            name2Temp = PlayerPrefs.GetString(name2TextTemp);
            winnerTemp = PlayerPrefs.GetString(winnerTextTemp, "None");
            //Debug.Log("name1Temp: " + name1Temp + ", name2Temp: " + name2Temp);

            //create new Text gameObject and set it as active
            GameObject newText = Instantiate(textTemplate) as GameObject;
            newText.SetActive(true);
            newText.GetComponent<TextLogItem>().SetText(name1Temp + " vs " + name2Temp + ", winner: " + winnerTemp, myColour);
            newText.transform.SetParent(textTemplate.transform.parent, false);

            gameNumTemp++;
        }


    }

    public void LogText(string newTextString, Color newColour)
    {
        if(textItems.Count >= 30) {
            GameObject tempItem = textItems[0];
            Destroy(tempItem.gameObject);
            textItems.Remove(tempItem);
        }

        //create new Text gameObject and set it as active
        GameObject newText = Instantiate(textTemplate) as GameObject;
        newText.SetActive(true);
        newText.GetComponent<TextLogItem>().SetText(newTextString, newColour);
        newText.transform.SetParent(textTemplate.transform.parent, false);
    
        textItems.Add(newText.gameObject);
    }
}
