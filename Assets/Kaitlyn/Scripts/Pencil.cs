using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Pencil : MonoBehaviour
{
    public GameObject pencilPrefab;

    public List<PencilData> pencils;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void PencilToSpawn(InputAction.CallbackContext ctx)
    {
        if(!ctx.performed) return;

        PencilData pencil = pencils[Random.Range(0, pencils.Count)];

        SpawnPencil(pencil);
    }

    public void SpawnPencil(PencilData penkil)
    {
        Vector3 startPos = penkil.pencilSpawnPoint.position;
        Vector3 endPos = -penkil.pencilSpawnPoint.position;

        float randomAngle = Random.Range(-penkil.angleRange, penkil.angleRange);

        Quaternion rotation = Quaternion.Euler(0, 0, randomAngle);
        Vector3 spawnDirection = rotation * Vector3.up;

        GameObject pencil = Instantiate(pencilPrefab, penkil.pencilSpawnPoint.position, Quaternion.LookRotation(spawnDirection));

        //Rigidbody2D rb = pencil.GetComponent<Rigidbody2D>();

        //if(rb != null)
        {
            //rb.linearVelocity = spawnDirection * penkil.pencilSpeed;
        }
    }
}

[System.Serializable]
public struct PencilData
{
    public Transform pencilSpawnPoint;
    public float pencilSpeed;
    public float angleRange;
}
