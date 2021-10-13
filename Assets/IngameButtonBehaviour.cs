using UnityEngine;
using UnityEngine.SceneManagement;

public class IngameButtonBehaviour : MonoBehaviour
{
    public void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
