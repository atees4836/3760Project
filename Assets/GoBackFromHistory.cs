using UnityEngine;
using UnityEngine.SceneManagement;

public class GoBackFromHistory : MonoBehaviour
{
    //Go back when back button is pressed in Player History Scene
    public void NextScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
