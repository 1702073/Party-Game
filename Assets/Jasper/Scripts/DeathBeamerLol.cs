using UnityEngine;

public class DeathBeamerLol : MonoBehaviour
{
    public GameObject deathBeamPrefab;
    GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float x = player.transform.position.x;
            float y = player.transform.position.y;
            float width = Random.Range(2f, 4f);
            float angle = Random.Range(0, 360);
            float delay = 1.5f;
            float sustain = 0.5f;

            MakeDeathBeam(x, y, width, angle, delay, sustain);
        }
    }

    void MakeDeathBeam(float x, float y, float width, float angle, float delay, float sustain)
    {
        GameObject beam = Instantiate(deathBeamPrefab, new Vector3(x, y, 0), Quaternion.Euler(0, 0, angle));
        DeathBeam deathBeam = beam.GetComponent<DeathBeam>();
        deathBeam.width = width;
        deathBeam.warningDuration = delay;
        deathBeam.beamDuration = sustain;
    }
}
