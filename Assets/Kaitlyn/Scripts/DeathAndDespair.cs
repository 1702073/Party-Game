using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class DeathAndDespair : MonoBehaviour
{
    public float deathAnimDuration = .3f;
    private bool isDying = false;

    private int playerCount;

    void Start()
    {
        playerCount = PlayerInputManager.instance.playerCount;
    }

    void Update()
    {
        
    }

    public IEnumerator Death()
    {
        playerCount--;

        StartCoroutine(ScaleOverTime(Vector3.zero, deathAnimDuration));

        while (isDying)
        {
            yield return null;
        }

        Debug.Log("pls pl spls pls pls pls");

        if (playerCount <= 0)
        {
            // grab the time snd stuff here
            Debug.Log("lowk won typ sh2");
            Destroy(this.gameObject);
        }
        else
        {
            Debug.Log("im crine");
            Destroy(this.gameObject);
            yield return null;

        }

    }

    private IEnumerator ScaleOverTime(Vector3 targetScale, float duration)
    {
        isDying = true;
        Vector3 initialScale = transform.localScale;
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {           
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration;
            t = Mathf.SmoothStep(0f, 1f, t);

            transform.localScale = Vector3.Lerp(initialScale, targetScale, t);

            yield return null;
        }

        transform.localScale = targetScale;

        isDying = false;

        Debug.Log("derp");
    }

    public void ReadPlayers()
    {

        for (int i = 0; i < PlayerInputManager.instance.playerCount; i++)
        {
            
        }
    }
}
