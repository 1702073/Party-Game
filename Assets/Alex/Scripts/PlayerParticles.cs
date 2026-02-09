using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerParticles : MonoBehaviour
{
    private int playerIndex;
    private ParticleSystem playerParticles;
    private void Start()
    {
        playerIndex = transform.GetComponentInParent<PlayerInput>().playerIndex;
        playerParticles = GetComponent<ParticleSystem>();
        ParticleSystem.MainModule mainModule = playerParticles.main;
        switch (playerIndex)
        {
            case 0:
                mainModule.startColor = Color.blue;
                break;
            case 1:
                mainModule.startColor = Color.red;
                break;
            case 2:
                mainModule.startColor = Color.green;
                break;
            case 3:
                mainModule.startColor = new Color(.8f, .276f, 0f);
                break;
        }

    }



}
