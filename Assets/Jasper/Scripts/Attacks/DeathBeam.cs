using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class DeathBeam : MonoBehaviour
{
    // References
    [Header("References")]
    public GameObject warning;
    public GameObject beam;
    AudioSource audioSource;

    // Sounds
    [Header("Sounds")]
    public AudioClip warningSound1;
    public AudioClip warningSound2;
    public AudioClip fireSound;
    float fireSoundTimer;

    // Configuration
    [Header("General Configuration")]
    public float width;

    [Header("Warning Configuration")]
    public float warningDuration;
    float warningFlashTime;
    public Color warningColor;

    [Header("Beam Configuration")]
    public float beamDuration;
    public Color beamColor;

    void Start()
    {
        fireSoundTimer = 0;

        // Configure warning and beam
        warning.GetComponent<SpriteRenderer>().color = warningColor;
        warning.transform.localScale = new Vector3(
            width,
            warning.transform.localScale.y,
            warning.transform.localScale.z
        );
        warningFlashTime = warningDuration / 10;

        beam.GetComponent<SpriteRenderer>().color = beamColor;
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Warning
        if (warningDuration > 0) {
            warningDuration -= Time.deltaTime;
            warningFlashTime -= Time.deltaTime;

            // Flash warning
            if (warningFlashTime <= 0)
            {
                warning.SetActive(!warning.activeSelf);
                AudioClip soundToPlay;

                // Adjust flash time and sound based on remaining warning duration
                if (warningDuration / 10 < 0.05f)
                {
                    warningFlashTime = 0.05f;
                    soundToPlay = warningSound2;
                }
                else
                {
                    warningFlashTime = warningDuration / 10;
                    soundToPlay = warningSound1;
                }

                // Play warning sound if warning is active
                if (warning.activeSelf)
                {
                    audioSource.PlayOneShot(soundToPlay);
                }
            }
        } else if (!beam.activeSelf) {
            // I warned you, now PREPARE TO BE VANQUISHED
            warning.SetActive(false);
            beam.SetActive(true);
        }

        // Beam
        if (beam.activeSelf) {
            if (beamDuration > 0) {
                // Enlarge beam to set width
                if (beam.transform.localScale.x < width) { 
                    beam.transform.localScale += new Vector3(Time.deltaTime * (5 * width), 0, 0);
                }

                beamDuration -= Time.deltaTime;

                // Play fire sound
                if (fireSoundTimer > 0) {
                    fireSoundTimer -= Time.deltaTime;
                } else {
                    audioSource.PlayOneShot(fireSound);
                    fireSoundTimer = 0.25f;
                }
            } else {
                // Shrink beam before self destruction
                if (beam.transform.localScale.x > 0) { 
                    beam.transform.localScale -= new Vector3(Time.deltaTime * (5 * width), 0, 0);
                }
                else {
                    Destroy(gameObject);
                }
            }
        }

        // Clamp beam width
        beam.transform.localScale = new Vector3(
            Mathf.Clamp(beam.transform.localScale.x, 0, width),
            beam.transform.localScale.y,
            beam.transform.localScale.z
        );
    }
}