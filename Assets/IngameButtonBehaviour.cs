using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEditor;

public class IngameButtonBehaviour : MonoBehaviour
{
    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void EndGame()
    {
        if(EditorUtility.DisplayDialog("Are you sure you want to end the game?", "I'm sure","Cancel"))
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
