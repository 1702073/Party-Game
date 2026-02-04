using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.UI;


public class CharacterSelect : MonoBehaviour
{
    public PlayerInputManager playerInputManager;
    public List<Sprite> selectedSkins = new ();
    private GameObject cursorPrefab;
    [SerializeField] private Canvas canvas;
    private int currentCount;
    private GameObject skinSelectButton;
    private List<Sprite> skins = new();
    [SerializeField] private Sprite test;


    private void Awake()
    {
        cursorPrefab = Resources.Load<GameObject>("Prefabs/Cursor");
        skinSelectButton = Resources.Load<GameObject>("Prefabs/SelectButton");
        for (int i = 0; i < InputSystem.devices.Count; ++i)
        {
            var device = InputSystem.devices[i]; //if (player.GetComponent<PlayerInput>().currentControlScheme == "Gamepad") //
            if (device is Keyboard || device is Gamepad)
            {
                var input = playerInputManager.JoinPlayer(pairWithDevice: device);
                DontDestroyOnLoad(input.gameObject);
                if (device is Gamepad)
                {
                    GameObject cursor = Instantiate(cursorPrefab, canvas.GetComponent<RectTransform>());
                    cursor.GetComponent<CursorScript>().cursorInput = input;
                }
            }

        }
        currentCount = playerInputManager.playerCount;
        DontDestroyOnLoad(playerInputManager);
    }

    void Start()
    {
        skins = SaveDataController.Instance.current.UnlockedSkins.Skins;
        Vector3 pos = new (-100f, 100f, 0f);
        List<GameObject> buttons = new();
        for (int i = 0; i < skins.Count; i++)
        {
            Sprite skin = skins[i];
            GameObject select = Instantiate(skinSelectButton, canvas.GetComponent<RectTransform>());
            buttons.Add(select);
            select.GetComponent<RectTransform>().anchoredPosition = pos;
            pos += new Vector3 (-170f, 0f, 0f);
        }

        for (int i = 0; i < buttons.Count; i++) // I dont understand why this is needed but it breaks in the other for loop
        {
            buttons[i].GetComponent<Image>().sprite = skins[i];
        }

    }

    void Update()
    {
        
    }

}
