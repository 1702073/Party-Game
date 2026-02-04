using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.UI;
using Mono.Cecil.Cil;

public class ShopScript : MonoBehaviour
{
    private ShopData[] allSkins;
    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private RectTransform skinButtonsTransform;

    private int buttonNumber;

    private void Awake()
    {
        allSkins = Resources.LoadAll<ShopData>("Skins");
    }

    void Start()
    {
        float xStep = 188f / skinButtonsTransform.rect.width;
        float yStep = 144f / skinButtonsTransform.rect.height;
        RectTransform prefabRect = buttonPrefab.GetComponent<RectTransform>();
        Vector2 baseAnchorMin = prefabRect.anchorMin;
        Vector2 baseAnchorMax = prefabRect.anchorMax;


        for (int i = 0; i < 16; i++)
        {
            int currentIndex = i;
            GameObject newButton = Instantiate(buttonPrefab, skinButtonsTransform);
            newButton.GetComponent<Image>().sprite = allSkins[i].skin;
            newButton.GetComponent<Button>().onClick.AddListener(() => Buy(currentIndex));
            RectTransform rect = newButton.GetComponent<RectTransform>();

            int column = i /4;
            int row = i % 4;

            Vector2 offset = new Vector2(xStep * column, -yStep * row);
            rect.anchorMin = baseAnchorMin + offset;
            rect.anchorMax = baseAnchorMax + offset;

        }

    }

    public void Exit()
    {
        SceneManager.LoadScene(0); //Update this later to use an actual scene rather than an index
    }

    public void Buy(int index)
    {
        Debug.Log("EEE" + index.ToString());
        var ownedSkins = SaveDataController.Instance.current.UnlockedSkins.Skins;
        var skin = allSkins[index]; 

        if (index > 15) // Achievement Skins
        {
            
        }
        else
        {
            int cost = allSkins[index].cost; 
            int currency = SaveDataController.Instance.current.Currency;
            if (ownedSkins.Contains(skin.skin.name) || cost > currency)
            {
                Debug.Log("You either dont have enough money or already own this skin");
                return;
            }
    
        
            SaveDataController.Instance.current.Currency = currency - cost;
            SaveDataController.Instance.current.UnlockedSkins.Skins.Add(skin.skin.name);
            Debug.Log($"You bought Skin Number {index} for {cost} and now have {currency - cost}.");

        }
    }
}
