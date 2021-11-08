using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEditor;

public class IngameButtonBehaviour : MonoBehaviour
{
    // Returns to main menu
    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void EndGame()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
