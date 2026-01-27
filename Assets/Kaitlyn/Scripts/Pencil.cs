using System.Collections.Generic;
using UnityEngine;

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

    public void PencilToSpawn()
    {
        PencilData pencil = pencils[Random.Range(0, pencils.Count)];

        SpawnPencil(pencil);
    }

    public void SpawnPencil(PencilData penkil)
    {
        
        float randomAngle = Random.Range(-penkil.angleRange, penkil.angleRange);

        Quaternion rotation = Quaternion.Euler(0, 0, randomAngle);
        Vector3 spawnDirection = rotation * Vector3.forward;

        GameObject pencil = Instantiate(pencilPrefab, penkil.pencilSpawnPoint.position, Quaternion.LookRotation(spawnDirection));

        Rigidbody rb = pencil.GetComponent<Rigidbody>();

        if(rb != null)
        {
            rb.linearVelocity = spawnDirection * penkil.pencilSpeed;
        }
    }
}

public struct PencilData
{
    public Transform pencilSpawnPoint;
    public float pencilSpeed;
    public float angleRange;
}
