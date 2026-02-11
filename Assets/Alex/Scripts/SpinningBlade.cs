using UnityEngine;

public class SpinningBlade : MonoBehaviour
{
    [SerializeField] private float spinSpeed = 5f;

    private void Start()
    {
        
    }

    private void Update()
    {
        spinBlade();
    }

    private void spinBlade()
    {
        transform.Rotate(new Vector3(0, 0, spinSpeed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(collision.gameObject.TryGetComponent(out DeathAndDespair deathAndDespair))
            {              
                StartCoroutine(deathAndDespair.Death());
            }
            else
            {
                Debug.Log(":pensive:");
            }
        }
    }
}
