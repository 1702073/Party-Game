using UnityEngine;

public class DoNotDestroyOnLoad : MonoBehaviour
{
    // im lazy.

    static DoNotDestroyOnLoad instance;

    void Start()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }
}
