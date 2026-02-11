using UnityEngine;
using System.Collections;


public class BombScript : MonoBehaviour
{

    private SpriteRenderer _bombSprite;
    [SerializeField] private float blinkDuration = 1f;
    [SerializeField] private int blinks = 3;
    [SerializeField] private GameObject warning;
    [SerializeField] private LayerMask playerLayer;
    

    void Start()
    {
        _bombSprite = GetComponent<SpriteRenderer>();
        StartCoroutine(Blink());
        StartCoroutine(ChangeTrigger());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator ChangeTrigger()
    {
        for (int i = 0; i < 1; i++)
        {
            yield return new WaitForSeconds(.5f);
        }
        gameObject.GetComponent<CircleCollider2D>().isTrigger = true;
    }

    private IEnumerator Blink()
    {
        for (int i = 0; i < blinks * 2; i++)
        {
            if (i % 2 == 0)
            {
                _bombSprite.color = Color.white;
            }
            else
            {
                _bombSprite.color = Color.red;

            }

            if (!(i + 1 < blinks * 2))
            {
                StartCoroutine(WarningExpand());
            }

            yield return new WaitForSeconds(blinkDuration / 2f);
        }

        
        
        yield return null;
    }

    private IEnumerator WarningExpand()
    {
        warning.SetActive(warning);
        float elapsed = 0f;
        Vector3 start = Vector3.zero;
        start.z = 1f;
        Vector3 target = new (5f, 5f, 1f);

        warning.transform.localScale = start;

        while (elapsed < blinkDuration / 2f)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / (blinkDuration / 2f);
            warning.transform.localScale = Vector3.Lerp(start, target, t);
            yield return null;
        }

        warning.transform.localScale = target;
        Explode();

        
    }

    private void Explode()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, 2.5f, Vector2.zero, 0f, playerLayer);
        foreach (var hit in hits)
        {

            Debug.Log(hit.collider.gameObject.name);
            if (hit.collider.gameObject.TryGetComponent(out DeathAndDespair deathAndDespair))
            {      
                Debug.Log("PLAYER DIED TO BOMB!?!?!?!?!");        
                StartCoroutine(deathAndDespair.Death());
            }
            else
            {
                Debug.Log(":bomb:");
            }
        }
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(WarningExpand());

            if (collision.gameObject.TryGetComponent(out DeathAndDespair deathAndDespair))
            {      
                StartCoroutine(deathAndDespair.Death());
            }
            else
            {
            }   
        }
    }

}
