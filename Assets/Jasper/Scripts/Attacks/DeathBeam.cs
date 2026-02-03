using UnityEngine;

public class DeathBeam : MonoBehaviour
{
    // References
    [Header("References")]
    public GameObject warning;
    public GameObject beam;

    // Configuration
    [Header("General Configuration")]
    public float width;

    [Header("Warning Configuration")]
    public float warningDuration;
    public Color warningColor;

    [Header("Beam Configuration")]
    public float beamDuration;
    public Color beamColor;

    void Start()
    {
        warning.GetComponent<SpriteRenderer>().color = warningColor;
        warning.transform.localScale = new Vector3(
            width,
            warning.transform.localScale.y,
            warning.transform.localScale.z
        );

        beam.GetComponent<SpriteRenderer>().color = beamColor;
    }

    void Update()
    {
        if (warningDuration > 0) {
            warningDuration -= Time.deltaTime;
        } else if (!beam.activeSelf) {
            warning.SetActive(false);
            Debug.Log("warning no longer exists");
            beam.SetActive(true);
            Debug.Log("BEAM EXISTS NOW AAAHAHAHAHAHAHAHAAAAA");
        }

        // DEATH BEAM AAAHAHAHAHAHAHAHAAAAA
        if (beam.activeSelf) {
            if (beamDuration > 0) {
                // Enlarge death beam to set width
                if (beam.transform.localScale.x < width) { 
                    beam.transform.localScale += new Vector3(Time.deltaTime * (5 * width), 0, 0);
                }

                beamDuration -= Time.deltaTime;
            } else {
                // Shrink death beam before self destruction
                if (beam.transform.localScale.x > 0) { 
                    beam.transform.localScale -= new Vector3(Time.deltaTime * (5 * width), 0, 0);
                }
                else {
                    Destroy(gameObject);
                }
            }
        }

        beam.transform.localScale = new Vector3(
            Mathf.Clamp(beam.transform.localScale.x, 0, width),
            beam.transform.localScale.y,
            beam.transform.localScale.z
        );
    }
}