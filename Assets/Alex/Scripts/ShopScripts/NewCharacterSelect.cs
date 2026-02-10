using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class NewCharacterSelect : MonoBehaviour
{


    public PlayerInputManager playerInputManager;
    private GameObject cursorPrefab;
    [SerializeField] private Canvas canvas;
    private int currentCount;
    private GameObject selectdImage;
    [SerializeField] private GameObject[] selectedImages = new GameObject[4];
    private Dictionary<GameObject, Sprite> _players = new Dictionary<GameObject, Sprite>();
    private static GameObject kbm;
    private static bool spawned;

    private void Awake()
    {
        if (spawned)
        {
            Destroy(gameObject);
            return;
        }
        spawned = true;
        cursorPrefab = Resources.Load<GameObject>("Prefabs/Cursor");

        for (int i = 0; i < InputSystem.devices.Count; ++i)
        {
            var device = InputSystem.devices[i];
            if (device is Keyboard || device is Gamepad)
            {
                var input = playerInputManager.JoinPlayer(pairWithDevice: device);
                _players.Add(input.gameObject, null);
                DontDestroyOnLoad(input.gameObject);
                if (device is Gamepad)
                {
                    GameObject cursor = Instantiate(cursorPrefab, canvas.GetComponent<RectTransform>());
                    CursorScript cursorScript = cursor.GetComponent<CursorScript>();
                    cursorScript.cursorInput = input;
                    cursorScript.characterSelect = this;
                }
                else
                {
                    kbm = input.gameObject;
                }
            }
        }
        currentCount = playerInputManager.playerCount;
        DontDestroyOnLoad(playerInputManager);
    }


    public void ChangeSprite(GameObject player, Sprite newSkin)
    {
        player.GetComponent<SpriteRenderer>().sprite = newSkin;
        _players[player] = newSkin;
        int index = _players.Keys.ToList().IndexOf(player);
        selectedImages[index].GetComponent<Image>().sprite = newSkin;
    }

    public void ChangeSprite(Sprite newSkin) //This is hard coded mb my brain hurts
    {
        kbm.GetComponent<SpriteRenderer>().sprite = newSkin;
        _players[kbm] = newSkin;
        int index = _players.Keys.ToList().IndexOf(kbm);
        selectedImages[index].GetComponent<Image>().sprite = newSkin;

    }


    private void Update()
    {
        if (playerInputManager.playerCount == 0)
        {
            spawned = false;
            Destroy(gameObject);
        }

        if (SceneManager.GetActiveScene().name == "Shop" && canvas == null)
        {
            GrabReferences();
        }
    }

    private void GrabReferences()
    {
        canvas = FindAnyObjectByType<Canvas>();
        GameObject skinImages = GameObject.FindGameObjectWithTag("Selected");
        int j = 0;
        foreach (Transform skin in skinImages.transform)
        {
            selectedImages[j] = skin.gameObject;
            j++;
        }
        for (int i = 0; i < InputSystem.devices.Count; ++i)
        {
            var device = InputSystem.devices[i];
            if (device is Gamepad)
            {
                GameObject cursor = Instantiate(cursorPrefab, canvas.GetComponent<RectTransform>());
                CursorScript cursorScript = cursor.GetComponent<CursorScript>();
                cursorScript.cursorInput = FindObjectsByType<PlayerInput>(FindObjectsSortMode.None).First(item => item.devices.Contains(device));
                cursorScript.characterSelect = this;
            }
        }
    }

    public void StartGame()
    {
        foreach (var player in _players.Values)
        {
            if (player == null)
            {
                return;
            }
        }
        //Destroy(this)
        //Make this switch scenes if we end of doing that
    }

}
