using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class ShopScript : MonoBehaviour
{
    [SerializeField] private List<ShopData> allSkins;
    private int currency = 10000; //Change this later to use save data

        //SaveDataController.Instance.current.Currency;
 

    public void Exit()
    {
        SceneManager.LoadScene(0); //Update this later to use an actual scene rather than an index
    }

    public void Buy(int index)
    {
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
