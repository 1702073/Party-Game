using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void SceneChange(string sceneName)
    {
        if (!GameObject.Find("InputManager"))
        {
            SceneManager.LoadScene("Shop");
            return;
        }
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1f;
    }

    public void QuitButton()
    {
        Debug.Log("Quit the game!");
        Application.Quit();
    }
}