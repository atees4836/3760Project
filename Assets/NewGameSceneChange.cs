using UnityEngine;
using UnityEngine.SceneManagement;
 
public class NewGameSceneChange : MonoBehaviour
{
    // Load board scene when submit button is pressed on names scene
    public void NextScene()
    {
        SceneManager.LoadScene("board");
    }
}