using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonBehaviour : MonoBehaviour
{
    // Closes the game
    public void QuitGame() 
    {
        Application.Quit();
    }

    // Loads the instructions scene
    public void InstructionsScene()
    {
        SceneManager.LoadScene("Instructions");
    }
}
