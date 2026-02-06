using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class DeathAndDespair : MonoBehaviour
{
    public float deathAnimDuration = .3f;

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

        if (playerCount <= 0)
        {
            StartCoroutine(ScaleOverTime(Vector3.zero, deathAnimDuration)); // this coroutine destroys the player at the end :man_juggling:
            Debug.Log("lowk won typ sh2");           
            yield break;
        }
        else
        {
            StartCoroutine(ScaleOverTime(Vector3.zero, deathAnimDuration));
            Debug.Log("im crine");
            yield return null;
        }
    }

    private IEnumerator ScaleOverTime(Vector3 targetScale, float duration)
    {
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

        Destroy(this.gameObject);
    }

    public void ReadPlayers()
    {

        for (int i = 0; i < PlayerInputManager.instance.playerCount; i++)
        {
            
        }
    }
}
