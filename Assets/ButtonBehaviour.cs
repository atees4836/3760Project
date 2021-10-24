using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehaviour : MonoBehaviour
{
    public void QuitGame() 
    {
        Application.Quit();
    }

    public void InstructionsScene()
    {
        SceneManager.LoadScene("Instructions");
    }
}
