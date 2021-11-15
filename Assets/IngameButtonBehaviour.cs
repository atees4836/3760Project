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
        SceneManager.LoadScene("MainMenu");
        // if(EditorUtility.DisplayDialog("End Game", "Choose a winner:","Red won", "Black won"))
        // {
        //     EditorUtility.DisplayDialog("Red Won!", "Congratulations!","Return to menu");
        //     SceneManager.LoadScene("MainMenu");
        // } else{
        //     EditorUtility.DisplayDialog("Black Won!", "Congratulations!","Return to menu");
        //     SceneManager.LoadScene("MainMenu");
        // }
    }
}
