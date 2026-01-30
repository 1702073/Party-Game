using System.Collections;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    [SerializeField] private GameObject spinningBlade;
    [SerializeField] private GameObject warningPrefab;
    [SerializeField] private float warningDuration;
    [SerializeField] private float spinCooldown;
    [SerializeField] private float spinSpeed = .5f;


    private void Start()
    {
        spinningBlade = Resources.Load<GameObject>("Prefabs/Blade");
        StartCoroutine(spawnBlade());
    }

    private IEnumerator spawnBlade()
    {
        GameObject warning = Instantiate(warningPrefab);
        yield return new WaitForSeconds(warningDuration);
        Destroy(warning);
        spinningBlade = Instantiate(spinningBlade);
        InvokeRepeating(nameof(spinBlade), 0f, 0.05f);
        yield break;


    }

    private void spinBlade()
    {
        spinningBlade.transform.Rotate(new Vector3(0, 0, spinSpeed));
    }
    




}
