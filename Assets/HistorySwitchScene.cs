using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HistorySwitchScene : MonoBehaviour
{
    //Open Player History Scene from main menu on button press
    public void NextScene()
    {
        SceneManager.LoadScene("PlayerHistory");
    }
}
