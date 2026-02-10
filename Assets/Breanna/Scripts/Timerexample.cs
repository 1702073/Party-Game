using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timerexample : MonoBehaviour
{
    public TMP_Text Disvar;

    public float val;

    bool str;

    public int money;
    public TextMeshProUGUI moneyText;

    void Start()
    {
        money = SaveDataController.Instance.current.Currency;
        val = 0;
        str = false;

        start();
    }
    void Update()
    {
        if (str)
        {
            val += Time.deltaTime;
        }
        if(Disvar != null)
            Disvar.text = val.ToString();
    }
    public void start()
    {
        str = true;
    }
    public void stop()
    {
        str = false;      
    }
    public void Reset()
    {
        AddMoney();

        str = false;
        val = 0;
    }

    public void AddMoney()
    {
        money += (int)val;

        SaveDataController.Instance.current.Currency = money;

        if (moneyText != null)
            moneyText.text = money.ToString();
    }

}
