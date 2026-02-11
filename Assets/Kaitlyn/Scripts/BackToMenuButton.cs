using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMenuButton : MonoBehaviour
{
    public void SceneChange(string sceneName)
    {        
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1f;
    }
}
