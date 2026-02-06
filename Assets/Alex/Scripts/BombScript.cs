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
    }

    // Update is called once per frame
    void Update()
    {
        
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
                warning.SetActive(warning);
            }

            yield return new WaitForSeconds(blinkDuration / 2f);
        }

        Destroy(gameObject);

        RaycastHit2D hit = Physics2D.CircleCast(transform.position, 2.5f, Vector2.zero, 0f, playerLayer);
        if (hit)
        {
            Debug.Log("Player hit by bomb");
            //Add death function here
        }
        yield return null;
    }

}
