using System.Collections;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    [SerializeField] private GameObject spinningBlade;
    [SerializeField] private GameObject warningPrefab;
    [SerializeField] private GameObject bombPrefab;

    [SerializeField] private float warningDuration;
    [SerializeField] private float spinCooldown;
    [SerializeField] private float spinSpeed = .5f;


    private void Start()
    {
        spinningBlade = Resources.Load<GameObject>("Prefabs/Blade");
        StartCoroutine(SpawnBlade());
        InvokeRepeating(nameof(SpawnBomb), 2f, 2f);
    }

    private IEnumerator SpawnBlade()
    {
        GameObject warning = Instantiate(warningPrefab);
        yield return new WaitForSeconds(warningDuration);
        Destroy(warning);
        spinningBlade = Instantiate(spinningBlade);
        yield break;
    }

    private void SpawnBomb()
    {
        Vector3 spawnPos = new (Random.Range(-6f, 6f), Random.Range(-6f, 6f), 0f);
        GameObject bomb = Instantiate(bombPrefab, spawnPos, Quaternion.identity);
    }

 




}
