using UnityEngine;
using UnityEngine.InputSystem;

public class Pausing : MonoBehaviour
{

    Master_Pause masterPause;

    public void Awake()
    {
    }
    

    public void Toggle(InputAction.CallbackContext ctx)
    {
        masterPause = FindAnyObjectByType<Master_Pause>(FindObjectsInactive.Include);
        masterPause.Toggle(ctx);
    }

    public void Pause()
    {
        masterPause = FindAnyObjectByType<Master_Pause>(FindObjectsInactive.Include);
        masterPause.Pause();
    }

    public void Continue()
    {
        masterPause = FindAnyObjectByType<Master_Pause>(FindObjectsInactive.Include);
        masterPause.Continue();
    }
}
