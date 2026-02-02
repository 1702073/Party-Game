using UnityEngine;

public class Pausing : MonoBehaviour
{
    public GameObject PausePanel, Ui;
    public bool isPaused = false;

    
    public void Awake()
    {
        //Ui = GameObject.find
    }


    public void Start()
    {
        Time.timeScale = 1f;
        isPaused = false;
        Ui.SetActive(true);
        PausePanel.SetActive(false);
    }

    public void Update()
    {
        //if (Input.GetKeyDown(pause) && isPaused == false)
        //{
        //    Pause();
        //}
        //else if (Input.GetKeyDown(pause) && isPaused == true)
        //{
        //    Continue();
        //}
    }

    public void Pause()
    {
        if (isPaused)
            return;

        Ui.SetActive(false);
        PausePanel.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Continue()
    {
        if (!isPaused)
            return;

        Ui.SetActive(true);
        PausePanel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
}
