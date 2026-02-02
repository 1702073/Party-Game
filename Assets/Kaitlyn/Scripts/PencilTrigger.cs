using UnityEngine;

public class PencilTrigger : MonoBehaviour
{
    //I FORGOT THE PENCIL SCRIPT WAS ON A  SEPERATE OBJECT CALLE DBLERP

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) // should the pencil get destroyed when it hits someone or should it keep going ??
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }
}
