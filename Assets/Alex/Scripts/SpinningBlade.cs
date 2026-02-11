using UnityEngine;
using UnityEngine.UIElements;

public class SpinningBlade : MonoBehaviour
{
    [SerializeField] private float spinSpeed = 5f;

    private Timerexample timer;

    private void Start()
    {
        timer = FindFirstObjectByType<Timerexample>();
    }

    private void FixedUpdate()
    {
        #region difficulty scaling
        if (timer != null)
        {
            if (timer.val >= 20 && timer.val <= 20.02)
            {
                spinSpeed *= 1.2f;
            }
            else if (timer.val >= 40 && timer.val <= 40.02)
            {
                spinSpeed *= 1.2f;
            }
            else if (timer.val >= 60 && timer.val <= 60.02)
            {
                spinSpeed *= 1.2f;
            }
            else if (timer.val >= 80 && timer.val <= 80.02)
            {
                spinSpeed *= 1.2f;
            }
            else if (timer.val >= 100 && timer.val <= 100.02)
            {
                spinSpeed *= 1.2f;
            }
        }
        #endregion
        spinBlade();
    }

    private void spinBlade()
    {
        transform.Rotate(new Vector3(0, 0, spinSpeed * Time.deltaTime));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(collision.gameObject.TryGetComponent(out DeathAndDespair deathAndDespair))
            {              
                StartCoroutine(deathAndDespair.Death());
            }
            else
            {
                Debug.Log(":pensive:");
            }
        }
    }
}
