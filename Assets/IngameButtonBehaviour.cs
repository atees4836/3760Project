using UnityEngine;
using UnityEngine.SceneManagement;

public class IngameButtonBehaviour : MonoBehaviour
{
    // Returns to main menu
    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
