using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CharacterSelect : MonoBehaviour
{
    public PlayerInputManager playerInputManager;
    private GameObject cursorPrefab;
    [SerializeField] private Canvas canvas;
    private int currentCount;
    private GameObject skinSelectButton;
    private GameObject selectedImage;
    private List<GameObject> selectedImages = new ();
    [SerializeField] private Sprite test;
    private Dictionary<GameObject, Sprite> _players = new Dictionary<GameObject, Sprite> ();
    private GameObject kbm;
    

    private void Awake()
    {
        cursorPrefab = Resources.Load<GameObject>("Prefabs/Cursor");
        skinSelectButton = Resources.Load<GameObject>("Prefabs/SelectButton");
        selectedImage = Resources.Load<GameObject>("Prefabs/SelectedImage");
        int j = 0;
        for (int i = 0; i < InputSystem.devices.Count; ++i)
        {
            var device = InputSystem.devices[i]; 
            if (device is Keyboard || device is Gamepad)
            {
                var input = playerInputManager.JoinPlayer(pairWithDevice: device);
                _players.Add(input.gameObject, null);
                GameObject selectImage = Instantiate(selectedImage, canvas.GetComponent<RectTransform>());
                selectedImages.Add(selectImage);
                selectImage.GetComponent<RectTransform>().anchoredPosition -= j * new Vector2(0, 200);
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
                j++;
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
            select.GetComponent<RectTransform>().SetSiblingIndex(1);

            buttons.Add(select);
            buttons[i].GetComponent<Image>().sprite = skin;
            select.GetComponent<Button>().onClick.AddListener(() => ChangeSprite(kbm, select.GetComponent<Image>().sprite));

            select.GetComponent<RectTransform>().anchoredPosition = pos;
            pos += new Vector3 (-170f, 0f, 0f);
        }
    }

    public void ChangeSprite(GameObject player, Sprite newSkin)
    {
        player.GetComponent<SpriteRenderer>().sprite = newSkin;
        _players[player] = newSkin;
        int index = _players.Keys.ToList().IndexOf(player);
        selectedImages[index].GetComponent<Image>().sprite = newSkin;
    }

    
    void Update()
    {
        
    }

    public void StartGame()
    {
        foreach (var player in _players.Values)
        {
            if (player == null)
            {
                Debug.Log("Not every player has selected their skin!");
                return;
            }
        }

        SceneManager.LoadScene("GameScene");
        
    }



}
