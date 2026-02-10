using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using System.IO;

public class ShopButtonScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CheckOwned();
        gameObject.GetComponent<Button>().onClick.AddListener(CheckOwned);
    }

    public void CheckOwned()
    {
        var skin = gameObject.GetComponent<Image>().sprite;
        string assetPath = AssetDatabase.GetAssetPath(skin);
        string assetName = Path.GetFileNameWithoutExtension(assetPath);
        var ownedSkins = SaveDataController.Instance.current.UnlockedSkins.Skins;
        if (!ownedSkins.Contains(assetName))
        {
            gameObject.GetComponent<Image>().color = new Color(56f/255f, 56f/255f, 56f/255f);
        }
        else
        {
            gameObject.GetComponent<Image>().color = new Color(1f, 1f, 1f);
            
        }
    }


}
