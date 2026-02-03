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
    public Transform pencilSpawnPos;

    public float pencilSpawnTime; // how often pencils spawn

    void Start()
    {
        mainCam = Camera.main;
        InvokeRepeating("PencilToSpawn", 3f, pencilSpawnTime);
    }

    void Update()
    {
        
    }

    public void PencilToSpawn() // originally for the manual spawn but invoke repeating needs a void so ill use this InputAction.CallbackContext ctx
    {
        //if(!ctx.performed) return;

        Transform spawnPoint = pencilSpawnPoints[Random.Range(0, pencilSpawnPoints.Count)];


        StartCoroutine(RandomerPencilSpawn());

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
            rb.linearVelocity = direction.normalized * pencilSpeed;
        }

        Destroy(pencil, 2f);

        yield break;
    } // fallback manual spawner 

    public IEnumerator RandomerPencilSpawn()
    {
        float randomX = Random.Range(-10f, 10f);
        float randomY = Random.Range(-10f, 10f);

        Vector3 targetPosition =new Vector3(randomX, randomY, 0);

        Vector2 spawnDirection = Random.insideUnitCircle.normalized;
        Vector3 spawnPos = mainCam.transform.position + new Vector3(spawnDirection.x, spawnDirection.y, 0) * spawnRadius;
        spawnPos.z = 0;
        Vector3 viewPoint = mainCam.WorldToViewportPoint(spawnPos);

       

        pencilTarget.position = targetPosition;
        pencilSpawnPos.position = spawnPos;

        Vector2 direction = (targetPosition - spawnPos);

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Vector3 rotation = new Vector3(0, 0, angle + 90);

        GameObject pencil = Instantiate(pencilPrefab,spawnPos, Quaternion.identity);

        pencil.transform.rotation = Quaternion.Euler(rotation);

        Rigidbody2D rb = pencil.GetComponent<Rigidbody2D>();

        yield return new WaitForSeconds(warningTime);


        if (rb != null)
        {
            rb.linearVelocity = direction.normalized * pencilSpeed;
        }

        Destroy(pencil, 2f);

        yield break;
    }
}
