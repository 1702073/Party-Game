using UnityEngine;
using UnityEngine.InputSystem;

public class Pausing : MonoBehaviour
{

    Master_Pause masterPause;

    public void Awake()
    {
        masterPause = FindAnyObjectByType<Master_Pause>(FindObjectsInactive.Include);
    }
    

    public void Toggle(InputAction.CallbackContext ctx)
    {
        masterPause.Toggle(ctx);
    }

    public void Pause()
    {
        masterPause.Pause();
    }

    public void Continue()
    {
        masterPause.Continue();
    }
}
