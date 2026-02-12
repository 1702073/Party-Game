using UnityEngine;

public class PencilTrigger : MonoBehaviour
{
    //I FORGOT THE PENCIL SCRIPT WAS ON A  SEPERATE OBJECT CALLED BLERP

    AudioSource audioSource;
    public AudioClip pencilSound;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        Invoke("PlaySound", 1.25f);
    }

    void PlaySound()
    {
        audioSource.PlayOneShot(pencilSound);
    }

    private void OnTriggerEnter2D(Collider2D collision) // should the pencil get destroyed when it hits someone or should it keep going ??
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