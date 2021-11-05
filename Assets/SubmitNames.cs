using UnityEngine;
using UnityEngine.SceneManagement;
 
public class SubmitNames : MonoBehaviour
{
    // Load board when Names scene's submit button is pressed
    public void NextScene()
    {
        SceneManager.LoadScene("board");
    }
}