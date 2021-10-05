using UnityEngine;
using UnityEngine.SceneManagement;
 
public class NewGameSceneChange : MonoBehaviour
{
    public void NextScene()
    {
        SceneManager.LoadScene("board");
    }
}