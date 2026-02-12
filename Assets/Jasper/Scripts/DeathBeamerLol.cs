using System.Collections;
using UnityEngine;

public class DeathBeamerLol : MonoBehaviour
{
    public GameObject deathBeamPrefab;
    GameObject player;

    private Timerexample timer;
    public float beamCooldown = 5f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        timer = FindFirstObjectByType<Timerexample>();

        Invoke(nameof(StartDeathBeams), 5f);
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    float x = player.transform.position.x;
        //    float y = player.transform.position.y;
        //    float width = Random.Range(2f, 4f);
        //    float angle = Random.Range(0, 360);
        //    float delay = 1.5f;
        //    float sustain = 0.5f;

        //    MakeDeathBeam(x, y, width, angle, delay, sustain);
        //}
    }

    private void FixedUpdate()
    {
        #region difficulty scaling
        if (timer != null)
        {
            if (timer.val >= 20 && timer.val <= 20.02)
            {
                beamCooldown *= .8f;
            }
            else if (timer.val >= 40 && timer.val <= 40.02)
            {
                beamCooldown *= .8f;
            }
            else if (timer.val >= 60 && timer.val <= 60.02)
            {
                beamCooldown *= .8f;
            }
            else if (timer.val >= 80 && timer.val <= 80.02)
            {
                beamCooldown *= .8f;
            }
            else if (timer.val >= 100 && timer.val <= 100.02)
            {
                beamCooldown *= .8f;
            }
        }
        #endregion
    }

    public IEnumerator RepeatDeathBeam()
    {
        while (true)
        {
            float x = player.transform.position.x;
            float y = player.transform.position.y;
            float width = Random.Range(1f, 2f);
            float angle = Random.Range(0, 360);
            float delay = 1.5f;
            float sustain = 0.5f;

            MakeDeathBeam(x, y, width, angle, delay, sustain);

            yield return new WaitForSeconds(beamCooldown);
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

    public void StartDeathBeams()
    {
        StartCoroutine(RepeatDeathBeam());
    }
}
