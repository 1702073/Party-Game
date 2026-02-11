using UnityEngine;

public class BeamHit : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.TryGetComponent(out DeathAndDespair deathAndDespair))
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
