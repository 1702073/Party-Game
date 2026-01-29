using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pencil : MonoBehaviour
{
    public GameObject pencilPrefab;

    public List<Transform> pencilSpawnPoints;
    public float warningTime;
    public float pencilSpeed;

    public Camera mainCam;
    public float spawnRadius;

    public Transform pencilTarget;

    void Start()
    {
        mainCam = Camera.main;
    }

    void Update()
    {
        
    }

    public void PencilToSpawn(InputAction.CallbackContext ctx)
    {
        if(!ctx.performed) return;

        Transform spawnPoint = pencilSpawnPoints[Random.Range(0, pencilSpawnPoints.Count)];


        RandomerPencilSpawn();

        //StartCoroutine(SpwanPencil(spawnPoint));
    }

    public IEnumerator SpwanPencil(Transform spawnpoint)
    {
        Vector2 startPos = spawnpoint.position;
        Vector2 endPos = -startPos;

        Vector2 direction = (endPos - startPos);


        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Vector3 rotation = new Vector3(0, 0, angle + 90);

        GameObject pencil = Instantiate(pencilPrefab, spawnpoint.position, Quaternion.identity);

        pencil.transform.rotation = Quaternion.Euler(rotation);

        Rigidbody2D rb = pencil.GetComponent<Rigidbody2D>();

        yield return new WaitForSeconds(warningTime);


        if (rb != null)
        {
            rb.linearVelocity = direction * pencilSpeed;
        }

        Destroy(pencil, 2f);

        yield break;
    }

    public void RandomerPencilSpawn()
    {
        float randomX = Random.Range(0f, 1f);
        float randomY = Random.Range(0f, 1f);

        Vector3 viewportPos = new Vector3(randomX, randomY, 0);
        Vector3 spawnPosition = mainCam.ViewportToWorldPoint(new Vector3(viewportPos.x, viewportPos.y, 0));

        pencilTarget.position = spawnPosition
;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }
}
