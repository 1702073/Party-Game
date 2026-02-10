using UnityEngine;


public class Levels : MonoBehaviour
{
    [SerializeField] private Sprite[] levelSprites = new Sprite[3];

    void Start()
    {

        GetComponent<SpriteRenderer>().sprite = levelSprites[Random.Range(0, 2)];

    }

    
    void Update()
    {
        
    }
}
