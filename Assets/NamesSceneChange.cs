using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NamesSceneChange : MonoBehaviour
{
    // Load names scene when new game button is pressed
    public void NextScene()
    {
        SceneManager.LoadScene("Names");
    }
}
