using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopulateList : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject textTemplate2;
    private List<GameObject> textItems;
    void Start()
    {
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
            GameObject newText = Instantiate(textTemplate2) as GameObject;
            newText.SetActive(true);
            newText.GetComponent<TextLogItem>().SetText("Test", myColour);
            newText.transform.SetParent(textTemplate2.transform.parent, false);

            gameNumTemp++;
        }
    }

}
