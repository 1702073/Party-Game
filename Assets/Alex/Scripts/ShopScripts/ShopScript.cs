using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.UI;

public class ShopScript : MonoBehaviour
{
    [SerializeField] private List<ShopData> allSkins;
    [SerializeField] private GameObject buttonPrefab;
    [SerializeField] private RectTransform skinButtonsTransform;

    private int buttonNumber;
 
    void Start()
    {
        float xStep = 188f / skinButtonsTransform.rect.width;
        float yStep = 144f / skinButtonsTransform.rect.height;
        RectTransform prefabRect = buttonPrefab.GetComponent<RectTransform>();
        Vector2 baseAnchorMin = prefabRect.anchorMin;
        Vector2 baseAnchorMax = prefabRect.anchorMax;


        for (int i = 0; i < 16; i++)
        {

            GameObject newButton = Instantiate(buttonPrefab, skinButtonsTransform);
            newButton.GetComponent<Image>().sprite = allSkins[i].skin;
            RectTransform rect = newButton.GetComponent<RectTransform>();

            int column = i /4;
            int row = i % 4;

            Vector2 offset = new Vector2(xStep * column, -yStep * row);
            rect.anchorMin = baseAnchorMin + offset;
            rect.anchorMax = baseAnchorMax + offset;

            //newButton.GetComponent<Button>().onClick.RemoveAllListeners();
            //newButton.GetComponent<Button>().onClick.AddListener(() => Buy(i));

            //newButton.GetComponent<Button>().onClick.RemoveAllListeners();
            //newButton.GetComponent<Button>().onClick.AddListener(() => Buy(i));
        //     RectTransform temp = newButton.GetComponent<RectTransform>();
        //     temp.anchorMin = new Vector2(temp.anchorMin.x + 187f * (i / 4) / skinButtonsTransform.rect.width, temp.anchorMin.y - 144f * (i % 4) / skinButtonsTransform.rect.height);
        //     temp.anchorMax = new Vector2(temp.anchorMax.x + 187f * (i / 4) / skinButtonsTransform.rect.width, temp.anchorMax.y - 144f * (i % 4) / skinButtonsTransform.rect.height);
        }
    }

    public void Exit()
    {
        SceneManager.LoadScene(0); //Update this later to use an actual scene rather than an index
    }

    public void Buy(int index)
    {
        Debug.Log("EEE" + index.ToString());
        List<Sprite> ownedSkins = SaveDataController.Instance.current.UnlockedSkins.Skins;
        Sprite skin = allSkins[index].skin; 
        int cost = allSkins[index].cost; 
        int currency = SaveDataController.Instance.current.Currency;
        if (ownedSkins.Contains(skin) || cost > currency)
        {
            Debug.Log("You either dont have enough money or already own this skin");
            return;
        }
    
        
        SaveDataController.Instance.current.Currency = currency - cost;
        SaveDataController.Instance.current.UnlockedSkins.Skins.Add(skin);
        Debug.Log($"You bought Skin Number {index} for {cost} and now have {currency}.");
    }
}
