using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ProjHitScript : MonoBehaviour
{
    private Rigidbody2D _rb2d;
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Debug.Log("HIT THE PLAYER!?!??!?!?");
        }
    }

}
