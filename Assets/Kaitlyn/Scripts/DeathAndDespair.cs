using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DeathAndDespair : MonoBehaviour
{
    public float deathAnimDuration = .5f;
    public AudioClip deathSound;
    AudioSource audioSource;

    private static int playerCount;

    private Timerexample timer;

    [SerializeField] private Image winScreen;
    [SerializeField] private List<Sprite> winScreens;

    private bool isDying;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (PlayerInputManager.instance != null)
        {
            playerCount = PlayerInputManager.instance.playerCount;
        }        
    }

    void Update()
    {
        
    }

    public void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Level")
        {
            timer = FindFirstObjectByType<Timerexample>();
            winScreen = GameObject.FindGameObjectWithTag(tag: "WinScreen").GetComponent<Image>();
            winScreen.gameObject.SetActive(false);
        }
        else
        {
            timer = null;
            winScreen = null;
        }
    }
    public IEnumerator Death()
    {
        audioSource.PlayOneShot(deathSound);
        playerCount--;
        Debug.Log($"Player Count {playerCount}");
        if (playerCount <= 0)
        {
            if (timer != null)
            {
                timer.stop();
                timer.Reset();
            }
            int index = this.gameObject.GetComponent<PlayerInput>().playerIndex;

            StartCoroutine(ScaleOverTime(Vector3.zero, deathAnimDuration)); // this coroutine destroys the player at the end :man_juggling:
            WaitUntil death = new WaitUntil(() => !isDying);
            yield return death;
            Debug.Log("lowk won typ sh2"); 
            if(winScreen != null)
            {
                winScreen.gameObject.SetActive(true);
                winScreen.sprite = winScreens[index];
                Time.timeScale = 0;
            }

            //SceneManager.LoadScene("Winner Winner Chicken Dinner"); //rlly regretting the long name now...
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

        Destroy(this.gameObject);
    }

    public void ReadPlayers()
    {

        for (int i = 0; i < PlayerInputManager.instance.playerCount; i++)
        {
            
        }
    }
}
