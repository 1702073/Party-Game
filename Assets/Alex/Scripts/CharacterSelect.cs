using System.Collections.Generic;
using System.Linq;
using UnityEngine;
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
    [SerializeField] private Sprite test;


    private void Awake()
    {
        cursorPrefab = Resources.Load<GameObject>("Prefabs/Cursor");
        skinSelectButton = Resources.Load<GameObject>("Prefabs/SelectButton");
        for (int i = 0; i < InputSystem.devices.Count; ++i)
        {
            var device = InputSystem.devices[i]; 
            if (device is Keyboard || device is Gamepad)
            {
                selectedSkins.Add(null);
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
        Vector3 pos = new (-100f, 100f, 0f);
        List<GameObject> buttons = new();
        for (int i = 0; i < SaveDataController.Instance.current.UnlockedSkins.Skins.Count; i++)
        {
            Sprite skin = Resources.Load<Sprite>($"Player Skins/{SaveDataController.Instance.current.UnlockedSkins.Skins[i]}");
            
            GameObject select = Instantiate(skinSelectButton, canvas.GetComponent<RectTransform>());
            buttons.Add(select);
            buttons[i].GetComponent<Image>().sprite = skin;
            //select.GetComponent<Button>().onClick.AddListener(() => Buy(select));

            select.GetComponent<RectTransform>().anchoredPosition = pos;
            pos += new Vector3 (-170f, 0f, 0f);
        }
    }

    void Update()
    {
        
    }



}
