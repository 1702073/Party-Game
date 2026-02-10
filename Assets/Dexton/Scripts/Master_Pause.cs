using UnityEngine;
using UnityEngine.InputSystem;

public class Master_Pause : MonoBehaviour
{

    public GameObject pause;

    public bool isPaused = false;

    public void Awake()
    {
        pause = FindFirstObjectByType<PauseMenu>(FindObjectsInactive.Include).gameObject;
    }

    void Start()
    {
        Time.timeScale = 1f;
        isPaused = false;
        pause.SetActive(false);
    }

    public void Toggle(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            Debug.Log("Toggling Pause");

            if (isPaused)
                Continue();
            else
                Pause();
        }
    }

    public void Pause()
    {
        if (isPaused)
            return;

        pause.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void Continue()
    {
        if (!isPaused)
            return;

        pause.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
}
