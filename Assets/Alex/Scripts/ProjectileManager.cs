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
    [SerializeField] private float bombSpawnCooldown = 2f;

    private Timerexample timer;


    private void Start()
    {
        spinningBlade = Resources.Load<GameObject>("Prefabs/Blade");
        timer = FindFirstObjectByType<Timerexample>();
        StartCoroutine(SpawnBlade());
        Invoke(nameof(SpawnBombStart), 2f);
    }

    private void FixedUpdate()
    {
        #region difficulty scaling
        if (timer != null)
        {
            if (timer.val >= 20 && timer.val <= 20.02)
            {
                bombSpawnCooldown *= .8f;
            }
            else if (timer.val >= 40 && timer.val <= 40.02)
            {
                bombSpawnCooldown *= .8f;
            }
            else if (timer.val >= 60 && timer.val <= 60.02)
            {
                bombSpawnCooldown *= .8f;
            }
            else if (timer.val >= 80 && timer.val <= 80.02)
            {
                bombSpawnCooldown *= .8f;
            }
            else if (timer.val >= 100 && timer.val <= 100.02)
            {
                bombSpawnCooldown *= .8f;
            }
        }
        #endregion
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

    public IEnumerator RepeatSpawnBomb()
    {
        while (true)
        {
            SpawnBomb();
            yield return new WaitForSeconds(bombSpawnCooldown);
        }
    }

    private void SpawnBombStart()
    {
        StartCoroutine(RepeatSpawnBomb());
    }


}
