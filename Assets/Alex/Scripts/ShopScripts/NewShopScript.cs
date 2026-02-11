using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using UnityEngine.UI;
//using UnityEditor;
using System.IO;

public class NewShopScript : MonoBehaviour
{

    private ShopData[] allSkins;
    [SerializeField] public NewCharacterSelect characterSelect;


    void Start()
    {
        
        allSkins = Resources.LoadAll<ShopData>("Skins");
    }

   public void Exit()
    {
        Debug.Log("bingus");
        SceneManager.LoadScene("Start Menu"); //gurt: yo.
    }

    public void Buy(int index)
    {
        var skin = allSkins[index];
        string assetName = skin.skin.texture.name;
        var ownedSkins = SaveDataController.Instance.current.UnlockedSkins.Skins;
        if (ownedSkins.Contains(assetName))
        {
            //Set the players skin
            Debug.Log("test");
            characterSelect.ChangeSprite(allSkins[index].skin);
        }

        else
        {
            int money = SaveDataController.Instance.current.Currency;
            if (skin.cost < money)
            {
                money -= skin.cost;
                ownedSkins.Add(assetName);
                SaveDataController.Instance.current.UnlockedSkins.Skins = ownedSkins;
                SaveDataController.Instance.current.Currency = money;
            }
        }
    }
}
