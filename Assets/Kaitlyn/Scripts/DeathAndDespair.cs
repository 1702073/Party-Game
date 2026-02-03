using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class DeathAndDespair : MonoBehaviour
{
    public float deathAnimDuration = .3f;
    private bool isDying = false;

    private static int playerCount;

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

        if(playerCount <= 0)
        {
            // grab the time snd stuff here
            yield break;
        }

        StartCoroutine(ScaleOverTime(Vector3.zero, deathAnimDuration));

        if (isDying)
        {
            yield return null;
        }
        else
        {
            Destroy(this.gameObject);
        }

        yield break;
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
    }
}
