using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;


public class CharacterSelect : MonoBehaviour
{
    public PlayerInputManager playerInputManager;
    [SerializeField] private List<Sprite> selectedSkins = new ();
    private GameObject cursorPrefab;
    [SerializeField] private Canvas canvas;


    private void Awake()
    {
        cursorPrefab = Resources.Load<GameObject>("Prefabs/Cursor");

        for (int i = 0; i < InputSystem.devices.Count; ++i)
        {
            var device = InputSystem.devices[i]; //if (player.GetComponent<PlayerInput>().currentControlScheme == "Gamepad") //
            if (device is Keyboard || device is Gamepad)
            {
                var input = playerInputManager.JoinPlayer(pairWithDevice: device);
                DontDestroyOnLoad(input.gameObject);
                if (device is Gamepad)
                {
                    Instantiate(cursorPrefab, canvas.GetComponent<RectTransform>());
                }
            }

        }

        DontDestroyOnLoad(playerInputManager);
    }
}
