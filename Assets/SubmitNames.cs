using UnityEngine;
using UnityEngine.SceneManagement;
 
public class SubmitNames : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene("board");
    }
}